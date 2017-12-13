namespace BusinessLayerInterfaces.Models
{
    public interface ILoanCalculationModel
    {
        double MonthlyPayment { get; }
        double TotalInterest { get; }
        double TotalPayment { get; }
    }
}
