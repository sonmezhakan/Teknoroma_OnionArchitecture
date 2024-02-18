using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Teknoroma.Application.Features.Products.Models
{
    public class ProductListViewModel
    {
        [Display(Name = "ID")]
        public Guid ID { get; set; }

        [Display(Name = "Product Name*")]
        public string ProductName { get; set; }

        [Display(Name = "Unit Price*")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Units In Stock*")]
        public int UnitsInStock { get; set; }
        [Display(Name = "Critical Stock*")]
        public int CriticalStock { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        [Display(Name = "Category*")]
        public string CategoryName { get; set; }
    }
}
