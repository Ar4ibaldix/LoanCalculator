using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Models;

namespace BusinessLayerCore.Models
{
    public sealed class LoanInfoModel: ILoanInfoModel
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

        public LoanInfoModel(int amount, decimal interest, int downpayment, int term)
        {
            Amount = amount;
            Interest = interest;
            Downpayment = downpayment;
            Term = term;
        }

        #region [ Set values ]

        //BL validation of parameters
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
