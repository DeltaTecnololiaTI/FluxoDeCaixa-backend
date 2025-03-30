using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Domain.DTOs
{
    public class LancamentoResponseDto
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string CategoriaNome { get; set; }
    }
}
