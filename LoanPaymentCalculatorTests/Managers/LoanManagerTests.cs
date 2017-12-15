using BusinessLayerCore.Managers;
using BusinessLayerCore.Models;
using BusinessLayerInterfaces.Exceptions;
using BusinessLayerInterfaces.Managers;
using BusinessLayerInterfaces.Models;
using Moq;
using NUnit.Framework;

namespace LoanPaymentCalculatorTests.Managers
{
    [TestFixture]
    public class LoanManagerTests
    {       
        [Test]
        [TestCase(null)]
        public void CalculateLoanStatisticsMethodThrowExceptionIfNotparamIsNull(ILoanInfoModel term)
        {
            var manager = new LoanManager();
            Assert.Throws<LoanInfoModelNotFoundException>(() => manager.CalculateLoanStatistics(term));
        }

        [Test]
        public void CalculateLoanStatisticsMethodReturnsResult()
        {  
            var loanInfoModel = new LoanInfoModel(100000, 5.5m ,20000, 30);         
            var manager =  new Mock<ILoanManager>();
            manager.Object.CalculateLoanStatistics(loanInfoModel);
            manager.Verify(x => x.CalculateLoanStatistics(loanInfoModel), Times.Once);
            Assert.DoesNotThrow(() => manager.Object.CalculateLoanStatistics(loanInfoModel));
        }

        [Test]
        [TestCase(-100)]
        public void CalculateLoanStatisticsThrowExceptionIfNotValidAmount(int amount)
        {
            var loanInfoModel = new LoanInfoModel(amount, 5, 5, 10);
            var manager = new Mock<ILoanManager>();
            manager.Setup(x => x.CalculateLoanStatistics(It.IsAny<ILoanInfoModel>())).Throws<InvalidAmountException>();
            Assert.Throws<InvalidAmountException>(() => manager.Object.CalculateLoanStatistics(loanInfoModel));
        }

        [Test]
        [TestCase(102)]
        public void CalculateLoanStatisticsThrowExceptionIfNotValidInterest(int interest)
        {
            var loanInfoModel = new LoanInfoModel(10, interest, 5, 10);
            var manager = new Mock<ILoanManager>();
            manager.Setup(x => x.CalculateLoanStatistics(It.IsAny<ILoanInfoModel>())).Throws<InvalidInterestException>();
            Assert.Throws<InvalidInterestException>(() => manager.Object.CalculateLoanStatistics(loanInfoModel));
        }

        [Test]
        [TestCase(102)]
        public void CalculateLoanStatisticsThrowExceptionIfNotValidDownpayment(int downpayment)
        {
            var loanInfoModel = new LoanInfoModel(10, 5, downpayment, 10);
            var manager = new Mock<ILoanManager>();
            manager.Setup(x => x.CalculateLoanStatistics(It.IsAny<ILoanInfoModel>())).Throws<InvalidDownPaymentException>();
            Assert.Throws<InvalidDownPaymentException>(() => manager.Object.CalculateLoanStatistics(loanInfoModel));
        }

        [Test]
        [TestCase(-100)]
        public void CalculateLoanStatisticsThrowExceptionIfNotValidTerm(int term)
        {
            var loanInfoModel = new LoanInfoModel(10, 5, 5, term);
            var manager = new Mock<ILoanManager>();
            manager.Setup(x => x.CalculateLoanStatistics(It.IsAny<ILoanInfoModel>())).Throws<InvalidTermException>();
            Assert.Throws<InvalidTermException>(() => manager.Object.CalculateLoanStatistics(loanInfoModel));
        }
    }
}
