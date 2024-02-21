using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.AppUserRoles.Contants;

namespace Teknoroma.Application.Features.AppUserRoles.Models
{ 
    public class AppUserRoleViewModel
    {
        [Display(Name = AppUserRoleColumnNames.ID)]
        public Guid ID { get; set; }

		[Display(Name = AppUserRoleColumnNames.Name)]
		public string Name { get; set; }
    }
}
