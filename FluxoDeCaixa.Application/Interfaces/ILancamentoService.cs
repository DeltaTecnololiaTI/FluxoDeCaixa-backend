

using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Infra.DTOs;

namespace FluxoDeCaixa.API.Interfaces
{
    public interface ILancamentoService
    {
        Task<Lancamento> CriarLancamentoAsync(CriarLancamentoDto lancamentoDto);
        Task<IEnumerable<Lancamento>> ObterLancamentosAsync();
    }
}

