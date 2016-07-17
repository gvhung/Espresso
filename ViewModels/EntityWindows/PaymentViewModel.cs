﻿using System;
using System.Linq;
using System.Windows.Input;
using Model;
using Model.Entity;

namespace ViewModels.EntityWindows
{
    public class PaymentViewModel :Abstract.aEntityWindowViewModel
    {
        public PaymentViewModel(object argPayment = null)
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

        protected override void cmdSave_Execute()
        {
            if (CreatingNew)
                _context.Payments.Add(Payment);
            SaveContext();
        }


        public ICommand cmdMakeMonthly
        { get; private set; }

        private void cmdMakeMonthly_Execute()
        {
            if (CreatingNew)
            {
                MonthlyExpense NewMonthlyExpense = new MonthlyExpense
                {
                    Amount = Payment.Sum,
                    Designation = Payment.Designation,
                    Day = Payment.Date.Day,
                    RemindingDay = Payment.Date.AddDays(-5).Day
                };
                var addedExpense = _context.MonthlyExpenses.Add(NewMonthlyExpense);

                MonthlyPayment NewMonthlyPayment = new MonthlyPayment
                {
                    Date = DateTime.Now,
                    PaidAmount = Payment.Sum,
                    MonthlyExpense = addedExpense,
                    Account = _context.Accounts.FirstOrDefault()
                };
                _context.MonthlyPayments.Add(NewMonthlyPayment);
            }
            SaveContext();
        }

        #endregion
    }
}