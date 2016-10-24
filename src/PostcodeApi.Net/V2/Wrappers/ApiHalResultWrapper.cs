using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Wrappers
{
    [DataContract]
    public class ApiHalResultWrapper
    {
        [DataMember(Name = "_embedded", EmitDefaultValue = false)]
        public HalEmbeddedResult Embedded { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public HalNavigator Links { get; set; }
    }
}
