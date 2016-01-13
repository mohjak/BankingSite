using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace BankingSite.ControllerTests
{
	[TestFixture]
    public class LoanApplicationControllerTests
    {
		[Test]
		public void ShouldRenderDefaultView()
		{
			var fakeRepository = new Mock<IRepository>();
			var fakeApplicationScorrer = new Mock<ILoanApplicationScorer>();

			var sut = new LoanApplicationController(fakeRepository.Object, fakeApplicationScorrer.Object);

			var result = sut.Apply() as ViewResult;

			Assert.That(result.ViewName, Is.EqualTo("Apply"));
		}
    }
}
