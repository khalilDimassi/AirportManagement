using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "First name must be 3 characters or more"),
            MaxLength(25, ErrorMessage = "First name must be 25 characters or less")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
