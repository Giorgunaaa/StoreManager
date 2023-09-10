using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTO;

public class AccountDetails : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    public string Password { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
