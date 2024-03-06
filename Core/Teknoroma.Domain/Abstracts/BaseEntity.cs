using Teknoroma.Domain.Enums;
using Teknoroma.Domain.Interfaces;

namespace Teknoroma.Domain.Abstracts
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            ID = Guid.NewGuid();
            MasterId = Guid.NewGuid();

            IsActive = true;
        }

        public Guid ID { get; set; }
        public Guid MasterId { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIpAddress { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }

        public DateTime? DeletedDate { get; set; }
        public string? DeletedComputerName { get; set; }
        public string? DeletedIpAddress { get; set; }

        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        
    }
}
