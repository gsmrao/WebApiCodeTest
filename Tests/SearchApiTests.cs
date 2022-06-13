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
            HttpResponseMessage response = await aPIServiceCall.SearchData("com", "en", "GBP", "0", "10","");

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

            HttpResponseMessage response = await aPIServiceCall.SearchData("com", "en", "GBP", "0", "10", "Nike caps");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        
    }
}