using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class RijksDriehoek
    {
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "coordinates", EmitDefaultValue = false)]
        public List<double> Coordinates { get; set; }

        [DataMember(Name = "crs", EmitDefaultValue = false)]
        public Crs ReferenceSystem { get; set; }
    }
}
