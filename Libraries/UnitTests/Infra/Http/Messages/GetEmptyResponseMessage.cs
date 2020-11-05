using System.Runtime.Serialization;

namespace ServicesClient.Messages
{
    [DataContract]
    public class GetEmptyResponseMessage
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "statusDescricao")]
        public string StatusDescricao { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "detalhes")]
        public string Detalhes { get; set; }
    }
}