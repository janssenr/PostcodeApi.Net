# PostcodeApi.Net
=================

[![Build Status](https://travis-ci.org/janssenr/PostcodeApi.Net.svg?branch=master)](https://travis-ci.org/janssenr/PostcodeApi.Net)

PostcodeApi.Net is a ASP.Net client library for the PostcodeAPI.nu web service.

**Links:**

* [More information](https://www.postcodeapi.nu)
* [API documentation](https://www.postcodeapi.nu/docs/v3/)

Requirements
------------

PostcodeApi.Net works with ASP.Net 4.5.1 or up.

Installation
------------

PostcodeApi.Net can easily be installed using the NuGet package

	Install-Package PostcodeApi

Usage
-----

Instantiate the client and replace the API key with your personal credentials:

```
var apiKey = "replace_with_your_own_api_key";
var client = new PostcodeApiClient(Environment.SANDBOX, apiKey);

var result = client.Lookup("6545CA", 29);
```
