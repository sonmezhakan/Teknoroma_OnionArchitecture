﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Domain.Entities
{
    public class AppUser: IdentityUser<Guid>
    {

        public virtual List<Employee> Employees { get; set; }
    }
}
