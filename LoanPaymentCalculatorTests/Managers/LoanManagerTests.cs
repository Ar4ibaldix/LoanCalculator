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
    }
}
