using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key, StringLength(7)]
        public string PassportNumber { get; set; }

        public FullName FullName { get; set; }

        [DisplayName("Date of Birth"), DataType(DataType.DateTime, ErrorMessage = "Invalid Date")]
        public DateTime BirthDate { get; set; }
                
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid phone number")]
        public int TelNumber { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email")]
        public string EmailAddress { get; set; }

        //public virtual List<Flight> Flights { get; set; }
        public virtual List<Ticket> Tickets { get; set; }


        public override string ToString()
        {
            return "FirstName: " + FullName.FirstName + " LastName: " + FullName.LastName + " date of Birth: "+ BirthDate;
        }

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
            else
                return FullName.FirstName == firstName && FullName.LastName == lastName;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

    }
}
