using System;
using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Models;

namespace BusinessLayerCore.Models
{
    internal sealed class LoanInfoModel: ILoanInfoModel
    {
        private int _amount;
        private decimal _interest;
        private int _downpayment;
        private int _term;

        public int Amount
        {
            get { return _amount; }
            private set { SetAmount(value); }
        }
        public decimal Interest
        {
            get { return _interest; }
            private set { SetInterest(value); }
        }
        public int Downpayment
        {
            get { return _downpayment; }
            private set { SetDownpayment(value); }
        }

        public int Term
        {
            get { return _term; }
            private set { SetTerm(value); }
        }


        public double MonthlyPayment { get; private set; }
        public double TotalInterest { get; private set; }
        public double TotalPayment { get; private set; }

        public LoanInfoModel(int amount, decimal interest, int downpayment, int term)
        {
            Amount = amount;
            Interest = interest;
            Downpayment = downpayment;
            Term = term;

            CalculateLoanInfo();
        }

        private void CalculateLoanInfo()
        {
            MonthlyPayment = ((Amount - Downpayment) * ((double)Interest /100)/12)/(1-(1/(Math.Pow((1 + ((double)Interest / 100) / 12), Term * 12))));
            TotalPayment = (Term * 12 * MonthlyPayment);
            TotalInterest = TotalPayment - (Amount - Downpayment);
        }

        #region [ Set values ]

        private void SetAmount(int value)
        {
            if (value <= 0)
            {
                throw new InvalidAmountException();
            }
            _amount = value;
        }

        private void SetInterest(decimal value)
        {
            if (value <= 0 || value > 100)
            {
                throw new InvalidInterestException();
            }
            _interest = value;
        }

        private void SetDownpayment(int value)
        {
            if (value < 0 || value >= _amount)
            {
                throw new InvalidDownPaymentException();
            }
            _downpayment = value;
        }


        private void SetTerm(int value)
        {
            if (value <= 0)
            {
                throw new InvalidTermException();
            }
            _term = value;
        }

        #endregion
    }
}
