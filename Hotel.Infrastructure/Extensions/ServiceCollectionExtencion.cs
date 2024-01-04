﻿using Hotel.Infrastructure.Presistence;
using Hotel.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Interefaces;
using Hotel.Infrastructure.Repositories;

namespace Hotel.Infrastructure.Extensions
{
    public static class ServiceCollectionExtencion
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Hotel")));

            services.AddScoped<HotelSeder>();

            services.AddScoped<IRezerwacjeRepository, RezerwacjeRepository>();
        }
    }
}