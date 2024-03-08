
using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.StockInputs.Contants;

namespace Teknoroma.Application.Features.StockInputs.Models
{
    public class UpdateStockInputViewModel
    {
        [Display(Name = StockInputColumnNames.ID)]
        [Required(ErrorMessage = StockInputsMessages.IDNotNull)]
        public Guid ID { get; set; }

        [Display(Name = StockInputColumnNames.SupplierID)]
        public Guid? SupplierID { get; set; }

        [Display(Name = StockInputColumnNames.InoviceNumber)]
        public string? InoviceNumber { get; set; }

        [Display(Name = StockInputColumnNames.Quantity)]
        [Required(ErrorMessage = StockInputsMessages.QuantityNotNull)]
        public int Quantity { get; set; }

        [Display(Name = StockInputColumnNames.Description)]
        public string? Description { get; set; }
    }
}
