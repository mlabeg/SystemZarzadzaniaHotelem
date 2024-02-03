using Hotel.Infrastructure.Presistence;
using Hotel.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hotel.Domain.Interfaces;
using Hotel.Infrastructure.Repositories;

namespace Hotel.Infrastructure.Extensions
{
    public static class ServiceCollectionExtencion
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Hotel")));

            services.AddScoped<HotelSeeder>();

            services.AddScoped<IReservationRepository, ReservationsRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IRoomsRepository, RoomsRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        }
    }
}