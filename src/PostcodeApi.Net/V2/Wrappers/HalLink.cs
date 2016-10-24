using System;
using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Wrappers
{
    [DataContract]
    public class HalLink
    {
        [DataMember(Name = "href", EmitDefaultValue = false)]
        public Uri Href { get; set; }

        public override string ToString()
        {
            return Href.ToString();
        }
    }
}
