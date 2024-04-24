
using Microsoft.EntityFrameworkCore;
using QuickParcelApi.Data;

namespace QuickParcelApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var QuickParcelConnectionString = builder.Configuration.GetConnectionString("QuickParcelConnectionString");

            // Add services to the container.


            builder.Services.AddDbContext<QuickParcelDbContext>(options => options.UseSqlServer(QuickParcelConnectionString));

            builder.Services.AddControllers();
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


            using (var scope = app.Services.CreateScope()) {

                var services = scope.ServiceProvider;
                var QuickParcelContext = services.GetRequiredService<QuickParcelDbContext>();
                QuickParcelContext.Database.EnsureCreated();
                QuickParcelInitializer.Initialize(QuickParcelContext);

            }

                app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
