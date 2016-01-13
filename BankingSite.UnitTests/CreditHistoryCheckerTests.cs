using BankingSite.Models;
using NUnit.Framework;

namespace BankingSite.UnitTests
{
	[TestFixture]
	public class CreditHistoryCheckerTests
	{
		[Test]
		public void ShouldRecognizePeopleWithBadCredit()
		{
			var sut = new CreditHistoryChecker();

			var isCreditWorthy = sut.CheckCreditHistory("Sarah", "Smith");

			Assert.That(isCreditWorthy, Is.False);
		}

		[Test]
		public void ShouldOkPeopleWithGoodCredit()
		{
			var sut = new CreditHistoryChecker();

			var isCreditWorthy = sut.CheckCreditHistory("Gentry", "Smith");

			Assert.That(isCreditWorthy, Is.True);
		}

	}
}
