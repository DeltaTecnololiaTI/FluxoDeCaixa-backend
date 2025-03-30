using System.ComponentModel.DataAnnotations;

namespace FluxoDeCaixa.Domain.DTOs
{
    public class SaldoDiarioDto
    {
        public DateTime Data { get; set; }
        public decimal Saldo { get; set; }
    }
}
