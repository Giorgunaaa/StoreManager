using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace StoreManager.DTO;

public class ProductDinamicField
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [NotMapped]
    [MaxLength(300)]
    public string Value { get; set; } = null!;

    [Required]
    public Product Product { get; set; } = null!;

    [Column("Value")]
    [MaxLength(300)]
    public string SerializedValue
    {
        get => JsonSerializer.Serialize(Value);
        set => Value = JsonSerializer.Deserialize<string>(value);
    }
}
