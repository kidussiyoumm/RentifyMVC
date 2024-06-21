namespace Rentify.Models.Domains
{
    public class RentalApplication
    {

        public int applicationID { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected

        public DateTime ApplicationDate { get; set; }

        public DateTime? MoveInDate { get; set; }

        public string Notes { get; set; }


        public int userID { get; set; }
        public virtual User User { get; set; } // Foreign key to User

        public int PropertyID { get; set; } // Foreign key to Property
        public virtual Property Property { get; set; } // Navigation property to Property




    }


}
