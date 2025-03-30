using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.DTOs;
namespace FluxoDeCaixa.Domain.Interfaces;

public interface ILancamentoService
{
    Task<Lancamento> CriarLancamentoAsync(LancamentoDto lancamentoDto);
    Task<IEnumerable<Lancamento>> ObterLancamentosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
}