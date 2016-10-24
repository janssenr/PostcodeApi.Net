using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PostcodeApi.Net.V2.Model
{
    [DataContract]
    public class PostcodeNen5825
    {
        [DataMember(Name = "streets", EmitDefaultValue = false)]
        public List<string> Streets { get; set; }

        [DataMember(Name = "postcode", EmitDefaultValue = false)]
        public string Postcode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", string.Join(", ", Streets), Environment.NewLine, Postcode);
        }
    }
}
