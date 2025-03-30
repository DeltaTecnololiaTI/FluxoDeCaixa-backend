using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace FluxoDeCaixa.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/lancamentos")]
    public class LancamentoController : ControllerBase
    {
        private readonly LancamentoRepository _repository;

        public LancamentoController(LancamentoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Cria um novo lançamento financeiro.
        /// </summary>
        /// <param name="lancamento">Objeto contendo as informações do lançamento.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Lançamento criado com sucesso.</response>
        /// <response code="400">Requisição inválida, verifique os dados informados.</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um lançamento financeiro", Description = "Registra um novo lançamento no sistema.")]
        [SwaggerResponse(200, "Lançamento registrado com sucesso.")]
        [SwaggerResponse(400, "Valor deve ser maior que zero e tipo deve ser informado.")]
        public async Task<IActionResult> CriarLancamento([FromBody] Lancamento lancamento)
        {
            if (lancamento.Valor <= 0 || string.IsNullOrEmpty(lancamento.Tipo))
                return BadRequest("Valor deve ser maior que zero e tipo deve ser informado.");

            await _repository.AddAsync(lancamento);
            return Ok("Lançamento registrado com sucesso.");
        }

        /// <summary>
        /// Obtém os lançamentos financeiros de uma determinada data.
        /// </summary>
        /// <param name="data">Data no formato dd-MM-yyyy.</param>
        /// <returns>Lista de lançamentos da data informada.</returns>
        /// <response code="200">Lista de lançamentos retornada com sucesso.</response>
        /// <response code="400">Formato de data inválido.</response>
        [HttpGet("{data}")]
        [SwaggerOperation(Summary = "Obtém lançamentos por data", Description = "Retorna todos os lançamentos financeiros registrados para uma data específica.")]
        [SwaggerResponse(200, "Lista de lançamentos retornada com sucesso.")]
        [SwaggerResponse(400, "Formato de data inválido. Use dd-MM-yyyy.")]
        public async Task<IActionResult> ObterLancamentosPorData(string data)
        {
            if (!DateTime.TryParseExact(data, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida))
            {
                return BadRequest("Formato de data inválido. Use dd-MM-yyyy.");
            }

            var lancamentos = await _repository.GetByDateAsync(dataConvertida);
            return Ok(lancamentos);
        }
    }
}
