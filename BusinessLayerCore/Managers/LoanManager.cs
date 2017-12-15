﻿using System;
using BusinessLayerCore.Models;
using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Managers;
using BusinessLayerInterfaces.Models;

namespace BusinessLayerCore.Managers
{
    public sealed class LoanManager : ILoanManager
    {
        public ILoanCalculationModel CalculateLoanStatistics(ILoanInfoModel loanInfoModel)
        {
            var result = new LoanCalculationModel();
            //Validate icoming data
            if (loanInfoModel == null)
            {
                throw new LoanInfoModelNotFoundException();
            }
            if (loanInfoModel.Amount <= 0)
            {
                throw new InvalidAmountException();
            }
            if (loanInfoModel.Interest <= 0 || loanInfoModel.Interest > 100)
            {
                throw new InvalidInterestException();
            }
            if (loanInfoModel.Downpayment < 0 || loanInfoModel.Downpayment >= loanInfoModel.Amount)
            {
                throw new InvalidDownPaymentException();
            }
            if (loanInfoModel.Term <= 0)
            {
                throw new InvalidTermException();
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
