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
    public class ProductController : BaseController
    {
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
			await CategoryViewBag();
			await BrandViewBag();

			model.ImagePath = await ImageHelper.ImageFile(productImage);
            if(ModelState.IsValid)
            {
                CreateProductCommandRequest createProduct = Mapper.Map<CreateProductCommandRequest>(model);

                HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("product/create", createProduct);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

                    ImageHelper.ImageFileDelete(model.ImagePath);

					return View(model);
				}
                
                return View();
            }
            else
            {
				ModelState.AddModelError(string.Empty, "Hatalı İşlem");

                ImageHelper.ImageFileDelete(model.ImagePath);

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

            var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}");

            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(response);
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model,IFormFile? productImage)
        {
			await ProductViewBag();
			await CategoryViewBag();
			await BrandViewBag();

			if (ModelState.IsValid)
            {
                //ürünün eski resim yolunu alıyoruz
                var oldProduct = await ApiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{model.ID}");

                if (productImage == null)
                    model.ImagePath = oldProduct.ImagePath;
                else
                    model.ImagePath = await ImageHelper.ImageFile(productImage);//Yeni resmi yükle

                model.UnitsInStock = oldProduct.UnitsInStock;


                UpdateProductCommandRequest productDTO = Mapper.Map<UpdateProductCommandRequest>(model);

                HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("product/update", productDTO);

                //İşlem başarılı ise ve yeni resim yüklendi ise bu işlemi yap
                if (response.IsSuccessStatusCode && productImage != null)
                {
                    //Eski resmi sil
                    ImageHelper.ImageFileDelete(oldProduct.ImagePath);

					return RedirectToAction("Update", model.ID);
				}
                else if(response.IsSuccessStatusCode && productImage == null)//İşlem başarılı ise ve yeni resim yüklenmedi ise sayfaya yönlendir
                {
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

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            //ürünün eski resim yolunu alıyoruz
            string oldImagePath = ApiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}").Result.ImagePath;

            HttpResponseMessage response = await ApiService.HttpClient.DeleteAsync($"product/delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                ImageHelper.ImageFileDelete(oldImagePath);

                return RedirectToAction("ProductList", "Product");
            }    

            return RedirectToAction("ProductList", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllProductQueryResponse>>("product/getall");

            List<ProductListViewModel> products = Mapper.Map<List<ProductListViewModel>>(response);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await ProductViewBag();
            await CategoryViewBag();
            await BrandViewBag();

            if (id == null) return View();

            var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}");

            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(response);

            return View(productViewModel);
        }


        private async Task ProductViewBag()
        {
            var getProductList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllProductQueryResponse>>("product/getall").Result.Select(x => new GetAllProductQueryResponse
			{
				ProductName = x.ProductName,
				ID = x.ID
			});

			ViewBag.ProductList = getProductList;
		}

        private async Task CategoryViewBag()
        {
            var getCategoryList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllCategoryQueryResponse>>("category/getall").Result.Select(x => new GetAllCategoryQueryResponse
			{
				CategoryName = x.CategoryName,
				ID = x.ID
			});

            ViewBag.CategoryList = getCategoryList;
        }

        private async Task BrandViewBag()
        {
            var getBrandList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllBrandCommandResponse>>("brand/getall").Result.Select(x => new GetAllBrandCommandResponse
			{
				BrandName = x.BrandName,
				ID = x.ID
			});

			ViewBag.BrandList = getBrandList;
		}

      
    }
}
