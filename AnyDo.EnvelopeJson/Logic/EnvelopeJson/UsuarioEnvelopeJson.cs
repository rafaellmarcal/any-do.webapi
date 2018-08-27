using Newtonsoft.Json;

namespace AnyDo.EnvelopeJson.Logic.EnvelopeJson
{
    public class UsuarioEnvelopeJson
    {
        [JsonProperty(PropertyName = "usuarioid")]
        public int UsuarioID { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "senha")]
        public string Senha { get; set; }
    }
}
