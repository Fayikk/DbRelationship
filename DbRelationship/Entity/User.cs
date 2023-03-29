﻿using System.ComponentModel.DataAnnotations;

namespace DbRelationship.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Product> Products { get; set; } 
    }
}
