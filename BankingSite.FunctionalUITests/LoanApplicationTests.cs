using BankingSite.Controllers;
using BankingSite.FunctionalUITests.DemoHelperCode;
using BankingSite.FunctionalUITests.PageObjectModels;
using BankingSite.Models;
using NUnit.Framework;
using TestStack.Seleno.PageObjects.Locators;

namespace BankingSite.FunctionalUITests
{
	[TestFixture]
	public class LoanApplicationTests
	{
		[Test]
		public void ShouldAcceptLoanApplication()
		{
			var applyPage =
				 BrowserHost.Instance.NavigateToInitialPage<LoanApplicationController, LoanApplicationPage>(
					  x => x.Apply());

			var applicationDetails = new LoanApplication
			{
				FirstName = "Gentry",
				LastName = "Smith",
				Age = 42,
				AnnualIncome = 999999999
			};

			var acceptPage = applyPage.SubmitApplication<AcceptedPage>(applicationDetails);

			var acceptMessageText = acceptPage.AcceptedMessage;

			Assert.That(acceptMessageText, Is.EqualTo("Congratulations Gentry - Your application was accepted!"));

			DemoHelper.Wait(5000);
		}


		[Test]
		public void ShouldDeclineLoanApplication()
		{
			var applyPage =
				 BrowserHost.Instance.NavigateToInitialPage<LoanApplicationController, LoanApplicationPage>(
					  x => x.Apply());

			var applicationDetails = new LoanApplication
			{
				FirstName = "Gentry",
				LastName = "Smith",
				Age = 16,
				AnnualIncome = 20000
			};

			var declinePage = applyPage.SubmitApplication<DeclinedPage>(applicationDetails);

			Assert.That(declinePage.DeclinedMessage, Is.EqualTo("Sorry Gentry - We are unable to offer you a loan at this time."));

			DemoHelper.Wait(5000);
		}

	}
}
