using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTO;

public class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    public ICollection<City>? Cities { get; set; }
}