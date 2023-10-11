using API.DatabaseContext;
using API.Repository.Definition;
using API.Repository.Implementation;
using API.Services.Definition;
using API.Services.Implementation;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddCors();

            //--------Add Repository-----------------------------------------
            services.AddScoped<IUserRepository, UserRepository>();
            //----------Add Service------------------------------------------
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            //---------------------------------------------------------------

            return services;
        }
        
    }
}
