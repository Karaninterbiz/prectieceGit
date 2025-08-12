using FinancialModule.Contracts.Repositories;
using FinancialModule.Core.Services;
using FinancialModule.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace FinancialModule.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFinancialModule(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<InvoiceService>();
            return services;
        }
    }
}
