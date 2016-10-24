using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    /// <summary>
    /// Coordinate Reference System
    /// </summary>
    [DataContract]
    public class Crs
    {
        [DataMember(Name ="type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public Dictionary<string, string> Urns { get; set; }
    }
}
