using System.ComponentModel.DataAnnotations;

namespace Rentify.Models.Domains
{
    public class Agent
    {
        [Key]
        public int agentID { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        public string phoneNumber { get; set; }

        public string officeAddress { get; set; }

        public virtual List<Property> Properties { get; set; } // One-to-many with Property
        public virtual List<User> Users { get; set; } // Many-to-many with User


        public Agent()
        {
            Properties = new List<Property>();
            Users = new List<User>();
        }

    }
}
