﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPIAssessment.Models
{
    public class RegisterNewAccountModel
    {
        //basically it will have everrything Account has except some fieelds
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string AccountName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //public decimal CurrentAccountBalance { get; set; }
        public AccountType AccountType { get; set; } 
        //we'll also store the hash and salt of the Account Transaction pin
        
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        //Let's add regullar expression
        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Pin must not be more than 4 digits")] //it should be a 4-digit string
        public string Pin { get; set; }
        [Required]

        [Compare("Pin", ErrorMessage = "Pins do not match")]
        public string ConfirmPin { get; set; } // we want to comppare both o...
    }
}
