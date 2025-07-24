using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.User
{
    public class ApplicationUser
    {
        [Key]
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
