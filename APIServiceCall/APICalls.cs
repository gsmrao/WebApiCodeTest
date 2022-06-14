using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Configuration;

using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace WebApiCodeTest.APIServiceCall
{
    public class APIServiceCalls
    {
        public async Task<HttpResponseMessage> SearchData(string strStore,string strLang,
            string strCurrency, string strOffSet,string strLimit, string strInputData, bool blnSpellcheck)
        {

            const string searchV2Url = "https://api.asos.com/product/search/v2/";
            const string accept = "application/json";
            const string encoding = "identity";
            const string keepAlive = "keep-alive";

            UriBuilder builder = null;

            if (blnSpellcheck == false)
            {
                builder = new UriBuilder(searchV2Url)
                {
                    Query = $"store={strStore}&lang={strLang}&currency={strCurrency}&offset={strOffSet}&limit={strLimit}&q={strInputData}"
                };
            }
            else if (blnSpellcheck == true)
            {
                builder = new UriBuilder(searchV2Url)
                {
                    Query = $"Spellcheck={blnSpellcheck}&store={strStore}&lang={strLang}&currency={strCurrency}&offset={strOffSet}&limit={strLimit}&q={strInputData}"
                };
            }



            var request = new HttpRequestMessage(HttpMethod.Get, builder.Uri);
            request.Headers.Add("Accept", accept);
            request.Headers.Add("Accept-Encoding", encoding);
            request.Headers.Add("Connection", keepAlive);
            request.Headers.Add("User-Agent", Assembly.GetExecutingAssembly().GetName().Name);
            request.Headers.Add("asos-c-name", "qa-code-test");

            // Act
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            return response;
        }

    }

}
