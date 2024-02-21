using Microsoft.AspNetCore.Identity;

namespace Teknoroma.Domain.Entities
{
    public class AppUser: IdentityUser<Guid>
    {

        public virtual List<Employee> Employees { get; set; }
        public virtual List<StockInput> StockInputs { get; set; }
        public virtual AppUserProfile AppUserProfile { get; set; }
    }
}
