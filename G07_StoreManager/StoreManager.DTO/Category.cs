﻿using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTO
{
	public class Category
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}