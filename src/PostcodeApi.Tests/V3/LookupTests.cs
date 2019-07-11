using NUnit.Framework;
using PostcodeApi.Net.V3;
using PostcodeApi.Net.V3.Model;
using System.Configuration;

namespace PostcodeApi.Tests.V3
{
    [TestFixture]
    public class LookupTests
    {
        private PostcodeApiClient _client;

        [SetUp]
        public void Setup()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("V3ApiKey");
            _client = new PostcodeApiClient(Environment.SANDBOX, apiKey);
        }

        [Test]
        public void GetSpecificAddress()
        {
            var result = _client.Lookup("6545CA", 29);

            Assert.IsNotNull(result);
            Assert.AreEqual("6545CA", result.Postcode);
            Assert.AreEqual(29, result.Number);
            Assert.AreEqual("Waldeck Pyrmontsingel", result.Street);
            Assert.AreEqual("Nijmegen", result.City);
            Assert.AreEqual("Nijmegen", result.Municipality);
            Assert.AreEqual("Gelderland", result.Province);
        }
    }
}
