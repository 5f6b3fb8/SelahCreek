using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WildBillPnw.SelahCreek.Models;
using WildBillPnw.SelahCreek.Profiles;

namespace WildBillPnw.SelahCreek.Tests
{
    [TestClass]
    public class NetworkIncidentTests
    {
        private IMapper mapper;

        [TestInitialize]
        public void BeforeTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<NetworkIncidentProfile>();
                cfg.AllowNullDestinationValues = true;
            });

            config.CompileMappings();
            mapper = config.CreateMapper();
        }

        #region Number

        [TestMethod]
        public void TestNetworkInboundNumber()
        {
            var expected = new NetworkIncident { Number = "12345" };
            var actual = mapper.Map<Incident>(expected);
            Assert.AreEqual(expected.Number, actual.CorrelationId);
        }

        [TestMethod]
        public void TestNetworkReverseNumber()
        {
            var expected = new Incident { Number = "12345" };
            var actual = mapper.Map<NetworkIncident>(expected);
            Assert.AreEqual(expected.Number, actual.CorrelationId);
        }

        #endregion

        #region Description

        [TestMethod]
        public void TestNetworkInboundDescription()
        {
            var expected = new NetworkIncident { Description = "Test" };
            var actual = mapper.Map<Incident>(expected);
            Assert.AreEqual(expected.Description, actual.Description);
        }

        [TestMethod]
        public void TestNetworkReverseDescription()
        {
            var expected = new Incident { Description = "Test" };
            var actual = mapper.Map<NetworkIncident>(expected);
            Assert.AreEqual(expected.Description, actual.Description);
        }

        #endregion

        #region Short Description

        [TestMethod]
        public void TestNetworkInboundShortDescription()
        {
            var expected = new NetworkIncident { ShortDescription = "Test" };
            var actual = mapper.Map<Incident>(expected);
            Assert.AreEqual(expected.ShortDescription, actual.ShortDescription);
        }

        [TestMethod]
        public void TestNetworkReverseShortDescription()
        {
            var expected = new Incident { ShortDescription = "Test" };
            var actual = mapper.Map<NetworkIncident>(expected);
            Assert.AreEqual(expected.ShortDescription, actual.ShortDescription);
        }

        #endregion

        #region Priority

        [DataTestMethod]
        [DataRow(NetworkIncidentPriority.Critical, IncidentPriority.Critical)]
        [DataRow(NetworkIncidentPriority.High, IncidentPriority.High)]
        [DataRow(NetworkIncidentPriority.Medium, IncidentPriority.Medium)]
        [DataRow(NetworkIncidentPriority.Low, IncidentPriority.Low)]
        [DataRow(NetworkIncidentPriority.VeryLow, IncidentPriority.Low)] // Selah Creek does not have VeryLow
        public void TestNetworkInboundPriority(NetworkIncidentPriority input, IncidentPriority expected)
        {
            var actual = mapper.Map<Incident>(new NetworkIncident { Priority = input });
            Assert.AreEqual(expected, actual.Priority);
        }

        [DataTestMethod]
        [DataRow(IncidentPriority.Critical, NetworkIncidentPriority.Critical)]
        [DataRow(IncidentPriority.High, NetworkIncidentPriority.High)]
        [DataRow(IncidentPriority.Medium, NetworkIncidentPriority.Medium)]
        [DataRow(IncidentPriority.Low, NetworkIncidentPriority.Low)]
        public void TestNetworkReversePriority(IncidentPriority input, NetworkIncidentPriority expected)
        {
            var actual = mapper.Map<NetworkIncident>(new Incident { Priority = input });
            Assert.AreEqual(expected, actual.Priority);
        }

        #endregion

        #region State

        [DataTestMethod]
        [DataRow(NetworkIncidentState.Empty, IncidentState.New, IncidentHoldReason.Empty)]
        [DataRow(NetworkIncidentState.New, IncidentState.New, IncidentHoldReason.Empty)]
        [DataRow(NetworkIncidentState.WipConfiguring, IncidentState.InProgress, IncidentHoldReason.Empty)]
        [DataRow(NetworkIncidentState.WipInTransit, IncidentState.InProgress, IncidentHoldReason.Empty)]
        [DataRow(NetworkIncidentState.Resolved, IncidentState.Resolved, IncidentHoldReason.Empty)]
        [DataRow(NetworkIncidentState.Rejected, IncidentState.Canceled, IncidentHoldReason.Empty)]
        [DataRow(NetworkIncidentState.Closed, IncidentState.Closed, IncidentHoldReason.Empty)]
        [DataRow(NetworkIncidentState.WipAwaitingVendor, IncidentState.OnHold, IncidentHoldReason.AwaitingVendor)]
        [DataRow(NetworkIncidentState.WipAwaitingCaller, IncidentState.OnHold, IncidentHoldReason.AwaitingCaller)]
        public void TestNetworkInboundState(NetworkIncidentState input, IncidentState expectedState,
            IncidentHoldReason expectedHoldReason)
        {
            var actual = mapper.Map<Incident>(new NetworkIncident { State = input });
            Assert.AreEqual(expectedState, actual.State);
            Assert.AreEqual(expectedHoldReason, actual.HoldReason);
        }

        [DataTestMethod]
        [DataRow(IncidentState.New, IncidentHoldReason.Empty, NetworkIncidentState.New)]
        [DataRow(IncidentState.InProgress, IncidentHoldReason.Empty, NetworkIncidentState.WipConfiguring)]
        [DataRow(IncidentState.OnHold, IncidentHoldReason.AwaitingCaller, NetworkIncidentState.WipAwaitingCaller)]
        [DataRow(IncidentState.OnHold, IncidentHoldReason.AwaitingProblem, NetworkIncidentState.WipAwaitingCaller)]
        [DataRow(IncidentState.OnHold, IncidentHoldReason.AwaitingChange, NetworkIncidentState.WipAwaitingCaller)]
        [DataRow(IncidentState.OnHold, IncidentHoldReason.AwaitingVendor, NetworkIncidentState.WipAwaitingVendor)]
        [DataRow(IncidentState.Resolved, IncidentHoldReason.Empty, NetworkIncidentState.Resolved)]
        [DataRow(IncidentState.Canceled, IncidentHoldReason.Empty, NetworkIncidentState.Rejected)]
        [DataRow(IncidentState.Closed, IncidentHoldReason.Empty, NetworkIncidentState.Closed)]        
        public void TestNetworkReverseState(IncidentState inputState, IncidentHoldReason inputHoldReason,
            NetworkIncidentState expected)
        {
            var actual = mapper.Map<NetworkIncident>(new Incident { State = inputState, HoldReason = inputHoldReason });
            Assert.AreEqual(expected, actual.State);
        }

        #endregion
    }
}
