using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetByUserName
{
    public class GetByUserNameAppUserQueryValidator:AbstractValidator<GetByUserNameAppUserQueryRequest>
    {
        public GetByUserNameAppUserQueryValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz!");
        }
    }
}
