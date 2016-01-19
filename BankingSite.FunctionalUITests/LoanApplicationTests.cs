using BankingSite.Controllers;
using BankingSite.FunctionalUITests.DemoHelperCode;
using BankingSite.FunctionalUITests.PageObjectModels;
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

            var acceptPage = applyPage.EnterFirstName("Gentry")
                .EnterLastName("Smith")
                .EnterAge("42")
                .EnterAnnualIncome("99999999")
                .SubmitApplication<AcceptedPage>();

            // Should now be on application accepted page

            DemoHelper.Wait(5000);

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

            var declinePage = applyPage.EnterFirstName("Gentry")
                .EnterLastName("Smith")
                .EnterAge("16")
                .EnterAnnualIncome("20000")
                .SubmitApplication<DeclinedPage>();

            Assert.That(declinePage.DeclinedMessage, Is.EqualTo("Sorry Gentry - We are unable to offer you a loan at this time."));
            
            DemoHelper.Wait(5000);
        }

    }
}
