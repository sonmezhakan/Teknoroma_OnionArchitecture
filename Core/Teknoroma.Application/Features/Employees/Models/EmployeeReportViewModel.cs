namespace Teknoroma.Application.Features.Employees.Models
{ 
    public class EmployeeReportViewModel
    {
        public List<EmployeeEarningReportViewModel> EmployeeEarningReportViewModels { get; set; }
        public List<EmployeeSellingReportViewModel> EmployeeSellingReportViewModels { get; set; }
        public List<EmployeeDetailReportViewModel> EmployeeDetailReportViewModels { get; set; }
    }
}
