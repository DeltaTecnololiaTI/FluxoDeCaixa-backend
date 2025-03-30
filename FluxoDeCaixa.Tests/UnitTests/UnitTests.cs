using FluxoDeCaixa.Application.Interfaces;
using FluxoDeCaixa.Application.Services;
using FluxoDeCaixa.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FluxoDeCaixa.Tests.UnitTests
{
    public class LancamentoServiceTests
    {
        private readonly Mock<ILancamentoRepository> _lancamentoRepositoryMock;
        private readonly LancamentoService _lancamentoService;

        public LancamentoServiceTests()
        {
            _lancamentoRepositoryMock = new Mock<ILancamentoRepository>();
            _lancamentoService = new LancamentoService(_lancamentoRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnLancamentos()
        {
            // Arrange
            var lancamentos = new List<Lancamento>
            {
                new Lancamento { Id = 1, Valor = 100, Tipo = "Crédito" },
                new Lancamento { Id = 2, Valor = -50, Tipo = "Débito" }
            };
            _lancamentoRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(lancamentos);

            // Act
            var result = await _lancamentoService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepository()
        {
            // Arrange
            var lancamento = new Lancamento { Id = 1, Valor = 100, Tipo = "Crédito" };

            // Act
            await _lancamentoService.AddAsync(lancamento);

            // Assert
            _lancamentoRepositoryMock.Verify(repo => repo.AddAsync(lancamento), Times.Once);
        }
    }
}