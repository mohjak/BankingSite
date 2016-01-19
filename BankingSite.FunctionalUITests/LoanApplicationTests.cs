using BankingSite.Controllers;
using BankingSite.FunctionalUITests.DemoHelperCode;
using BankingSite.FunctionalUITests.PageObjectModel;
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
			var applyPage = BrowserHost.Instance.NavigateToInitialPage<LoanApplicationController, LoanApplicationPage>(x => x.Apply());

			var acceptPage = applyPage.EnterFirstName("Gentry")
				.EnterLastName("Smith")
				.EnterAge("42")
				.EnterAnnualIncome("99999999")
				.SubmitApplication<AcceptedPage>();
			
			DemoHelper.Wait();

			// Should now be on application accepted page

			DemoHelper.Wait(5000);

			var acceptMessageText = acceptPage.AcceptedMessage;

			Assert.That(acceptMessageText, Is.EqualTo("Congratulations Gentry - Your application was accepted!"));

			DemoHelper.Wait(5000);
		}


		[Test]
		public void ShouldDeclineLoanApplication()
		{
			BrowserHost.Instance.Application.Browser
				 .Navigate()
				 .GoToUrl(BrowserHost.RootUrl + @"LoanApplication\Apply");

			var firstNameBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("FirstName"));
			firstNameBox.SendKeys("Gentry");

			var lastNameBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("LastName"));
			lastNameBox.SendKeys("Smith");

			var ageBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("Age"));
			ageBox.SendKeys("16");

			var incomeBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("AnnualIncome"));
			incomeBox.SendKeys("20000");

			DemoHelper.Wait();

			var applyButton = BrowserHost.Instance.Application.Browser.FindElement(By.Id("Apply"));
			applyButton.Click();

			// Should now be on application accepted page

			DemoHelper.Wait(5000);

			var declineMessageText = BrowserHost.Instance.Application.Browser.FindElement(By.Id("declineMessage"));

			Assert.That(declineMessageText.Text, Is.EqualTo("Sorry Gentry - We are unable to offer you a loan at this time."));

			DemoHelper.Wait(5000);
		}

	}
}
