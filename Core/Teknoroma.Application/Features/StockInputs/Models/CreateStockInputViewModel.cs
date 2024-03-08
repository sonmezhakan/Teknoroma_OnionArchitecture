using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.StockInputs.Contants;

namespace Teknoroma.Application.Features.StockInputs.Models
{
    public class CreateStockInputViewModel
    {
        [Display(Name = StockInputColumnNames.BranchID)]
        [Required (ErrorMessage =StockInputsMessages.BranchNotNull)]
        public Guid BranchID { get; set; }

        [Display(Name = StockInputColumnNames.ProductID)]
        [Required(ErrorMessage = StockInputsMessages.ProductNotNull)]
        public Guid ProductID { get; set; }

        [Display(Name = StockInputColumnNames.SupplierID)]
        public Guid? SupplierID { get; set; }

        [Display(Name = StockInputColumnNames.InoviceNumber)]
        public string? InoviceNumber { get; set; }

        [Display(Name = StockInputColumnNames.Quantity)]
        [Required(ErrorMessage = StockInputsMessages.QuantityNotNull)]
        public int Quantity { get; set; }

        [Display(Name = StockInputColumnNames.StockEntryDate)]
        public DateTime StockEntryDate { get; set; }

        [Display(Name = StockInputColumnNames.Description)]
        public string? Description { get; set; }
    }
}
