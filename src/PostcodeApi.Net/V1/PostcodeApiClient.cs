using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PostcodeApi.Net.Helpers;
using PostcodeApi.Net.V1.Wrappers;

namespace PostcodeApi.Net.V1
{
    public class PostcodeApiClient : PostcodeApiClientBase
    {
        [Obsolete("The recommended alternative is PostcodeApi.Net.V3.PostcodeApiClient", false)]
        public PostcodeApiClient(string apiKey) : base(apiKey)
        {
            EndpointUrl = "http://api.postcodeapi.nu/";
            HeaderKey = "Api-Key";
        }

        public ApiResultWrapper GetAddress(string postcode)
        {
            postcode = postcode.Replace(" ", string.Empty);

            var headers = new WebHeaderCollection
            {
                {HeaderKey, ApiKey}
            };
            var parameters = new Dictionary<string, string>
            {
                {"type", FindPostcodeType(postcode)}
            };

            var queryString = string.Join("&",
                parameters.Select(
                    p =>
                        string.IsNullOrEmpty(p.Value)
                            ? Uri.EscapeDataString(p.Key)
                            : string.Format("{0}={1}", Uri.EscapeDataString(p.Key),
                                Uri.EscapeDataString(p.Value))));
            var url = EndpointUrl + postcode + "/?" + queryString;
            var response = DoRestCall(url, "GET", headers);
            return JsonHelper.Deserialize<ApiResultWrapper>(response);
        }

        public ApiResultWrapper GetAddress(string postcode, int number)
        {
            postcode = postcode.Replace(" ", string.Empty);

            var headers = new WebHeaderCollection
            {
                {HeaderKey, ApiKey}
            };
            var parameters = new Dictionary<string, string>
            {
                {"view", "bag"}
            };

            var queryString = string.Join("&",
                parameters.Select(
                    p =>
                        string.IsNullOrEmpty(p.Value)
                            ? Uri.EscapeDataString(p.Key)
                            : string.Format("{0}={1}", Uri.EscapeDataString(p.Key),
                                Uri.EscapeDataString(p.Value))));
            var url = EndpointUrl + postcode + "/" + number + "/?" + queryString;
            var response = DoRestCall(url, "GET", headers);
            return JsonHelper.Deserialize<ApiResultWrapper>(response);
        }
    }
}
