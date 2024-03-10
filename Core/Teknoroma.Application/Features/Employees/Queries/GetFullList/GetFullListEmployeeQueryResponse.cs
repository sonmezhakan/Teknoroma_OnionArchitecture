namespace Teknoroma.Application.Features.Employees.Queries.GetFullList
{
	public class GetFullListEmployeeQueryResponse
	{
		public Guid ID { get; set; }
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
        public bool IsActive { get; set; }
    }
}
