using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionalUITests.PageObjectModel
{
	class AcceptedPage : Page
	{
		public string AcceptedMessage
		{ get
			{
				return Find.Element(By.Id("acceptMessage")).Text;
			}
		}
	}
}