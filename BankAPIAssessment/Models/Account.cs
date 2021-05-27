using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankAPIAssessment.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountName => FirstName.ToUpper() + " " + LastName.ToUpper();
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal CurrentAccountBalance { get; set; }
        //[JsonConverter(typeof(StringEnumConverter))]
        public AccountType AccountType { get; set; } // This will be an Enum to show if the account to be created is "Savings" or "Current"
        public string AccountNumberGenerated { get; set; } // we shall generate accountNumber here!

        //we'll also store the hash and salt of the Account Transaction pin
        [JsonIgnore]
        public byte[] PinHash { get; set; }
        [JsonIgnore]
        public byte[] PinSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }


        //We will generate an accountNumberr using a Random obj
         Random rand = new Random();

        public Account()
        {
            AccountNumberGenerated = Convert.ToString((long)Math.Floor(rand.NextDouble() * 9_000_000_000L + 1_000_000_000L)); // we did 9_000_000_000 so we could get a 10-digit random number
            //also AccountName property = FirstName+LastName
            //AccountName = $"{FirstName} {LastName}"; //e.g John Doe
        }
    }



    public enum AccountType
    {
        Savings, //savings => 0., current => 1 etc
        Current

    }
}

