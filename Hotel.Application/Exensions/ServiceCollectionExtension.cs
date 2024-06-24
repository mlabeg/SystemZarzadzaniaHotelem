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
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IOsobaService, OsobaService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomReservationService, RoomReservationService>();
        }
    }
}