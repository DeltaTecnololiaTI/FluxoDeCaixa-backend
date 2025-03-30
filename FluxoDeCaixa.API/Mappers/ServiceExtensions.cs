namespace FluxoDeCaixa.API.Mappers
{
    public static class ServiceExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(LancamentoMappingProfile), typeof(SaldoDiarioMappingProfile));
        }
    }
}
