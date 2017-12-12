using System;
using System.Reflection;
using BusinessLayerInterfaces.Models;
using log4net;
using LoanPaymentCalculator.Models;
using LoanPaymentCalculator.Resources;
using Newtonsoft.Json.Linq;

namespace LoanPaymentCalculator.Helpers
{
    internal static class InputHelper
    {
        private static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static LoanModel FillLoanFields()
        {
            var amount = 0;
            decimal interest = 0;
            var downpayment = 0;
            var term = 0;

            Console.Clear();
            Console.Write(LoanRes.Amount);
            try
            {
                int.TryParse(Console.ReadLine(), out amount);
                if (amount <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                while (amount <= 0)
                {
                    var errorMessage = amount <= 0 ? Errors.MustBepositiveOrGreaterZero : Errors.NotValidInteger;
                    log.Error(errorMessage);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.ResetColor();
                    Console.Write(LoanRes.Amount);
                    int.TryParse(Console.ReadLine(), out amount);
                }
            }

            Console.Write(LoanRes.Interest);

            try
            {
                var interestString = Console.ReadLine();                                                                    // Reading From console
                var trimmed = interestString.Trim('%').Replace(",",".");                                                                     // Trimming '%' symbols
                if (!decimal.TryParse(trimmed, out interest))
                {
                    throw new Exception(Errors.NotValidInteger);
                }
                if (interest <= 0 || interest > 100)
                {
                    throw new Exception("");
                }
            }
            catch (Exception e)
            {
                var notValidString = !string.IsNullOrEmpty(e.Message);                                                      // flag for error mesages
                while (interest <= 0 || interest > 100) 
                {
                    string errorMessage;
                    if (interest <= 0)
                    {
                        errorMessage = notValidString ? e.Message : Errors.MustBepositiveOrGreaterZero;
                    }
                    else if (interest > 100)
                    {
                        errorMessage = Errors.PersentLess;
                    }
                    else
                    {
                        errorMessage = Errors.NotValidInteger;
                    }
                    log.Error(errorMessage);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.ResetColor();
                    Console.Write(LoanRes.Interest);
                    var interestString = Console.ReadLine();
                    var trimmed = interestString.Trim('%');                                                                 // Trimming not numerical symbols
                    notValidString = !decimal.TryParse(trimmed, out interest);
                }
            }

            Console.Write(LoanRes.Downpayment);

            try
            {
                if (!int.TryParse(Console.ReadLine(), out downpayment))
                {
                    throw new Exception(Errors.NotValidInteger);
                };
                if (downpayment < 0 )
                {
                    throw new Exception("");
                }
                if (downpayment >= amount)
                {
                    throw new Exception("");
                }
            }
            catch(Exception e)
            {
                var notValidString = !string.IsNullOrEmpty(e.Message);
                while (downpayment < 0 || downpayment >= amount || notValidString)
                {
                    string errorMessage;
                    if (downpayment < 0)
                    {
                        errorMessage = Errors.MustBepositive;
                    }
                    else if (downpayment >= amount)
                    {
                        errorMessage = Errors.DownpaymentLessAmount;
                    }
                    else
                    {
                        errorMessage = Errors.NotValidInteger;
                    }
                    log.Error(errorMessage);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.ResetColor();
                    Console.Write(LoanRes.Downpayment);
                    notValidString = !int.TryParse(Console.ReadLine(), out downpayment);
                }
            }

            Console.Write(LoanRes.Term);
            try
            {
                int.TryParse(Console.ReadLine(), out term);
                if (term <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                while (term <= 0)
                {
                    var errorMessage = amount <= 0 ? Errors.MustBepositiveOrGreaterZero : Errors.NotValidInteger;
                    log.Error(errorMessage);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.ResetColor();
                    Console.Write(LoanRes.Term);
                    int.TryParse(Console.ReadLine(), out term);
                }
            }

            Console.WriteLine();
            var result = new LoanModel(amount, interest, downpayment, term);
            return result;
        }

        public static void WriteLoanInfo(ILoanInfoModel infoModel)    // Write json to console
        {
            JObject jObject;
            if (infoModel != null)
            {
                jObject = new JObject(new JProperty(LoanRes.MonthlyPayment, Math.Round(infoModel.MonthlyPayment, 2)),
                    new JProperty(LoanRes.TotalInterest, Math.Round(infoModel.TotalInterest, 2)),
                    new JProperty(LoanRes.TotalPayment, Math.Round(infoModel.TotalPayment, 2)));
            }
            else
            {
                jObject = new JObject();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(jObject);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
