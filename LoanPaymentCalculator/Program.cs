using System;
using System.Reflection;
using BusinessLayerCore.Managers;
using BusinessLayerCore.Models;
using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Models;
using log4net;
using LoanPaymentCalculator.Helpers;
using LoanPaymentCalculator.Resources;

namespace LoanPaymentCalculator
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var isContinue = true;
            while (isContinue)                                                  //Loop while user not enter 'Exit'
            {
                ILoanCalculationModel loanInfo = null;
                var loanmanager = new LoanManager();
                var loanModel = InputHelper.FillLoanFields();                  // Filling viewModel from console
                try
                {                                        
                    loanInfo = loanmanager.CalculateLoanStatistics(loanModel); //Calculating loan info 

                }

                //Catching  Bl exceptions and writin to log
                catch (InvalidAmountException)
                {
                    Log.Error(Errors.InvalidAmount);
                }
                catch (InvalidInterestException)
                {
                    Log.Error(Errors.InvalidInterest);
                }
                catch (InvalidDownPaymentException)
                {
                    Log.Error(Errors.InvalidDownPayment);
                }
                catch (InvalidTermException)
                {
                    Log.Error(Errors.InvalidTerm);
                }
                catch (LoanInfoModelNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Errors.LoanInfoModelNotFound);
                    Console.ResetColor();
                    Log.Error(Errors.LoanInfoModelNotFound);
                }
                catch (InvalidTotalInterestException)
                {
                    Log.Error(Errors.InvalidTotalInterest);
                }
                catch (InvalidMonthlyPaymentException)
                {
                    Log.Error(Errors.InvalidMonthlyPayment);
                }
                catch (InvalidTotalPaymentException)
                {
                    Log.Error(Errors.InvalidTotalPayment);
                }
                InputHelper.WriteLoanInfo(loanInfo);                                // Writing to the display
                Console.WriteLine(Errors.ExitMessage);
                var exit = Console.ReadLine();
                if (!string.IsNullOrEmpty(exit))                                    // Trying to exit 
                {
                    isContinue = exit.ToLower() != "e";
                }
            }
        }
    }
}
