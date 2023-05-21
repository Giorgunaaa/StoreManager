using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTO
{
    public sealed class Employee : Person
    {
        [MaxLength(30)]
        public string? Prosition { get; set; }

        public Employee? ReportsTo { get; set; }

        public ICollection<Employee>? ReportsFrom { get; set; }
    }
}
