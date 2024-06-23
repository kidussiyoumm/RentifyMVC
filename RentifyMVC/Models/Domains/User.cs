using System.ComponentModel.DataAnnotations;

namespace Rentify.Models.Domains
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public byte password { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        public string phoneNumber { get; set; }

        [Required]
        public string Role { get; set; } // Assuming roles are strings like "User" or "Admin"

        public virtual List<Property> Properties { get; set; } // One-to-many with Property
        public virtual List<Agent> Agents { get; set; } // Many-to-many with Agent



        public User()
        {
            Properties = new List<Property>();
            Agents = new List<Agent>();
        }
    }
}
