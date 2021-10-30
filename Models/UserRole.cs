using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class UserRole
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public Role Role { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User User { get; set; }
    }

    public enum Role
    {
        ADMIN,
        MODERATOR
    }
}
