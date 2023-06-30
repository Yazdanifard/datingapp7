using System.Collections.Immutable;
using API.Data;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services {
  public static class ApplicationServicesExtensions {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
      IConfiguration config
    ) {
      services.AddDbContext < DataContext > (opt => {
        opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
      });

      services.AddCors();
      services.AddScoped < ITokenService, TokenService > ();
      return services;
    }

  }
}