using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WildBillPnw.SelahCreek.Api;
using WildBillPnw.SelahCreek.Models;

namespace WildBillPnw.SelahCreek.Tests
{
    [TestClass]
    public class ApiTests
    {
        private TestServer server;
        private HttpClient client;

        [TestInitialize]
        public void TestInitialize()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [TestMethod]
        public async Task TestNetworkIncidentStatusCheck()
        {
            var response = await client.GetAsync("/NetworkIncident");
            response.EnsureSuccessStatusCode();

            var actual = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("ok.", actual);
        }

        [TestMethod]
        public async Task TestNetworkIncidentInbound()
        {
            var networkIncident = new NetworkIncident
            {
                Number = "INC12345",
                ShortDescription = "Network Incident",
                Description = "Test Network Incident",
                Priority = NetworkIncidentPriority.High,
                State = NetworkIncidentState.New
            };

            var json = JsonSerializer.Serialize(networkIncident);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("/NetworkIncident", payload);
            response.EnsureSuccessStatusCode();

            var actual = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("ok.", actual);
        }
    }
}