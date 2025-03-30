using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Infra.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<Lancamento> AdicionarAsync(Lancamento lancamento);
        Task<IEnumerable<Lancamento>> ObterTodosAsync();
    }
}
