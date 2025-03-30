using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Application.Interfaces
{
    public interface ISaldoDiarioService
    {
        Task<SaldoDiario> CalcularSaldoDiarioAsync(DateTime data);
    }
}
