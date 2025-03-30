using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FluxoDeCaixa.Application.Interfaces;
using FluxoDeCaixa.Infra.Persistence;

namespace FluxoDeCaixa.Infra.Services
{
    public class LancamentoService : ILancamentoRepository
    {
        private readonly AppDbContext _context;

        public LancamentoService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Lancamento>> GetAllAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<Lancamento> GetByIdAsync(int id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }

        public async Task AddAsync(Lancamento lancamento)
        {
            if (lancamento == null)
                throw new ArgumentNullException(nameof(lancamento));

            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lancamento lancamento)
        {
            if (lancamento == null)
                throw new ArgumentNullException(nameof(lancamento));

            _context.Lancamentos.Update(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null)
                throw new KeyNotFoundException($"Lançamento com ID {id} não encontrado.");

            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();
        }
    }
}
