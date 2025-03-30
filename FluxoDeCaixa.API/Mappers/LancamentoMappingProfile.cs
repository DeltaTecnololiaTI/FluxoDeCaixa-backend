using AutoMapper;
using FluxoDeCaixa.API.DTOs;
using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.API.Mappers
{
    public class LancamentoMappingProfile : Profile
    {
        public LancamentoMappingProfile()
        {
            CreateMap<Lancamento, LancamentoDto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString())) // Converte enum para string
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nome)); // Mapeia o nome da categoria

            CreateMap<LancamentoDto, Lancamento>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => Enum.Parse<TipoLancamento>(src.Tipo))) // Converte string para enum
                .ForMember(dest => dest.Categoria, opt => opt.Ignore()); // Ignora a categoria no mapeamento inverso (ou ajuste conforme sua lógica)
        }
    }
}