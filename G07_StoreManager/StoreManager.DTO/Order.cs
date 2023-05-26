using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.DTO;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ShippedDate { get; set; }

    [MaxLength(150)]
    public string? ShipAddress { get; set; }

    [Required] 
    public Employee Employee { get; set; } = null!;

    [Required] 
    public Customer Customer { get; set; } = null!;
}
