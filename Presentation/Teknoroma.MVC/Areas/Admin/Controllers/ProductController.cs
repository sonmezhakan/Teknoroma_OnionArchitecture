using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Brands.Quries.GetList;
using Teknoroma.Application.Features.Categories.Queries.GetList;
using Teknoroma.Application.Features.Products.Command.Create;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Products.Models;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetList;
using Teknoroma.Infrastructure.ImageHelpers;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public ProductController(IMapper mapper, IApiService apiService)
        {
            _mapper = mapper;
            _apiService = apiService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CategoryViewBag();
            await BrandViewBag();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model,IFormFile? productImage)
        {
            model.ImagePath = await ImageFile(productImage);
            if(ModelState.IsValid)
            {
                CreateProductCommandRequest createProduct = _mapper.Map<CreateProductCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("product/create", createProduct);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					ImageFileDelete(model.ImagePath);

					await CategoryViewBag();
					await BrandViewBag();

					return View(model);
				}
                
                return View();
            }
            else
            {
				ModelState.AddModelError(string.Empty, "Hatalı İşlem");

				ImageFileDelete(model.ImagePath);

                await CategoryViewBag();
                await BrandViewBag();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            await ProductViewBag();
            await CategoryViewBag();
            await BrandViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}");

            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(response);
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model,IFormFile? productImage)
        {
            
            if (ModelState.IsValid)
            {
                //ürünün eski resim yolunu alıyoruz
                var oldProduct = await _apiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{model.ID}");

                //Yeni resmi yükle
                model.ImagePath = await ImageFile(productImage);
                model.UnitsInStock = oldProduct.UnitsInStock;

                UpdateProductCommandRequest productDTO = _mapper.Map<UpdateProductCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PutAsJsonAsync("product/update", productDTO);

                if (response.IsSuccessStatusCode)
                {
                    //Eski resmi sil
                    ImageFileDelete(oldProduct.ImagePath);

					return RedirectToAction("Update", model.ID);
				}
                else
                {
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					//Eğer hata olursa eski resmin yolunu modele tekrardan aktarıp geriye döndürsün
					model.ImagePath = oldProduct.ImagePath;

					return View(model);
				}
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

                await ProductViewBag();
                await CategoryViewBag();
                await BrandViewBag();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            //ürünün eski resim yolunu alıyoruz
            string oldImagePath = _apiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}").Result.ImagePath;

            HttpResponseMessage response = await _apiService.HttpClient.DeleteAsync($"product/delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                ImageFileDelete(oldImagePath);

                return RedirectToAction("ProductList", "Product");
            }    

            return RedirectToAction("ProductList", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllProductQueryResponse>>("product/getall");

            List<ProductListViewModel> products = _mapper.Map<List<ProductListViewModel>>(response);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await ProductViewBag();
            await CategoryViewBag();
            await BrandViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}");

            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(response);

            return View(productViewModel);
        }


        private async Task ProductViewBag()
        {
            var getProductList =  _apiService.HttpClient.GetFromJsonAsync<List<GetAllProductQueryResponse>>("product/getall").Result.Select(x => new GetAllProductQueryResponse
			{
				ProductName = x.ProductName,
				ID = x.ID
			}).ToList();

			ViewBag.ProductList = getProductList;
		}

        private async Task CategoryViewBag()
        {
            var getCategoryList =  _apiService.HttpClient.GetFromJsonAsync<List<GetAllCategoryQueryResponse>>("category/getall").Result.Select(x => new GetAllCategoryQueryResponse
			{
				CategoryName = x.CategoryName,
				ID = x.ID
			}).ToList();
            if (ViewBag.CategoryList == null)
            {
                ViewBag.CategoryList = getCategoryList;
            }
        }

        private async Task BrandViewBag()
        {
            var getBrandList = _apiService.HttpClient.GetFromJsonAsync<List<GetAllBrandCommandResponse>>("brand/getall").Result.Select(x => new GetAllBrandCommandResponse
			{
				BrandName = x.BrandName,
				ID = x.ID
			}); ;

			ViewBag.BrandList = getBrandList;
		}

        //ImageUpload Metot
        private async Task<string> ImageFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                string path = "";
                var imageResult = ImageHelper.ImageUpload(formFile.FileName);

                if (imageResult != "0")
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", imageResult);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    };

                    return imageResult;
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Görsel formatı uygun değil.");
                    return "placeholer.jpg";
                }
            }
            else
            {
                return "placeholer.jpg";
            }
        }

        //Ürün resimlerinde değişiklik yapılacağı zaman ilk önce eski resmi silen metot
        public void ImageFileDelete(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && imagePath != "placeholder.svg")
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", imagePath);

                System.IO.File.Delete(path);
            }
        }
    }
}
