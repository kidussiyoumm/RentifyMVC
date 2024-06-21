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

        public bool IsAvailable { get; set; }

        public DateTime? DateAvailable { get; set; }

        // Foreign keys
        public int UserID { get; set; } // Foreign key to User
        public int AgentID { get; set; } // Foreign key to Agent

        public virtual User User { get; set; } // Navigation property to User
        public virtual Agent Agent { get; set; } // Navigation property to Agent
        public virtual ICollection<RentalApplication> RentalApplications { get; set; } // One-to-many with RentalApplication
        public virtual ICollection<Review> Reviews { get; set; } // One-to-many with Review

    }
}
