using System;
using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class AddressNen5825
    {
        [DataMember(Name = "street", EmitDefaultValue = false)]
        public string Street { get; set; }

        [DataMember(Name = "postcode", EmitDefaultValue = false)]
        public string Postcode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", Street, Environment.NewLine, Postcode);
        }
    }
}
