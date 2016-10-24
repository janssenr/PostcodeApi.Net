using System.Collections.Generic;
using System.Runtime.Serialization;
using PostcodeApi.Net.V2.Model;

namespace PostcodeApi.Net.V2.Wrappers
{
    [DataContract]
    public sealed class HalEmbeddedResult
    {
        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<AddressView> Addresses { get; set; }

        [DataMember(Name = "postcodes", EmitDefaultValue = false)]
        public List<PostcodeView> Postcodes { get; set; }
    }
}
