using System;
using BusinessLayerCore.Models;
using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Managers;
using BusinessLayerInterfaces.Models;

namespace BusinessLayerCore.Managers
{
    public sealed class LoanManager : ILoanManager
    {
        public ILoanInfoModel CreateLoan(int amount, decimal interest, int downpayment, int term)
        {
            //Creating Loan Bl model (validation inside)
            var result = new LoanInfoModel(amount, interest, downpayment, term);
            return result;
        }

        public ILoanCalculationModel CalculateLoanStatistics(ILoanInfoModel loanInfoModel)
        {
            var result = new LoanCalculationModel();
            if (loanInfoModel == null)
            {
                throw new LoanInfoModelNotFoundException();
            }
            //Calculating Loan info statistics(validation inside)
            result.MonthlyPayment = ((loanInfoModel.Amount - loanInfoModel.Downpayment) *
                                     ((double)loanInfoModel.Interest / 100) / 12) /
                                    (1 - (1 / (Math.Pow((1 + ((double)loanInfoModel.Interest / 100) / 12), loanInfoModel.Term * 12))));
            result.TotalPayment = (loanInfoModel.Term * 12 * result.MonthlyPayment);
            result.TotalInterest = result.TotalPayment - (loanInfoModel.Amount - loanInfoModel.Downpayment);
            return result;
        }
    }
}
