using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class GeographicCenter
    {
        [DataMember(Name = "wgs84", EmitDefaultValue = false)]
        public WorldGeodeticSystem WgsCoordinates { get; set; }

        [DataMember(Name = "rd", EmitDefaultValue = false)]
        public RijksDriehoek RdCoordinates { get; set; }
    }
}
