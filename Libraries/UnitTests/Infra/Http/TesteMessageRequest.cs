using System.Runtime.Serialization;

namespace Services
{
    [DataContract]
    public class TesteMessageRequest
    {
        [DataMember(Name = "teste")]
        public int Teste { get; set; }
    }
}