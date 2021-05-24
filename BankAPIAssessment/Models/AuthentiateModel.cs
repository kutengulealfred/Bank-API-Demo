using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPIAssessment.Models
{
    public class AuthentiateModel
    {
        [Required] // validate the account is 10-digit  using Regexp attribute
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$")]
        public string AccountNumber { get; set; }
        [Required]
        public string Pin { get; set; }
    }
}
