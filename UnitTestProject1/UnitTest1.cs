using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ODataTest;
using ODataTest.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Linq;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests companies and child addresses
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestMethod1()
        {
            var provider = new ApiTestProvider<OWinStartup>("");
            {
                var req = provider.GetRequest("/odata/Companies?$top=5&$expand=Addresses");
                var response = await req.GetAsync();
                Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK, await response.Content.ReadAsStringAsync());
                var companies = await response.Content.ReadAsAsync<ODataResponse<Company>>();
                Assert.IsTrue(companies.value.Any(), "No data was returned");
            }
        }
        public static JsonMediaTypeFormatter JsonODataSerializerSettings()
        {
            var restval =
               new JsonMediaTypeFormatter()
               {

                   SerializerSettings = new JsonSerializerSettings()
                   {
                       NullValueHandling = NullValueHandling.Ignore,
                       DefaultValueHandling = DefaultValueHandling.Ignore
                   }
               };
            restval.SerializerSettings.ContractResolver = new NullToEmptyListResolver();
            return restval;

        }
        //CANNOT APPLY PATCH TO NAVIGATION PROPERTY. This is wrong, and should work
        [TestMethod]
        public async Task PatchMustSucceed()
        {
            var guid = "C26F0FE8-98BC-41F0-8957-78270AB2C545";
            var guidNewAddress = "EBCF57A5-DF14-4087-B2E6-2A1FD33550A7";
            var company = new Company() { Addresses = new[] { new Address { Id = Guid.Parse(guidNewAddress), Street = "Station", StreetSuffix = "123", ZipCode = "asdfasdf" } } };
            var provider = new ApiTestProvider<OWinStartup>("");
            {
                var req = provider.GetRequest($"/odata/Companies({guid})");
                req.And((c) => c.Content = new ObjectContent<Company>(company, JsonODataSerializerSettings(), "application/json"));
                var response = await req.SendAsync("PATCH");

                Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent, await response.Content.ReadAsStringAsync());                
            }
        }

    }
}
