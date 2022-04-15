using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Service;
using Microsoft.EntityFrameworkCore;
using API.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static  class ApplicationSeviceExtensions
    {  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
         {   services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>{
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));

        });
        return services;        
        }   
    
         }
}