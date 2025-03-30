using AutoMapper;
using FluxoDeCaixa.API.DTOs;
using FluxoDeCaixa.Domain.Entities;


namespace FluxoDeCaixa.API.Mappers
{
    public class SaldoDiarioMappingProfile : Profile
    {
        public SaldoDiarioMappingProfile()
        {
            CreateMap<SaldoDiario, SaldoDiarioDto>().ReverseMap();
        }
    }

}