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
            while (isContinue) //Loop while user not enter 'Exit'
            {
                ILoanCalculationModel loanInfo = null;
                var loanmanager = new LoanManager();
                var loaModel = InputHelper.FillLoanFields(); // Filling viewModel from console
                try
                {
                    var loanModel = loanmanager.CreateLoan(loaModel.Amount, loaModel.Interest, loaModel.Downpayment,
                        loaModel.Term);  //Get BL Loan model
                    loanInfo = loanmanager.CalculateLoanStatistics(loanModel); //Calculating loan info 

                }

                //Catching  Bl exceptions and writin to log
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
                catch (LoanInfoModelNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Errors.LoanInfoModelNotFound);
                    Console.ResetColor();
                    log.Error(Errors.LoanInfoModelNotFound);
                }
                catch (InvalidTotalInterestException)
                {
                    log.Error(Errors.InvalidTotalInterest);
                }
                catch (InvalidMonthlyPaymentException)
                {
                    log.Error(Errors.InvalidMonthlyPayment);
                }
                catch (InvalidTotalPaymentException)
                {
                    log.Error(Errors.InvalidTotalPayment);
                }
                InputHelper.WriteLoanInfo(loanInfo); // Writing to the display
                Console.WriteLine(Errors.ExitMessage);
                var exit = Console.ReadLine();
                if (!string.IsNullOrEmpty(exit)) // Trying to exit 
                {
                    isContinue = exit.ToLower() != "e";
                }
            }
        }
    }
}
