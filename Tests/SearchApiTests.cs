using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;
using WebApiCodeTest.APIServiceCall;

namespace WebApiCodeTest.Tests
{
    [TestFixture]
    public class SearchApiTests
    {
        APIServiceCalls aPIServiceCall = new APIServiceCalls();
        [Test]
        public async Task GivenASearchRequestWithMissingSearchTerm_WhenTheRequestIsSent_ThenTheResponseShouldBeBadRequest()
        {
            HttpResponseMessage response = await aPIServiceCall.SearchData("com", "en", "GBP", "0", "10","", false);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task Valid_Search_Term()
        {
            // Given a valid search term
            // When the request is sent
            // Then response will code will be 200

            // Arrange

            HttpResponseMessage response = await aPIServiceCall.SearchData("com", "en", "GBP", "0", "10", "Nike caps",false);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task Valid_Search_Term_SpellCheck()
        {
            HttpResponseMessage response = await aPIServiceCall.SearchData("com", "en", "GBP", "0", "10", "Nkie caps", true);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}
