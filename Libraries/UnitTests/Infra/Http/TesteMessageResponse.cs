using System.Runtime.Serialization;

namespace Services
{
    [DataContract]
    public class TesteMessageResponse
    {
        [DataMember(Name = "teste")]
        public int TesteRetorno { get; set; }
    }
}