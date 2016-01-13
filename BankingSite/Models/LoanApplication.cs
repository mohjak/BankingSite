using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankingSite.Models
{    
    public class LoanApplication
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Current age in Years")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Total Annual Pre-Tax Income")]
        
        public Decimal AnnualIncome { get; set; }

        public bool IsAccepted { get; set; }
    }  
}
