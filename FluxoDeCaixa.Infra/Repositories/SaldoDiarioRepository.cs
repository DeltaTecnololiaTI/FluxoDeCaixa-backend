using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FluxoDeCaixa.Infra.Repositories
{
    public class SaldoConsolidadoRepository
    {
        private readonly AppDbContext _context;

        public SaldoConsolidadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(SaldoDiario saldo)
        {
            var existing = await _context.SaldosDiarios
                .FirstOrDefaultAsync(s => s.Data == saldo.Data);

            if (existing != null)
            {
                existing.Saldo = saldo.Saldo;
            }
            else
            {
                await _context.SaldosDiarios.AddAsync(saldo);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<SaldoDiario?> GetByDateAsync(DateTime data)
        {
            return await _context.SaldosDiarios
                .FirstOrDefaultAsync(s => s.Data == data.Date);
        }
    }
}
