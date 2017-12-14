using BusinessLayerInterfaces.Models;

namespace BusinessLayerInterfaces.Managers
{
    public interface ILoanManager
    {
        ILoanCalculationModel CalculateLoanStatistics(ILoanInfoModel loanInfoModel);
    }
}
