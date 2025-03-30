using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FluxoDeCaixa.Infra.Repositories
{
    public class LancamentoRepository
    {
        private readonly AppDbContext _context;

        public LancamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lancamento lancamento)
        {
            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lancamento>> GetByDateAsync(DateTime date)
        {
            return await _context.Lancamentos
                .Where(l => l.Data.Date == date.Date)
                .ToListAsync();
        }
    }
}
