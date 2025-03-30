using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Infra.Interfaces
{
    public interface ISaldoDiarioRepository
    {
        Task<SaldoDiario> ObterPorDataAsync(DateTime data);
        Task AtualizarSaldoAsync(SaldoDiario saldoDiario);
    }
}
