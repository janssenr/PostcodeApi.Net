using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PostcodeApi.Net.Helpers;
using PostcodeApi.Net.V2.Model;
using PostcodeApi.Net.V2.Wrappers;

namespace PostcodeApi.Net.V2
{
    public sealed class PostcodeApiClient : PostcodeApiClientBase
    {
        [Obsolete("The recommended alternative is PostcodeApi.Net.V3.PostcodeApiClient", false)]
        public PostcodeApiClient(string apiKey) : base(apiKey)
        {
            EndpointUrl = "https://api.postcodeapi.nu/v2/";
            HeaderKey = "X-Api-Key";
        }

        public ApiHalResultWrapper GetAddresses(string postcode = null, int? number = null, string from = null)
        {
            var headers = new WebHeaderCollection
            {
                {HeaderKey, ApiKey}
            };

            var parameters = new Dictionary<string, string>();
            if (postcode != null)
            {
                postcode = postcode.Replace(" ", string.Empty);
                if (FindPostcodeType(postcode) != Constants.PostcodeFormatTypes.P6)
                {
                    throw new ArgumentException("Postcode is not of the correct format " + Constants.PostcodeFormatTypes.P6);
                }
                parameters.Add("postcode", postcode);
            }

            if (number != null)
            {
                parameters.Add("number", number.ToString());
            }

            if (from != null)
            {
                parameters.Add("from", from);
            }

            var queryString = string.Join("&",
                parameters.Select(
                    p =>
                        string.IsNullOrEmpty(p.Value)
                            ? Uri.EscapeDataString(p.Key)
                            : string.Format("{0}={1}", Uri.EscapeDataString(p.Key),
                                Uri.EscapeDataString(p.Value))));
            var url = EndpointUrl + "addresses/?" + queryString;
            var response = DoRestCall(url, "GET", headers);
            return JsonHelper.Deserialize<ApiHalResultWrapper>(response);
        }

        /// <summary>
        /// Gets information about a single address.
        /// </summary>
        /// <param name="id">Identifier of the address. Equal to that of the governmental standard BAG.</param>
        /// <example>0268200000075156</example>
        public AddressView GetAddress(string id)
        {
            var headers = new WebHeaderCollection
            {
                {HeaderKey, ApiKey}
            };

            var url = EndpointUrl + "addresses/" + id + "/";
            var response = DoRestCall(url, "GET", headers);
            return JsonHelper.Deserialize<AddressView>(response);
        }

        public ApiHalResultWrapper GetPostcodes(string postcodeArea = null, string from = null)
        {
            var headers = new WebHeaderCollection
            {
                {HeaderKey, ApiKey}
            };

            var parameters = new Dictionary<string, string>();
            if (postcodeArea != null)
            {
                postcodeArea = postcodeArea.Replace(" ", string.Empty);
                if (FindPostcodeType(postcodeArea) != Constants.PostcodeFormatTypes.P4)
                {
                    throw new ArgumentException("Postcode is not of the correct format " + Constants.PostcodeFormatTypes.P4);
                }
                parameters.Add("postcodeArea", postcodeArea);
            }

            if (from != null)
            {
                parameters.Add("from", from);
            }

            var queryString = string.Join("&",
                parameters.Select(
                    p =>
                        string.IsNullOrEmpty(p.Value)
                            ? Uri.EscapeDataString(p.Key)
                            : string.Format("{0}={1}", Uri.EscapeDataString(p.Key),
                                Uri.EscapeDataString(p.Value))));
            var url = EndpointUrl + "postcodes/?" + queryString;
            var response = DoRestCall(url, "GET", headers);
            return JsonHelper.Deserialize<ApiHalResultWrapper>(response);
        }

        /// <summary>
        /// Gets information about a single postcode.
        /// </summary>
        /// <param name="postcode">Postcode in P6 format</param>
        /// <example>6545CA</example>
        public PostcodeView GetPostcode(string postcode)
        {
            if (FindPostcodeType(postcode) != Constants.PostcodeFormatTypes.P6)
            {
                throw new ArgumentException("Postcode is not of the correct format " + Constants.PostcodeFormatTypes.P6);
            }

            var headers = new WebHeaderCollection
            {
                {HeaderKey, ApiKey}
            };
            var url = EndpointUrl + "postcodes/" + postcode + "/";
            var response = DoRestCall(url, "GET", headers);
            return JsonHelper.Deserialize<PostcodeView>(response);
        }
    }
}
