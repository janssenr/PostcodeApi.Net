using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Wrappers
{
    [DataContract]
    public class HalNavigator
    {
        [DataMember(Name = "self", EmitDefaultValue = false)]
        public HalLink Self { get; set; }

        [DataMember(Name = "next", EmitDefaultValue = false)]
        public HalLink Next { get; set; }
    }
}
