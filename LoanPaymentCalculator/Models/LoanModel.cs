namespace LoanPaymentCalculator.Models
{
    internal sealed class LoanModel
    {
        public int Amount { get; private set; }
        public decimal Interest { get; private set; }
        public int Downpayment { get; private set; }
        public int Term { get; private set; }

        public LoanModel(int amount, decimal interest, int downpayment, int term)
        {
            Amount = amount;
            Interest = interest;
            Downpayment = downpayment;
            Term = term;
        }
    }
}
