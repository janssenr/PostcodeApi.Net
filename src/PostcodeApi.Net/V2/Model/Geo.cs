using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class Geo
    {
        [DataMember(Name = "center", EmitDefaultValue = false)]
        public GeographicCenter GeographicCenter { get; set; }
    }
}
