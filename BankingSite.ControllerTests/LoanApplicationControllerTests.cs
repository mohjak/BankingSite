using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

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

			sut.WithCallTo(x => x.Apply()).ShouldRenderDefaultView();
		}

		[Test]
		public void ShouldRdirectToAcceptedViewOnSuccessfulApplication()
		{
			var fakeRepository = new Mock<IRepository>();
			var fakeApplicationScorrer = new Mock<ILoanApplicationScorer>();

			var sut = new LoanApplicationController(fakeRepository.Object, fakeApplicationScorrer.Object);

			var acceptedApplication = new LoanApplication
			{
				IsAccepted = true
			};

			sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Accepted);
		}

		[Test]
		public void ShouldRdirectToAcceptedViewOnUnSuccessfulApplication()
		{
			var fakeRepository = new Mock<IRepository>();
			var fakeApplicationScorrer = new Mock<ILoanApplicationScorer>();

			var sut = new LoanApplicationController(fakeRepository.Object, fakeApplicationScorrer.Object);

			var acceptedApplication = new LoanApplication
			{
				IsAccepted = false
			};

			sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Declined);
		}
	}
}
