using BankingSite.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
	[TestFixture]
	public class HomeControllerTests
	{
		[Test]
		public void ShouldRedirectToPluralSightForContact()
		{
			var sut = new HomeController();

			sut.WithCallTo(x => x.Contact()).ShouldRedirectTo("http://pluralsight.com");
		}
	}
}
