using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTO;

public sealed class Customer : Person
{
    [MaxLength(20)]
    public string DisplayName { get; set; } = null!;

    public AccountDetails? AccountDetails { get; set; }
}
