using System.ComponentModel;

namespace PostcodeApi.Net.V1.Model
{
    /// <summary>
    /// Basisregistraties van het ministerie van Infrastructuur en Milieu
    /// </summary>
    public class Bag
    {
        /// <summary>
        /// Uniek adres-identificatienummer
        /// </summary>
        [Description("Kadastraal objectnummer")]
        public string Id { get; set; }
        /// <summary>
        /// Addresseerbaar object type
        /// </summary>
        [Description("Addresseerbaar object type")]
        public string Type { get; set; }
        /// <summary>
        /// Gebruiksdoel verblijfsobject
        /// </summary>
        [Description("Gebruiksdoel verblijfsobject")]
        public string Purpose { get; set; }
    }
}