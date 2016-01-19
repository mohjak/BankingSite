using BankingSite.Models;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionalUITests.PageObjectModels
{
	class LoanApplicationPage : Page<LoanApplication>
	{
		public T SubmitApplication<T>(LoanApplication application) where T : UiComponent, new()
		{
			Input.Model(application);

			return Navigate.To<T>(By.Id("Apply"));
		}

	}
}
