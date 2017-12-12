using BusinessLayerInterfaces.Models;

namespace BusinessLayerInterfaces.Managers
{
    public interface ILoanManager
    {
        ILoanInfoModel CreateLoan(int amount, decimal interest, int downpayment, int term);
    }
}
