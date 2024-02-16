using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Interfaces;

namespace Teknoroma.Persistence.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
           /* builder.Property(x => x.ID).HasColumnType("nvarchar(450)");
            builder.Property(x => x.MasterId).HasColumnType("nvarchar(450)");*/
        }
    }
}
