using Microsoft.AspNetCore.Identity;

namespace Teknoroma.Domain.Entities
{
    public class AppUser: IdentityUser<Guid>
    {

        public virtual Employee Employee { get; set; }
        public virtual List<StockInput> StockInputs { get; set; }
        public virtual AppUserProfile AppUserProfile { get; set; }
    }
}
