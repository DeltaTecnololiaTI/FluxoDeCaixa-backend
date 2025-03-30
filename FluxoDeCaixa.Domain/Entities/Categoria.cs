using System.Text.Json.Serialization;

namespace FluxoDeCaixa.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}
