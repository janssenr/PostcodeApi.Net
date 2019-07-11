using System.Runtime.Serialization;

namespace PostcodeApi.Net.V3.Model
{
    [DataContract]
    public class AddressView
    {
        /// <summary>
        /// Post code in the P6 format
        /// </summary>
        [DataMember(Name = "postcode", EmitDefaultValue = false)]
        public string Postcode { get; set; }

        [DataMember(Name = "number", EmitDefaultValue = false)]
        public int Number { get; set; }

        [DataMember(Name = "street", EmitDefaultValue = false)]
        public string Street { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "municipality", EmitDefaultValue = false)]
        public string Municipality { get; set; }

        [DataMember(Name = "province", EmitDefaultValue = false)]
        public string Province { get; set; }
    }
}
