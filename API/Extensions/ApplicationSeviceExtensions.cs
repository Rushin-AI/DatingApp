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
using API.Services;

namespace API.Extensions
{
    public static  class ApplicationSeviceExtensions
    {  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
         {   services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
             services.AddScoped<ITokenService, TokenService>();
             services.AddScoped<IPhotoService, PhotoService>();
             services.AddScoped<ILikesRepository, LikesRepository>();
             services.AddScoped<IMessageRepository, MessageRepository>();
             services.AddScoped<LogUserActivity>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>{
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));

        });
        return services;        
        }   
    
         }
}