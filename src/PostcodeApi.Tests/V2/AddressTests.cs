using System.Configuration;
using NUnit.Framework;
using PostcodeApi.Net.V2;
using PostcodeApi.Net.V2.Model;
using PostcodeApi.Net.V2.Wrappers;

namespace PostcodeApi.Tests.V2
{
    [TestFixture]
    public class AddressTests
    {
        private PostcodeApiClient _client;

        [SetUp]
        public void Setup()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("V2ApiKey");
            _client = new PostcodeApiClient(apiKey);
        }

        [Test]
        public void GetSingleAddress()
        {
            AddressView result = _client.GetAddress("0268200000075156");

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetSpecificAddress()
        {
            ApiHalResultWrapper result = _client.GetAddresses("6545CA", 29);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.AreEqual(20, result.Embedded.Addresses.Count);
            Assert.AreEqual("Binderskampweg", result.Embedded.Addresses[0].Street);
            Assert.AreEqual("Nijmegen", result.Embedded.Addresses[0].City.Label);
        }

        [Test]
        public void GetAddressRange()
        {
            ApiHalResultWrapper result = _client.GetAddresses("6545CA");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.IsNotNull(result.Links.Next);
            Assert.IsTrue(result.Embedded.Addresses.Count > 1);
            Assert.AreEqual("Binderskampweg", result.Embedded.Addresses[0].Street);
            Assert.AreEqual("Nijmegen", result.Embedded.Addresses[0].City.Label);
        }

        [Test]
        public void GetLargeAddressRange()
        {
            ApiHalResultWrapper result = _client.GetAddresses("6545CA");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.IsNotNull(result.Links.Next);
            Assert.IsTrue(result.Embedded.Addresses.Count == 20);
            Assert.AreEqual("Binderskampweg", result.Embedded.Addresses[0].Street);
            Assert.AreEqual("Nijmegen", result.Embedded.Addresses[0].City.Label);

        }
    }
}
