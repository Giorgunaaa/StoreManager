using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTO;

public sealed class Employee : Person
{
    [MaxLength(30)]
    public string? Position { get; set; }

    [MaxLength(20)]
    public string Username { get; set; } = null!;

    [MaxLength(20)]
    public string Password { get; set; } = null!; // todo: damiweret c# shi passwordis hashirebis funqcia.

    public Employee? ReportsTo { get; set; }

    public ICollection<Employee>? ReportsFrom { get; set; }

    public ICollection<City>? Cities { get; set; }
}