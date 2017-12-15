using BusinessLayerInterfaces.Models;

namespace BusinessLayerCore.Models
{
    public sealed class LoanInfoModel : ILoanInfoModel
    {
        public int Amount { get; }
        public decimal Interest { get; }
        public int Downpayment { get; }
        public int Term { get; }


        public LoanInfoModel(int amount, decimal interest, int downpayment, int term)
        {
            Amount = amount;
            Interest = interest;
            Downpayment = downpayment;
            Term = term;
        }
    }
}
