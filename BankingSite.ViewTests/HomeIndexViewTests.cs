using BankingSite.Models;
using HtmlAgilityPack;
using NUnit.Framework;
using RazorGenerator.Testing;

namespace BankingSite.ViewTests   
{
	[TestFixture]
	public class HomeIndexViewTests
	{
		[Test]
		public void ShouldRenderLoanInterestRate()
		{
			var sut = new Views.Home.Index();

			var model = new InterestRates
			{
				LoanRate = 23.45m
			};

			HtmlDocument html = sut.RenderAsHtml(model);

			var renderedLoanRate = html.GetElementbyId("loanRate").InnerText;

			Assert.That(renderedLoanRate, Is.EqualTo("23.45"));
		}

		[Test]
		public void ShouldRenderMainMessage()
		{
			var sut = new Views.Home.Index();

			sut.ViewBag.Message = "hello world";

			HtmlDocument html = sut.RenderAsHtml(new InterestRates());

			var actualMessage = html.GetElementbyId("mainMessage").InnerText;

			Assert.That(actualMessage, Is.EqualTo("hello world"));

		}

	}
}