namespace LoanPaymentCalculator.Models
{
    internal sealed class LoanModel
    {
        public int Amount { get; set; }
        public decimal Interest { get; set; }
        public int Downpayment { get; set; }
        public int Term { get; set; }

        public LoanModel(int amount,decimal interest, int downpayment, int term)
        {
            Amount = amount;
            Interest = interest;
            Downpayment = downpayment;
            Term = term;
        }
    } 
}
