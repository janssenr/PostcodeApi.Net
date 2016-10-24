using System.Runtime.Serialization;
using PostcodeApi.Net.V2.Wrappers;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class AddressView
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "street", EmitDefaultValue = false)]
        public string Street { get; set; }

        [DataMember(Name = "number", EmitDefaultValue = false)]
        public int Number { get; set; }

        [DataMember(Name = "letter", EmitDefaultValue = false)]
        public string Letter { get; set; }

        [DataMember(Name = "addition", EmitDefaultValue = false)]
        public string Addition { get; set; }

        /// <summary>
        /// Post code in the P6 format
        /// </summary>
        [DataMember(Name = "postcode", EmitDefaultValue = false)]
        public string Postcode { get; set; }

        /// <summary>
        /// Address following the NEN5825 standard
        /// </summary>
        [DataMember(Name = "nen5825", EmitDefaultValue = false)]
        public AddressNen5825 Nen5825 { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public City City { get; set; }

        [DataMember(Name = "municipality", EmitDefaultValue = false)]
        public Municipality Municipality { get; set; }

        [DataMember(Name = "province", EmitDefaultValue = false)]
        public Province Province { get; set; }

        [DataMember(Name = "geo", EmitDefaultValue = false)]
        public Geo Geo { get; set; }

        /// <summary>
        /// Type of the building or object (in Dutch)
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// The object's intended purpose (in Dutch)
        /// </summary>
        [DataMember(Name = "purpose", EmitDefaultValue = false)]
        public string Purpose { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public HalNavigator Links { get; set; }
    }
}
