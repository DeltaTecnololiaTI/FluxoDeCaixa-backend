using FluxoDeCaixa.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net.Mime;

namespace FluxoDeCaixa.API.Controllers
{
    /// <summary>
    /// Controller responsável por operações relacionadas ao saldo diário
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/saldodiario")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SaldoDiarioController : ControllerBase
    {
        private readonly ISaldoDiarioService _saldoDiarioService;

        public SaldoDiarioController(ISaldoDiarioService saldoDiarioService)
        {
            _saldoDiarioService = saldoDiarioService;
        }

        /// <summary>
        /// Obtém o saldo consolidado para uma data específica
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/saldodiario/2023-05-15
        ///
        /// </remarks>
        /// <param name="data">Data para consulta no formato dd-MM-yyyy.</param>
        /// <returns>Dados do saldo diário consolidado</returns>
        /// <response code="200">Retorna o saldo diário calculado</response>
        /// <response code="400">Se a data for inválida</response>
        /// <response code="404">Se não houver lançamentos para a data informada</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpGet("{data:datetime}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterSaldoDiario(string data)
        {

            try
            {
                if (!DateTime.TryParseExact(data, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida))
                {
                    return BadRequest("Formato de data inválido. Use dd-MM-yyyy.");
                }
                // Validação básica da data
                if (dataConvertida > DateTime.Today.AddDays(1))
                {
                    return BadRequest("Data não pode ser futura");
                }

                var saldo = await _saldoDiarioService.CalcularSaldoDiarioAsync(dataConvertida.Date);

                if (saldo == null)
                {
                    return NotFound($"Nenhum lançamento encontrado para a data {dataConvertida:yyyy-MM-dd}");
                }

                return Ok(saldo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um erro ao processar a requisição: {ex.Message}");
            }
        }
    }
}