using BusinessLayerCore.Models;
using BusinessLayerInterfaces.Exceptions;
using NUnit.Framework;

namespace LoanPaymentCalculatorTests.Models
{
    [TestFixture]
    public class LoanInfoModelTests
    {
        [Test]
        public void LoanInfoModelCanBeCreated()
        {
            const int expectedAmount = 100000;
            const decimal expectedInterest = 5.5m;
            const int expectedDownpayment = 20000;
            const int expectedTerm = 30;

            var loanInfoModel = new LoanInfoModel(expectedAmount, expectedInterest, expectedDownpayment, expectedTerm);
            Assert.DoesNotThrow(() => new LoanInfoModel(expectedAmount, expectedInterest, expectedDownpayment, expectedTerm));
            Assert.AreEqual(expectedAmount, loanInfoModel.Amount);
            Assert.AreEqual(expectedInterest, loanInfoModel.Interest);
            Assert.AreEqual(expectedDownpayment, loanInfoModel.Downpayment);
            Assert.AreEqual(expectedTerm, loanInfoModel.Term);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(-100)]
        public void LoanInfoModelThrowExceptionIfNotValidAmount(int amount)
        {        
            Assert.Throws<InvalidAmountException>(() => new LoanInfoModel(amount, 5, 5, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(101)]
        public void LoanInfoModelThrowExceptionIfNotValidInterest(decimal interest)
        {
            Assert.Throws<InvalidInterestException>(() => new LoanInfoModel(10, interest, 5, 10));
        }

        [Test]
        [TestCase(-100)]
        [TestCase(10)]
        public void LoanInfoModelThrowExceptionIfNotValidDownPayment(int downpayment)
        {
            Assert.Throws<InvalidDownPaymentException>(() => new LoanInfoModel(10, 5, downpayment, 10));
        }


        [Test]
        [TestCase(-100)]
        [TestCase(0)]
        public void LoanInfoModelThrowExceptionIfNotValidTerm(int term)
        {
            Assert.Throws<InvalidTermException>(() => new LoanInfoModel(10, 5, 5, term));
        }
    }
}
