using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Domain.Interfaces
{
    public interface IEntity
    {
        public Guid ID { get; set; }
        public Guid MasterId { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIpAddress { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }

        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
