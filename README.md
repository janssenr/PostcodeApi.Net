# PostcodeAPI.Net
PostcodeAPI.Net is a ASP.Net client library for the PostcodeAPI.nu web service.

**Links:**

* [More information](https://www.postcodeapi.nu)
* [API documentation](https://swaggerhub.com/api/apiwise/postcode-api)

Requirements
------------

PostcodeAPI.Net works with ASP.Net 4.5.1 or up.

Installation
------------

PostcodeAPI.Net can easily be installed using the NuGet package

	Install-Package PostcodeApi

Usage
-----

Instantiate the client and replace the API key with your personal credentials:

```
var apiKey = "replace_with_your_own_api_key";
var client = new PostcodeApiClient(apiKey);

var result = client.GetAddresses("6545CA", 29);
result = client.GetAddress("0268200000075156");
```
