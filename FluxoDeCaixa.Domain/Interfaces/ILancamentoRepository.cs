using FluxoDeCaixa.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Application.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<Lancamento>> GetAllAsync();
        Task<Lancamento> GetByIdAsync(int id);
        Task AddAsync(Lancamento lancamento);
        Task UpdateAsync(Lancamento lancamento);
        Task DeleteAsync(int id);
    }
}