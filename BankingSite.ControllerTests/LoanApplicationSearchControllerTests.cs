using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
	[TestFixture]
	class LoanApplicationSearchControllerTests
	{
		[Test]
		public void ShouldReturn404StatusWhenLoanIdNotExists()
		{
			var fakeRepository = new Mock<IRepository>();

			var sut = new LoanApplicationSearchController(fakeRepository.Object);

			sut.WithCallTo(x => x.ApplicationStatus(99)).ShouldGiveHttpStatus(HttpStatusCode.NotFound);
		}

		[Test]
		public void ShouldRenderApplicationWhenIdExists()
		{
			var fakeRepository = new Mock<IRepository>();

			fakeRepository.Setup(x => x.Find(99))
				.Returns(new LoanApplication { FirstName = "Larry" });

			var sut = new LoanApplicationSearchController(fakeRepository.Object);

			sut.WithCallTo(x => x.ApplicationStatus(99))
				.ShouldRenderDefaultView()
				.WithModel<LoanApplication>(x => x.FirstName = "Larry");
		}
	}
}
