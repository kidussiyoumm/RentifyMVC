namespace Rentify.Models.Domains
{
    public class RentalApplication
    {

        public int applicationID { get; set; }
        public string status { get; set; } // Pending, Approved, Rejected

        public DateTime applicationDate { get; set; }

        public DateTime? moveInDate { get; set; }

        public string? notes { get; set; }


        public int userID { get; set; }
        public virtual User User { get; set; } // Foreign key to User

        public int propertyID { get; set; } // Foreign key to Property
        public virtual Property property { get; set; } // Navigation property to Property




    }


}
