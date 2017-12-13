namespace BusinessLayerInterfaces.Models
{
    public interface ILoanInfoModel
    {
        int Amount { get; }
        decimal Interest { get; }
        int Downpayment { get; }
        int Term { get; }
    }
}
