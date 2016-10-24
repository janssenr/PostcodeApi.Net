using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class PostcodeView
    {
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public City City { get; set; }

        [DataMember(Name = "streets", EmitDefaultValue = false)]
        public List<string> Streets { get; set; }

        /// <summary>
        /// Post code in the P6 format
        /// </summary>
        [DataMember(Name = "postcode", EmitDefaultValue = false)]
        public string Postcode { get; set; }

        /// <summary>
        /// Address following the NEN5825 standard
        /// </summary>
        [DataMember(Name = "nen5825", EmitDefaultValue = false)]
        public PostcodeNen5825 Nen5825 { get; set; }

        [DataMember(Name = "municipality", EmitDefaultValue = false)]
        public Municipality Municipality { get; set; }

        [DataMember(Name = "geo", EmitDefaultValue = false)]
        public Geo Geo { get; set; }

        [DataMember(Name = "province", EmitDefaultValue = false)]
        public Province Province { get; set; }
    }
}
