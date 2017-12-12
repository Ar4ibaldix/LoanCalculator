namespace BusinessLayerInterfaces.Models
{
    public interface ILoanInfoModel
    {
        int Amount { get; }
        decimal Interest { get; }
        int Downpayment { get; }
        int Term { get; }

        double MonthlyPayment { get; }
        double TotalInterest { get; }
        double TotalPayment { get; }
    }
}
