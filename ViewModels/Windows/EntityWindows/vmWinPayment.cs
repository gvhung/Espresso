﻿using System;
using System.Linq;
using System.Windows.Input;
using Model;
using Model.Entity;

namespace ViewModels.Windows.EntityWindows
{
    public class vmWinPayment :Abstract.aEntityWindowViewModel
    {
        public vmWinPayment(object argPayment = null)
        {
            if (argPayment != null)
                Payment = argPayment as Payment;
            else
            {
                CreatingNew = true;
                Refresh();
            }
        }

        protected override void Refresh()
        {
            Payment = new Payment
            {
                Date = DateTime.Now,
                Account = ContextManager.ActiveAccounts.FirstOrDefault()
            };
        }

        #region Binding Properties 

        private Payment _payment;
        public Payment Payment
        {
            get { return _payment; }
            set
            {
                _payment = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        protected override void OnSaveValidation()
        {
            if (Payment.Sum <= 0)
                throw new Exception("Введите cумму платежа больше нуля");
        }

        protected override void OnSaveCreate()
        {
            // Add payment to database
            ContextManager.Context.Payments.Add(Payment);
            // Change account balance
            ContextManager.Context.dAccountsBalances.First(
                p => p.Account.Id == Payment.Account.Id).Balance -= Payment.Sum;
            // Add new transaction
            ContextManager.Context.dTransactions.Add(new dTransaction
            {
                Account = Payment.Account,
                Date = Payment.Date,
                Description = "Платёж",
                Participant = Payment.Designation,
                Sum = - Payment.Sum
            });
        }


        public ICommand cmdMakeMonthly
        { get; private set; }

        private void cmdMakeMonthly_Execute()
        { 
            if (Payment.Sum <= 0) 
            {
                FlyErrorMsg = "Введите cумму платежа";
                IsFlyErrorOpened = true;
                return;
            }
            if (CreatingNew)
            {
                MonthlyExpense NewMonthlyExpense = new MonthlyExpense
                {
                    Amount = Payment.Sum,
                    Designation = Payment.Designation,
                    Day = Payment.Date.Day,
                    RemindingDay = Payment.Date.AddDays(-5).Day
                };
                var addedExpense = ContextManager.Context.MonthlyExpenses.Add(NewMonthlyExpense);

                MonthlyPayment NewMonthlyPayment = new MonthlyPayment
                {
                    Date = DateTime.Now,
                    PaidAmount = Payment.Sum,
                    MonthlyExpense = addedExpense,
                    Account = ContextManager.Context.Accounts.FirstOrDefault()
                };
                ContextManager.Context.MonthlyPayments.Add(NewMonthlyPayment);
            }
            SaveContext();
            if (CreatingNew)
                Refresh();
        }

        #endregion
    }
}
