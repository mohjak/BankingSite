using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionalUITests.PageObjectModel
{
	class DeclinePage : Page
	{
		public string DeclineMessage
		{
			get
			{
				return Find.Element(By.Id("declineMessage")).Text;
			}
		}
	}
}