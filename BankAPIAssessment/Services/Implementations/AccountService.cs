﻿using BankAPIAssessment.Data;
using BankAPIAssessment.Models;
using BankAPIAssessment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPIAssessment.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private ApplicationDbContext _dbContext;

        public AccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Account Authenticate(string AccountNumber, string Pin)
        {
            //We authenticate account here
            ///does account exist for that number
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).SingleOrDefault();
            if (account == null)
                return null;
            //If we have a match
            //verify pinHash
            if (!VerifyPinHash(Pin, account.PinHash, account.PinSalt))
                return null;

            //Once Authentiation is passed
            return account;
        }

        private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
        {
            if (string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException("Pin");
            
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pinSalt))
            {
                var computedPinHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Pin));
                for (int i = 0; i < computedPinHash.Length; i++)
                {
                    if (computedPinHash[i] != pinHash[i]) return false;
                }
            }

            return true;
        }

        public Account Create(Account account, string Pin, string ConfirmPin)
        {
            //this is to create a new account
            if (_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("An account already exists with this email");
            //validate pin
            if (!Pin.Equals(ConfirmPin)) throw new ArgumentException("Pins do not match", "Pin");

            //Once all validation passes, lets create account, 
            ///we are hasshiing /encryptiing pin firstt
            byte[] pinHash, pinSalt;
            CreatePinHash(Pin, out pinHash, out pinSalt); // create this crypto method

            account.PinHash = pinHash;
            account.PinSalt = pinSalt;

            
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            return account;
        }

        private static void CreatePinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }
        }

        public void Delete(int Id)
        {
            var account = _dbContext.Accounts.Find(Id);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).FirstOrDefault();
            if (account == null) return null;

            return account;
        }

        public Account GetById(int Id)
        {
            var account = _dbContext.Accounts.Where(x => x.Id == Id).FirstOrDefault();
            if (account == null) return null;

            return account;
        }

        public void Update(Account account, string Pin = null)
        {
           var accounToBeUpdated = _dbContext.Accounts.Where(x => x.Email == account.Email).SingleOrDefault();//we can ctually use Id to look it
            //instead of email...
            if (accounToBeUpdated == null) throw new ApplicationException("Account does not exist");
            //if it exists, let's listen for user wanting to change any of his properties 
            if (!string.IsNullOrWhiteSpace(account.Email))
            {
                
                
                if (_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("This Email " + account.Email + " already exists");
                

                accounToBeUpdated.Email = account.Email;
            }

            //we wwant to allow the user to be able to change only EMail and PhoneNumbber and Pin
            if (!string.IsNullOrWhiteSpace(account.PhoneNumber))
            {
               
                if (_dbContext.Accounts.Any(x => x.PhoneNumber == account.PhoneNumber)) throw new ApplicationException("This PhoneNumber " + account.PhoneNumber + " already exists");
                

                accounToBeUpdated.PhoneNumber = account.PhoneNumber;
            }

            
            if (!string.IsNullOrWhiteSpace(Pin))
            {
               

                byte[] pinHash, pinSalt;
                CreatePinHash(Pin, out pinHash, out pinSalt);

                accounToBeUpdated.PinHash = pinHash;
                accounToBeUpdated.PinSalt = pinSalt;

            }
            accounToBeUpdated.DateLastUpdated = DateTime.Now;

           
            _dbContext.Accounts.Update(accounToBeUpdated);
            _dbContext.SaveChanges();
        }
    }
}
