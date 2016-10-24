using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using PostcodeApi.Net.Helpers;

namespace PostcodeApi.Net
{
    public abstract class PostcodeApiClientBase
    {
        public string EndpointUrl { get; set; }
        public string HeaderKey { get; set; }
        public string ApiKey { get; set; }

        protected PostcodeApiClientBase(string apiKey)
        {
            ApiKey = apiKey;
        }

        protected string DoRestCall(string url, string method, WebHeaderCollection headers = null, string contentType = null, byte[] data = null)
        {
            var req = WebRequest.Create(url);
            req.Method = method;
            if (headers != null)
            {
                foreach (var key in headers.AllKeys)
                {
                    req.Headers.Add(key, headers[key]);
                }
            }
            if (method.ToUpper() != "GET" && data != null)
            {
                req.ContentType = contentType;
                req.ContentLength = data.Length;
                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            string responseValue = string.Empty;
            try
            {
                using (var response = (HttpWebResponse)req.GetResponse())
                {
                    //_responseHeaders = response.Headers;
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                                reader.Close();
                            }
                            responseStream.Close();
                        }
                    }
                    response.Close();
                }
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                //_responseHeaders = response.Headers;
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                            reader.Close();
                        }
                        responseStream.Close();
                    }
                }
                response.Close();
                var exception = JsonHelper.Deserialize<CouldNotParseResponseException>(responseValue);

                switch ((int)response.StatusCode)
                {
                    case (int)HttpStatusCode.BadRequest: //400
                    case (int)HttpStatusCode.Unauthorized: //401
                    case (int)HttpStatusCode.Forbidden: //403
                    case (int)HttpStatusCode.NotFound: //404
                    case (int)HttpStatusCode.UnsupportedMediaType: //415
                    case (int)HttpStatusCode.InternalServerError: //500
                        throw new Exception(exception.Message);
                    default:
                        throw new Exception(exception.Message);
                }
            }
            return responseValue;
        }

        /// <summary>
        /// Returns the P4, P5 or P6 format detected by the input.
        /// </summary>
        public string FindPostcodeType(string postcode)
        {
            if (Regex.IsMatch(postcode, @"^[0-9]{4}[a-zA-Z]{2}$")) return Constants.PostcodeFormatTypes.P6;

            if (Regex.IsMatch(postcode, @"^[0-9]{4}[a-zA-Z]{1}$")) return Constants.PostcodeFormatTypes.P5;

            if (Regex.IsMatch(postcode, @"^[0-9]{4}$")) return Constants.PostcodeFormatTypes.P4;

            return string.Empty;
        }
    }
}
