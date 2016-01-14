
using BankingSite.Models;
using HtmlAgilityPack;
using NUnit.Framework;
using RazorGenerator.Testing;

namespace BankingSite.ViewTests
{
	[TestFixture]
	public class LoanApplicationSearchApplicationSatusViewTests
	{
		[Test]
		public void ShouldRenderAcceptedMessage()
		{
			var sut = new Views.LoanApplicationSearch.ApplicationStatus();

			var model = new LoanApplication
			{
				IsAccepted = true
			};

			HtmlDocument html = sut.RenderAsHtml(model);

			var isAcceptedMessageRendered = html.GetElementbyId("acceptedMessage") != null;
			var isDeclinedMessageRendered = html.GetElementbyId("declinedMessage") != null;

			Assert.That(isAcceptedMessageRendered, Is.True);
			Assert.That(isDeclinedMessageRendered, Is.False);


		}

	}
}
