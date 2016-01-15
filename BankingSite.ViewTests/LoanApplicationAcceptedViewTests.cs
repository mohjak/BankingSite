using BankingSite.Models;
using HtmlAgilityPack;
using NUnit.Framework;
using RazorGenerator.Testing;

namespace BankingSite.ViewTests
{
	[TestFixture]
	public class LoanApplicationAcceptedViewTests
	{
		[Test]
		public void ShouldRenderCorrectApplicationDetails()
		{
			var sut = new Views.LoanApplication.Accepted();

			var model = new LoanApplication
			{
				ID = 99,
				Age = 33,
				FirstName = "Gentry",
				LastName = "Smith",
				AnnualIncome = 12345.67m
			};

			HtmlDocument html = sut.RenderAsHtml(model);

			var renderedFirstName = html.GetElementbyId("firstName").InnerText;

			Assert.That(renderedFirstName,Is.EqualTo("Gentry"));
		}
	}
}
