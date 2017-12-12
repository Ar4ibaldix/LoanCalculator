using System;
using BusinessLayerCore.Managers;
using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Managers;
using Moq;
using NUnit.Framework;


namespace LoanPaymentCalculatorTests.Managers
{
    [TestFixture]
    public class LoanManagerTests
    {
        [Test]
        public void CreateLoanInfoMethodReturnCorrectResult()
        {
            var loanmanager = new Mock<ILoanManager>();
            loanmanager.Object.CreateLoan(4, 3, 2, 1);
            loanmanager.Verify(x => x.CreateLoan(4, 3, 2, 1), Times.Once);
            Assert.DoesNotThrow(()=> loanmanager.Object.CreateLoan(4, 3, 2, 1));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [Test]
        public void CreateLoanInfoMethodThrowExceptionIfNotValidAmount(int amount)
        {
            var manager = new LoanManager();
            Assert.Throws<InvalidAmountException>(() => manager.CreateLoan(amount, 2, 5, 10));
        }

        [Test]
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(101)]        
        public void CreateLoanInfoMethodThrowExceptionIfNotValidInterest(decimal interest)
        {
            var manager = new LoanManager();
            Assert.Throws<InvalidInterestException>(() => manager.CreateLoan(10, interest, 5, 10));
        }

        [Test]
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(100)] //Checking if downpayment > amount
        [TestCase(10)] //Checking if downpayment = amount
        public void CreateLoanInfoMethodThrowExceptionIfNotValidDownPayment(int payment)
        {
            var manager = new LoanManager();
            Assert.Throws<InvalidDownPaymentException>(() => manager.CreateLoan(10, 5, payment, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CreateLoanInfoMethodThrowExceptionIfNotValidDownTerm(int term)
        {
            var manager = new LoanManager();
            Assert.Throws<InvalidTermException>(() => manager.CreateLoan(10, 5, 5, term));
        }
    }
}
