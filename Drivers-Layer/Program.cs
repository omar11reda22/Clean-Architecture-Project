
using Application_Layer.Handlers;
using Infrastructure_Layer.MyContext;
using Infrastructure_Layer.Repositories;
using Infrastructure_Layer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Drivers_Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("key");
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(connection));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IApplicantRepository, ApplicantRepository>();
            builder.Services.AddTransient<IMajorRepsitory, MajorRepository>(); 
            // builder.Services.AddSingleton<IFileStorageService, FileStorageService>();
            builder.Services.AddTransient<IFileStorageService>(option =>
            {
                var webHostEnvironment = option.GetRequiredService<IWebHostEnvironment>();
                return new FileStorageService(webHostEnvironment.WebRootPath);
            });
            builder.Services.AddTransient<IUniversityRepository, UniversityRepository>();
            builder.Services.AddTransient<IMajorRepsitory, MajorRepository>();
          //  builder.Services.AddMediatR(typeof(AddnewapplicantHandler).Assembly);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddnewapplicantHandler).Assembly));
            builder.Services.AddMediatR(s => s.RegisterServicesFromAssemblies(typeof(GetallUniversityHandler).Assembly));
            var app = builder.Build();

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
    }
}
