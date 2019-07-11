using PostcodeApi.Net.V3.Model;

namespace PostcodeApi.Net.V3.Helpers
{
    public abstract class EnvironmentHelper
    {
        public static string GetUrl(Environment environment)
        {
            if (environment == Environment.PRODUCTION)
                return "https://api.postcodeapi.nu/v3";
            if (environment == Environment.SANDBOX)
                return "https://sandbox.postcodeapi.nu/v3";
            return null;
        }
    }
}
