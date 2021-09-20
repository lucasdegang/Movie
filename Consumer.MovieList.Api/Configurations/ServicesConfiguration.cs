using Consumer.MovieList.Api.Domain.Movie.Interface;
using Consumer.MovieList.Api.Domain.Movie.Service;
using Consumer.MovieList.Api.Infra;
using Consumer.MovieList.Api.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Consumer.MovieList.Api.Configurations
{
    public class ServicesConfiguration
    {
        public static IServiceCollection GetServiceProvider(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consumer Movie List", Version = "v1" });
            });

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddDbContext<MovieDbContext>(options => options.UseInMemoryDatabase("Movie"));
            
            return services;
        }
    }
}
