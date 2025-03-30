// FluxoDeCaixa.Application/DTOs/CriarLancamentoDto.cs
using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Infra.DTOs
{
    public class CriarLancamentoDto
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoLancamento Tipo { get; set; }
        public int CategoriaId { get; set; }
    }
}