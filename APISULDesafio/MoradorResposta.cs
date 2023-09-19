using System.Text.Json.Serialization;

namespace APISULDesafio
{
    public class MoradorResposta
    {
        [JsonPropertyName("andar")]
        public int Andar { get; set; }

        [JsonPropertyName("elevador")]
        public string Elevador { get; set; }

        [JsonPropertyName("turno")]
        public string Turno { get; set; }
    }

}