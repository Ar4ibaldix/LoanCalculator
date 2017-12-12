using BusinessLayerCore.Models;
using BusinessLayerInterfaces.Managers;
using BusinessLayerInterfaces.Models;

namespace BusinessLayerCore.Managers
{
    public sealed class LoanManager: ILoanManager
    {
        public ILoanInfoModel CreateLoan(int amount, decimal interest, int downpayment, int term)
        {
            var result = new LoanInfoModel(amount, interest, downpayment, term);
            return result;
        }
    }
}
