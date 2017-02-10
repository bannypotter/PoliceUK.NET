namespace PoliceUk.Entities
{
    using System.Runtime.Serialization;

    [DataContract]
    public class OutcomeCategory
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Name of the crime category
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
