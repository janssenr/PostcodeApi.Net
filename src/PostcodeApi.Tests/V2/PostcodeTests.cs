using System.Configuration;
using NUnit.Framework;
using PostcodeApi.Net.V2;
using PostcodeApi.Net.V2.Model;
using PostcodeApi.Net.V2.Wrappers;

namespace PostcodeApi.Tests.V2
{
    [TestFixture()]
    public class PostcodeTests
    {
        private PostcodeApiClient _client;

        [SetUp]
        public void Setup()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("V2ApiKey");
            _client = new PostcodeApiClient(apiKey);
        }

        [Test]
        public void GetSinglePostcode()
        {
            PostcodeView result = _client.GetPostcode("6545CA");

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetSpecificPostcode()
        {
            ApiHalResultWrapper result = _client.GetPostcodes("6545");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.AreEqual(20, result.Embedded.Postcodes.Count);
            Assert.AreEqual("Westkanaaldijk", result.Embedded.Postcodes[0].Streets[0]);
            Assert.AreEqual("Nijmegen", result.Embedded.Postcodes[0].City.Label);
        }

        [Test]
        public void GetPostcodeRange()
        {
            ApiHalResultWrapper result = _client.GetPostcodes("6545");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.IsNotNull(result.Links.Next);
            Assert.IsTrue(result.Embedded.Postcodes.Count > 1);
            Assert.AreEqual("Westkanaaldijk", result.Embedded.Postcodes[0].Streets[0]);
            Assert.AreEqual("Nijmegen", result.Embedded.Postcodes[0].City.Label);
        }

        [Test]
        public void GetLargePostcodeRange()
        {
            ApiHalResultWrapper result = _client.GetPostcodes("6545");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.IsNotNull(result.Links.Next);
            Assert.IsTrue(result.Embedded.Postcodes.Count == 20);
            Assert.AreEqual("Westkanaaldijk", result.Embedded.Postcodes[0].Streets[0]);
            Assert.AreEqual("Nijmegen", result.Embedded.Postcodes[0].City.Label);
        }
    }
}
