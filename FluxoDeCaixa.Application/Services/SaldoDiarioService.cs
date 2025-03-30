using FluxoDeCaixa.Application.Interfaces;
using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Infra.Repositories;

namespace FluxoDeCaixa.Application.Services
{
    public class SaldoDiarioService : ISaldoDiarioService
    {
        private readonly LancamentoRepository _lancamentoRepository;
        private readonly SaldoConsolidadoRepository _saldoConsolidadoRepository;

        public SaldoDiarioService(LancamentoRepository lancamentoRepository, SaldoConsolidadoRepository saldoConsolidadoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _saldoConsolidadoRepository = saldoConsolidadoRepository;
        }

        public async Task<SaldoDiario > CalcularSaldoDiarioAsync(DateTime data)
        {
            var lancamentos = await _lancamentoRepository.GetByDateAsync(data);
            decimal saldo = lancamentos.Sum(l => l.Tipo.ToLower() == "credito" ? l.Valor : -l.Valor);

            var saldoConsolidado = new SaldoDiario
            {
                Data = data.Date,
                Saldo = saldo
            };

            await _saldoConsolidadoRepository.SaveAsync(saldoConsolidado);
            return saldoConsolidado;
        }
    }
}
