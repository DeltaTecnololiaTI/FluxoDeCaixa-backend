using AutoMapper;
using FluxoDeCaixa.Application.DTOs;
using FluxoDeCaixa.Domain.DTOs;
using FluxoDeCaixa.Domain.Entities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Lancamento, LancamentoDTO>().ReverseMap();
        CreateMap<SaldoDiario, SaldoDiarioDTO>().ReverseMap();
        // Adicione outros mapeamentos conforme necessário
    }
}
