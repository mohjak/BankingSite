using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionalUITests.PageObjectModels
{
	class LoanApplicationPage : Page
	{
		public LoanApplicationPage EnterFirstName(string firstName)
		{
			Find.Element(By.Id("FirstName")).SendKeys(firstName);

			return this;
		}

		public LoanApplicationPage EnterLastName(string lastName)
		{
			Find.Element(By.Id("LastName")).SendKeys(lastName);

			return this;
		}

		public LoanApplicationPage EnterAge(string age)
		{
			Find.Element(By.Id("Age")).SendKeys(age);

			return this;
		}

		public LoanApplicationPage EnterAnnualIncome(string income)
		{
			Find.Element(By.Id("AnnualIncome")).SendKeys(income);

			return this;
		}

		public T SubmitApplication<T>() where T : UiComponent, new()
		{
			return Navigate.To<T>(By.Id("Apply"));
		}

	}
}
