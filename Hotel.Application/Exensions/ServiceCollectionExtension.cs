using Hotel.Application.Services;
using Hotel.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Exensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRezerwacjaService, RezerwacjaService>();
            services.AddScoped<IOsobaService, OsobaService>();
            services.AddScoped<IPokojService, PokojService>();

            //TODO dwa zakomentowane serwisy nie pozwalają wstać BD, na razie ich nie potrzeba, więc tak zostaja
        }
    }
}