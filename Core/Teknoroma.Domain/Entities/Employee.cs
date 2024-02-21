using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
	public class Employee : BaseEntity
    {
        public Guid BranchID { get; set; }
        public Guid DepartmentID { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Department Department { get; set; }

        //todo:Sorumlu olduğu şube entitysi oluşturulursa burada veya ayrı bir ara tablo üzerinde id tutulacak.
    }
}
