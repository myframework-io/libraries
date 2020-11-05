using System.Runtime.Serialization;

namespace ServicesClient.Messages
{
    [DataContract]
    public class RetornoResponseMessage2
    {
        [DataMember(Name = "pis")]
        public string Pis { get; set; }
    }
}