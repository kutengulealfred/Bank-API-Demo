﻿using BankAPIAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPIAssessment.Services.Interfaces
{
    public interface ITransactionService
    {
        Response CreateNewTransaction(Transaction transaction);
        IEnumerable<Transaction> GetAllTransactions();
        Response FindTransactionByDate(DateTime date);
        Response MakeDeposit(string AccountNumber, decimal Amount, string TransactionPin);
        Response MakeWithdrawal(string AccountNumber, decimal Amount, string TransactionPin);
        Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin);
    }
}