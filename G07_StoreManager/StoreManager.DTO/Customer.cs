using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.DTO;

public sealed class Customer : Person
{
    [MaxLength(20)]
    public string UserName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal AccountBalance { get; set; }

    public AccountDetails? AccountDetails { get; set; }
}
