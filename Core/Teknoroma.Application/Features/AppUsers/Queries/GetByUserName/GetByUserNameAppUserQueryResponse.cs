using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetByUserName
{
    public class GetByUserNameAppUserQueryResponse
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
