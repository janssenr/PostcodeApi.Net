using PostcodeApi.Net.Helpers;
using PostcodeApi.Net.V3.Helpers;
using PostcodeApi.Net.V3.Model;
using System;
using System.Net;
using Environment = PostcodeApi.Net.V3.Model.Environment;

namespace PostcodeApi.Net.V3
{
    public class PostcodeApiClient : PostcodeApiClientBase
    {
        public PostcodeApiClient(Environment environment, string apiKey) : base(apiKey)
        {
            EndpointUrl = EnvironmentHelper.GetUrl(environment);
            HeaderKey = "X-Api-Key";
        }

        public AddressView Lookup(string postcode, int number)
        {
            var headers = new WebHeaderCollection
            {
                {HeaderKey, ApiKey}
            };

            if (postcode != null)
            {
                postcode = postcode.Replace(" ", string.Empty);
                if (FindPostcodeType(postcode) != Constants.PostcodeFormatTypes.P6)
                {
                    throw new ArgumentException("Postcode is not of the correct format " + Constants.PostcodeFormatTypes.P6);
                }
            }

            var url = EndpointUrl + $"/lookup/{postcode}/{number}";
            var response = DoRestCall(url, "GET", headers);
            return JsonHelper.Deserialize<AddressView>(response);
        }
    }
}
