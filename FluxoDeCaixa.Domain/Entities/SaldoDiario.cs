namespace FluxoDeCaixa.Domain.Entities
{
    public class SaldoDiario
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Saldo { get; set; }
    }

}
