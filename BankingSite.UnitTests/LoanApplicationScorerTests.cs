using BankingSite.Models;
using Moq;
using NUnit.Framework;

namespace BankingSite.UnitTests
{
	[TestFixture]
	public class LoanApplicationScorerTests
	{
		// Here the test uses a fake CreditHistoryChecker collaborator
		
		[Test]
		public void ShouldDeclineWhenTooYoung()
		{
			var fakeCreditHistoryChecker = new Mock<ICreditHistoryChecker>();

			fakeCreditHistoryChecker.Setup(
				 x => x.CheckCreditHistory(It.IsAny<string>(), It.IsAny<string>()))
				 .Returns(true);

			var sut = new LoanApplicationScorer(fakeCreditHistoryChecker.Object);

			var application = new LoanApplication
			{
				Age = 21
			};

			sut.ScoreApplication(application);

			Assert.That(application.IsAccepted, Is.False);
		}


		[Test]
		public void ShouldAcceptWhenYoungButWealthy()
		{
			var fakeCreditHistoryChecker = new Mock<ICreditHistoryChecker>();

			fakeCreditHistoryChecker.Setup(
				 x => x.CheckCreditHistory(It.IsAny<string>(), It.IsAny<string>()))
				 .Returns(true);

			var sut = new LoanApplicationScorer(fakeCreditHistoryChecker.Object);

			var application = new LoanApplication
			{
				AnnualIncome = 1000000.01m,
				Age = 21
			};

			sut.ScoreApplication(application);

			Assert.That(application.IsAccepted, Is.True);
		}


		[Test]
		public void ShouldDeclineWhenNotTooYoungAndWealthyButPoorCredit()
		{
			var fakeCreditHistoryChecker = new Mock<ICreditHistoryChecker>();

			fakeCreditHistoryChecker.Setup(
				 x => x.CheckCreditHistory(It.IsAny<string>(), It.IsAny<string>()))
				 .Returns(false);

			var sut = new LoanApplicationScorer(fakeCreditHistoryChecker.Object);

			var application = new LoanApplication
			{
				AnnualIncome = 1000000.01m,
				Age = 22
			};

			sut.ScoreApplication(application);

			Assert.That(application.IsAccepted, Is.False);
		}



	}
}
