using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Models;

namespace BusinessLayerCore.Models
{
    internal sealed class LoanCalculationModel : ILoanCalculationModel
    {
        private double _monthlyPayment;
        private double _totalInterest;
        private double _totalPayment;

        public double MonthlyPayment
        {
            get { return _monthlyPayment; }
            set { SetMonthlyPayment(value); }
        }
        public double TotalInterest
        {
            get { return _totalInterest; }
            set { SetTotalInterest(value); }
        }
        public double TotalPayment {
            get { return _totalPayment; }
            set { SetTotalPayment(value); }
        }

    #region [ Set values ]

    private void SetMonthlyPayment(double value)
        {
            if (value <= 0)
            {
                throw new InvalidMonthlyPaymentException();
            }
            _monthlyPayment = value;
        }

        private void SetTotalInterest(double value)
        {
            if (value <= 0)
            {
                throw new InvalidTotalInterestException();
            }
            _totalInterest = value;
        }

        private void SetTotalPayment(double value)
        {
            if (value < 0 || value <= _monthlyPayment)
            {
                throw new InvalidTotalPaymentException();
            }
            _totalPayment = value;
        }

        #endregion
    }
}
