using System.Configuration;
using NUnit.Framework;
using PostcodeApi.Net.V1;
using PostcodeApi.Net.V1.Wrappers;

namespace PostcodeApi.Tests.V1
{
    [TestFixture]
    [Ignore("V1 has been officially deprecated as of 2016-03-01")]
    public class AddressTests
    {
        private PostcodeApiClient _client;

        [SetUp]
        public void SetUp()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("ApiKey");
            _client = new PostcodeApiClient(apiKey);
        }

        [Test]
        public void GetSingleAddress()
        {
            ApiResultWrapper address = _client.GetAddress("6545CA", 29);

            Assert.IsNotNull(address);
            Assert.IsNotNull(address.Resource);
            Assert.IsNotNull(address.Resource.Bag);
        }

        [Test]
        public void GetAddressByFullPostcode()
        {
            ApiResultWrapper result = _client.GetAddress("6545CA");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Resource);
            Assert.AreEqual(0, result.Resource.HouseNumber);
            Assert.IsNull(result.Resource.Bag);
        }

        [Test]
        public void GetAddressByPostcodeNumbers()
        {
            ApiResultWrapper result = _client.GetAddress("6545");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Resource);
            Assert.IsNull(result.Resource.Street);
            Assert.AreEqual(0, result.Resource.HouseNumber);
            Assert.IsNull(result.Resource.Postcode);
            Assert.IsNull(result.Resource.Bag);
        }
    }
}
