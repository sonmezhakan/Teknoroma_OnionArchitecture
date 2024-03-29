﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Brands.Quries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Categories.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Products.Command.Create;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Products.Models;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetList;
using Teknoroma.Application.Features.Products.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Products.Queries.GetProductEarningReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSalesDetailReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSellingReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSupplyDetailReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSupplyReport;
using Teknoroma.Application.Helpers.ImageHelpers;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{

	[Area("Admin")]
    [Authorize]
    public class ProductController : BaseController
    {
        [HttpGet]
		[Authorize(Roles = "Ürün Ekle")]
		public async Task<IActionResult> Create()
        {
            await CheckJwtBearer();
            await CategoryViewBag();
            await BrandViewBag();
            return View();
        }
        [HttpPost]
		[Authorize(Roles = "Ürün Ekle")]
		public async Task<IActionResult> Create(CreateProductViewModel model,IFormFile? productImage)
        {
            await CheckJwtBearer();
            model.ImagePath = await ImageHelper.ImageFile(productImage);
            if (!ModelState.IsValid)
            {
                await CategoryViewBag();
                await BrandViewBag();
                 
                ImageHelper.ImageFileDelete(model.ImagePath);
                 
                return View(model);
            }
            CreateProductCommandRequest createProduct = Mapper.Map<CreateProductCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("product/create", createProduct);

            if (!response.IsSuccessStatusCode)
            {
                ImageHelper.ImageFileDelete(model.ImagePath);
				await CategoryViewBag();
				await BrandViewBag();
				await HandleErrorResponse(response);
                return View(model);
            }

            return RedirectToAction("Create","Product");
        }

        [HttpGet]
		[Authorize(Roles = "Ürün Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
        {
            await CheckJwtBearer();
            await ProductViewBag();
            await CategoryViewBag();
            await BrandViewBag();

            if (id == null) return View();

            var response = await GetByProductId((Guid) id);

            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(response);
            return View(productViewModel);
        }

        [HttpPost]
		[Authorize(Roles = "Ürün Güncelle")]
		public async Task<IActionResult> Update(ProductViewModel model,IFormFile? productImage)
        {
            await CheckJwtBearer();
            await ProductViewBag();
			await CategoryViewBag();
			await BrandViewBag();

            //ürünün eski resim yolunu alıyoruz
            var oldProduct = await GetByProductId(model.ID);

            if (!ModelState.IsValid)
            {
                //Eğer hata olursa eski resmin yolunu modele tekrardan aktarıp geriye döndürsün
                model.ImagePath = oldProduct.ImagePath;
                 
                return View(model);
            }
            
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
            else if (response.IsSuccessStatusCode && productImage == null)//İşlem başarılı ise ve yeni resim yüklenmedi ise sayfaya yönlendir
            {
                return RedirectToAction("Update", model.ID);
            }
            else
            {
                await HandleErrorResponse(response);
                return View(model);
            }
        }

        [HttpGet]
		[Authorize(Roles = "Ürün Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();

            await ApiService.HttpClient.DeleteAsync($"product/delete/{id}");  

            return RedirectToAction("ProductList", "Product");
        }

        [HttpGet]
		[Authorize(Roles = "Ürün Listele")]
		public async Task<IActionResult> ProductList()
        {
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllProductQueryResponse>>("product/getall");

            List<ProductListViewModel> products = Mapper.Map<List<ProductListViewModel>>(response);

            return View(products);
        }

        [HttpGet]
		[Authorize(Roles = "Ürün Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
        {
            await CheckJwtBearer();
            await ProductViewBag();
            await CategoryViewBag();
            await BrandViewBag();

            if (id == null) return View();

            var response = await GetByProductId((Guid)id);

            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(response);

            return View(productViewModel);
        }

        [HttpGet]
		[Authorize(Roles = "Ürün Raporları")]
		public async Task<IActionResult> ProductReport(DateTime? startDate, DateTime? endDate)
        {
            await CheckJwtBearer();
            if (startDate == null || endDate == null)
			{
				startDate = DateTime.MinValue;
				endDate = DateTime.MaxValue;
			}
            else
            {
                endDate = endDate.Value.AddDays(1);
            }

            var productSellingReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductSellingReportQueryResponse>>($"product/ProductSellingReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List<ProductSellingReportViewModel> productSellingViewModels = Mapper.Map<List<ProductSellingReportViewModel>>(productSellingReport);
            
			var productEarningReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductEarningReportQueryResponse>>($"product/ProductEarningReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List<ProductEarningReportViewModel> productEarningViewModels = Mapper.Map<List<ProductEarningReportViewModel>>(productEarningReport);

            var productSupplyReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductSupplyReportQueryResponse>>($"product/ProductSupplyReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List<ProductSupplyReportViewModel> productSupplyReportViewModels = Mapper.Map<List<ProductSupplyReportViewModel>>(productSupplyReport);

			var productDetailSalesReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductSalesDetailReportQueryResponse>>($"product/ProductSalesDetailReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");


			List<ProductSalesDetailReportViewModel> productDetailSalesReportViewModels = Mapper.Map<List<ProductSalesDetailReportViewModel>>(productDetailSalesReports);

			var productSupplyDetailReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductSupplyDetailReportQueryResponse>>($"product/ProductSupplyDetailReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<ProductSupplyDetailReportViewModel> productSupplyDetailReportViewModels = Mapper.Map<List<ProductSupplyDetailReportViewModel>>(productSupplyDetailReports);

			ProductReportViewModel productReportViewModel = new ProductReportViewModel
            {
                ProductEarningViewModels = productEarningViewModels,
                ProductSellingViewModels = productSellingViewModels,
                ProductSupplyViewModels = productSupplyReportViewModels,
                ProductSalesDetailReportViewModels = productDetailSalesReportViewModels,
                ProductSupplyDetailReportViewModels = productSupplyDetailReportViewModels
			};

            return View(productReportViewModel);
        }


		private async Task<GetByIdProductQueryResponse> GetByProductId(Guid id)
        {
            return await ApiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}");
        }
        private async Task ProductViewBag()
        {
            var getProductList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameProductQueryResponse>>("product/GetAllSelectIdAndName");

			ViewBag.ProductList = getProductList;
		}

        private async Task CategoryViewBag()
        {
            var getCategoryList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameCategoryQueryResponse>>("category/GetAllSelectIdAndName");

            ViewBag.CategoryList = getCategoryList;
        }

        private async Task BrandViewBag()
        {
            var getBrandList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameBrandQueryResponse>>("brand/GetAllSelectIdAndName");

			ViewBag.BrandList = getBrandList;
		}

      
    }
}
