using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key, MaxLength(7)]
        public string PassportNumber { get; set; }

        [MinLength(3, ErrorMessage = "First name must be 3 characters or more"), 
            MaxLength(25, ErrorMessage = "First name must be 25 characters or less")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Date of Birth"), 
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), 
            DataType(DataType.DateTime, ErrorMessage = "Invalid Date")]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"\d{8}", ErrorMessage = "Invalid phone number")]
        public int TelNumber { get; set; }

        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage = "Invalid email")]
        public string EmailAddress { get; set; }

        //prop de navigation
        public virtual List<Flight> Flights { get; set; }

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: "+ BirthDate;
        }

        //TP1-Q10: Créer les trois méthodes bool CheckProfile(...)
        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return FirstName == firstName && LastName == lastName;
        //}

        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;
        //}

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FirstName == firstName && LastName == lastName && EmailAddress == email;
            else
                return FirstName == firstName && LastName == lastName;
        }

        //TP1-Q11.a: Implémenter la méthode PassengerType()
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

    }
}
