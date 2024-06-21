using System.ComponentModel.DataAnnotations;

namespace Rentify.Models.Domains
{
    public class Reviews
    {
        public int userID { get; set; } // Foreign key to User
        public virtual User user { get; set; } // Navigation property to User

        public int propertyID { get; set; } // Foreign key to Property
        public virtual Property property { get; set; } // Navigation property to Property

        [Range(1, 5)]
        public int rating { get; set; }

        public string? comment { get; set; }

        public DateTime datePosted { get; set; }
    }
}
