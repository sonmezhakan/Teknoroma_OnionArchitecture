using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Products.Models
{
    public class CreateProductViewModel
    {
        public CreateProductViewModel()
        {
            UnitsInStock = 0;
        }
        [Required(ErrorMessage = "İsim Boş Olamaz!")]
        [Display(Name = "Product Name*")]
        public string ProductName { get; set; }


        [Range(0.00, double.MaxValue, ErrorMessage = "Fiyatı doğru giriniz!")]
        [Display(Name = "Unit Price*")]
        public decimal? UnitPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stoğu doğru giriniz!")]
        [Display(Name = "Units In Stock*")]
        public int? UnitsInStock { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Kritik Miktarı doğru giriniz!")]
        [Display(Name = "Critical Stock*")]
        public int? CriticalStock { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Image")]
        public string? ImagePath { get; set; }

        [Display(Name = "Brand")]
        public Guid? BrandId { get; set; }

        [Required(ErrorMessage = "Kategori Boş Olamaz!")]
        [Display(Name = "Category*")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Statu")]
        public bool? IsActive { get; set; }
    }
}
