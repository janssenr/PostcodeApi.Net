using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class Municipality
    {
        /// <summary>
        /// Identifier of the municipality. 
        /// Equals that of the Dutch governmental standard BAG.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
