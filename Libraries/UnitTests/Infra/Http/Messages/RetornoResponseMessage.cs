using System.Runtime.Serialization;

namespace ServicesClient.Messages
{
    [DataContract]
    public class RetornoResponseMessage
    {
        [DataMember(Name = "localidade")]
        public int Localidade { get; set; }

        [DataMember(Name = "idCorretor")]
        public int IdCorretor { get; set; }

        [DataMember(Name = "idProduto")]
        public int IdProduto { get; set; }

        [DataMember(Name = "idTipoProduto")]
        public int IdTipoProduto { get; set; }

        [DataMember(Name = "profissao")]
        public string Profissao { get; set; }
    }
}