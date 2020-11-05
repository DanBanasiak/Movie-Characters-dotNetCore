using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWars.Api.Configurations;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StarWars.Application.Interfaces;
using StarWars.Application.Data;
using StarWars.Application.Queries;
using StarWars.Application.Data.Repositories;
using StarWars.Application.Commands.Characters.Create;
using StarWars.Domain.SeedWork;
using StarWars.Persistence;

namespace StarWars.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(
                typeof(GetCharactersQuery).Assembly, 
                typeof(CreateCharacterCommand).Assembly);

            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<IWeaponRepository, WeaponRepository>();
            services.AddScoped<ICharacterEpisodeRepository, CharacterEpisodeRepository>();
            services.AddScoped<ICharacterFriendRepository, CharacterFriendRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddSwaggerDocumentation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}