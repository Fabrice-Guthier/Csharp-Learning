using System;
using System.Collections.Generic;
using System.Text;

namespace DRYExercise
{
    class BankAccount
    {
        public float MoneyAmount { get; set; }
        public AccountLog AccountLog { get; set; }
        public float Quantity { get; set; }
        public BankAccount(float moneyAmount, AccountLog accountLog)
        {
            MoneyAmount = moneyAmount;
            AccountLog = accountLog ?? throw new ArgumentNullException(nameof(accountLog));
        }

        public bool CheckQuantity(float quantity)
        {
            return Quantity == quantity;
        }

        public bool CheckMoneyAmount()
        {
            return MoneyAmount - Quantity >= 0;
        }
        public void Withdraw()
        {            
            MoneyAmount -= Quantity;
            AccountLog.Logs.Add("Debit : " + Quantity);
        }

        public void Deposit()
        {
            MoneyAmount += Quantity;
            AccountLog.Logs.Add("Credit : " + Quantity);
        }

        public void NotEnoughMoney()
        {
            Console.WriteLine("You don't have enough money for this operation");
        }

        public void Debit(float quantity)
        {
            CheckQuantity(quantity);
            if (CheckMoneyAmount())
            {
                Withdraw();
            }
            else
                NotEnoughMoney();
        }

        public void Credit(float quantity)
        {
            CheckQuantity(quantity);
            Deposit();
        }

        public void Transfer(float quantity, BankAccount toCredit)
        {
            CheckQuantity(quantity);
            if (CheckMoneyAmount())
            {
                Withdraw();
                toCredit.Deposit();
            }
            else
                NotEnoughMoney();
        }

        public string GetLogs()
        {
            return AccountLog.GetLogs();
        }
    }
}
