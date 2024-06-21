using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace Rentify.Models.Domains
{
    public class Property
    {

        public int propertyID { get; set; }

        [Required]
        public string title { get; set; }

        public string description { get; set; }

        [Required]
        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zipCode { get; set; }

        [Required]
        public decimal price { get; set; }

        public int numberOfRooms { get; set; }

        public int numberOfBathrooms { get; set; }

        public bool ssAvailable { get; set; }

        public DateTime? dateAvailable { get; set; }

        // Foreign keys
        public int userID { get; set; } // Foreign key to User
        public int agentID { get; set; } // Foreign key to Agent

        public virtual User user { get; set; } // Navigation property to User
        public virtual Agent agent { get; set; } // Navigation property to Agent
       
        
        public virtual List<RentalApplication> RentalApplications { get; set; } // One-to-many with RentalApplication
        public virtual List<Review> Review { get; set; } // One-to-many with Review


        public Property()
        {
            Review = new List<Review>();
            RentalApplications = new List<RentalApplication>();
        }
    }
}
