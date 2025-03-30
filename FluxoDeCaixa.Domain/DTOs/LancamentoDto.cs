using FluxoDeCaixa.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FluxoDeCaixa.Domain.DTOs
{
    public class LancamentoDto
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoLancamento Tipo { get; set; }
        public int CategoriaId { get; set; }
    }

}
