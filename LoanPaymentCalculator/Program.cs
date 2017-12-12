using System;
using System.Reflection;
using BusinessLayerCore.Managers;
using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Models;
using log4net;
using LoanPaymentCalculator.Helpers;
using LoanPaymentCalculator.Resources;

namespace LoanPaymentCalculator
{
    class Program
    {
        private static readonly ILog log =
    LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var isContinue = true;
            while (isContinue)
            {
                ILoanInfoModel loanInfo = null;
                var loanmanager = new LoanManager();
                var loaModel = InputHelper.FillLoanFields();
                try
                {
                    loanInfo = loanmanager.CreateLoan(loaModel.Amount, loaModel.Interest, loaModel.Downpayment,
                        loaModel.Term);
                }
                catch (InvalidAmountException)
                {
                    log.Error(Errors.InvalidAmount);
                }
                catch (InvalidInterestException)
                {
                    log.Error(Errors.InvalidInterest);
                }
                catch (InvalidDownPaymentException)
                {
                    log.Error(Errors.InvalidDownPayment);
                }
                catch (InvalidTermException)
                {
                    log.Error(Errors.InvalidTerm);
                }

                InputHelper.WriteLoanInfo(loanInfo);
                Console.WriteLine(Errors.ExitMessage);
                var exit = Console.ReadLine();
                if (!string.IsNullOrEmpty(exit))
                {
                    isContinue = exit.ToLower() != "e";
                }
            }
        }
    }
}
