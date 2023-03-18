using NaiveGraph.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void AddNaiveGraphService(this IServiceCollection services)
        {
            services.AddSingleton<NaiveGraphService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(NaiveGraphService).Assembly));

            services.AddAutoMapper(typeof(NaiveGraphService).Assembly);
        }
    }
}
