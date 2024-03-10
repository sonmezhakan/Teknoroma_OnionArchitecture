namespace Teknoroma.Application.Features.Employees.Queries.GetById
{
    public class GetByIdEmployeeQueryResponse
    {
        public Guid ID { get; set; }
        public Guid BranchID { get; set; }
        public Guid DepartmentID { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
		public decimal? Salary { get; set; }
        public bool? IsActive { get; set; }
    }
}
