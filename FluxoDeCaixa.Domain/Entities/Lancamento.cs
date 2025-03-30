namespace FluxoDeCaixa.Domain.Entities
{
    public class Lancamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; } // "Credito" ou "Debito"
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
    }
}
