using PostcodeApi.Net.V1.Model;

namespace PostcodeApi.Net.V1.Wrappers
{
    public class ApiResultWrapper
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
        public Resource Resource { get; set; }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
