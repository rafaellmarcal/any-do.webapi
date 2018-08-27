using Newtonsoft.Json;

namespace AnyDo.EnvelopeJson.Logic.EnvelopeJson
{
    public class TarefaEnvelopeJson
    {
        [JsonProperty(PropertyName = "tarefaid")]
        public int TarefaID { get; set; }

        [JsonProperty(PropertyName = "titulo")]
        public string Titulo { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "datacadastro")]
        public string DataCadastro { get; set; }

        [JsonProperty(PropertyName = "dataconclusao")]
        public string DataConclusao { get; set; }

        [JsonProperty(PropertyName = "concluida")]
        public bool Concluida { get; set; }

        [JsonProperty(PropertyName = "usuarioid")]
        public int UsuarioID { get; set; }
    }
}
