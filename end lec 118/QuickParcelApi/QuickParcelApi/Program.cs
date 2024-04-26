using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuickParcelApi.Data;
using System.Text.Json.Serialization;

namespace QuickParcelApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var QuickParcelConnectionString = builder.Configuration.GetConnectionString("QuickParcelConnection");
            // Add services to the container.
            builder.Services.AddDbContext<QuickParcelDbContext>(options => options.UseSqlServer(QuickParcelConnectionString));
            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var QuickParcelContext = services.GetRequiredService<QuickParcelDbContext>();
                //error is here
                QuickParcelContext.Database.EnsureCreated();
                //error is here
                QuickParcelInitializer.Initialize(QuickParcelContext);
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}