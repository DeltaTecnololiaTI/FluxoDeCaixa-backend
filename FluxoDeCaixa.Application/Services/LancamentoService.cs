using FluxoDeCaixa.Application.Interfaces;
using FluxoDeCaixa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Application.Services
{
    public class LancamentoService : ILancamentoRepository
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository ?? throw new ArgumentNullException(nameof(lancamentoRepository));
        }

        public async Task<IEnumerable<Lancamento>> GetAllAsync()
        {
            return await _lancamentoRepository.GetAllAsync();
        }

        public async Task<Lancamento> GetByIdAsync(int id)
        {
            return await _lancamentoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Lancamento lancamento)
        {
            if (lancamento == null)
                throw new ArgumentNullException(nameof(lancamento));

            await _lancamentoRepository.AddAsync(lancamento);
        }

        public async Task UpdateAsync(Lancamento lancamento)
        {
            if (lancamento == null)
                throw new ArgumentNullException(nameof(lancamento));

            await _lancamentoRepository.UpdateAsync(lancamento);
        }

        public async Task DeleteAsync(int id)
        {
            await _lancamentoRepository.DeleteAsync(id);
        }
    }
}
