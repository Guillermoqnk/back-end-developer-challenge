using AutoMapper;
using Data.Contracts;
using Data.Model;
using Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Services.Configuration;
using Services.Contracts;
using Services.Implementations;

namespace DnDBeyondAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<DataSeeder>();
        builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
        builder.Services.AddScoped<ICharacterService, CharacterService>();
        builder.Services.AddScoped<ICombatService, CombatService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddDbContext<DnDContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DnDContext>();
            context.Database.Migrate();
            //SeedData(app);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void SeedData(IHost app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        using (var scope = app.Services.CreateScope())
        {
            var service = scope.ServiceProvider.GetService<DataSeeder>();
            service.Seed();
        }
    }
}