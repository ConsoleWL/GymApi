using GymApi.Services.CustomerServices;
using GymDb;
using Microsoft.EntityFrameworkCore;

namespace GymApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICustomerService, CustomerService>();

            //added this
            string connectionString = "Server=.;Database=GymDB;trusted_connection=True;TrustServerCertificate=True;";

            builder.Services.AddDbContext<GymDbContext>(options=>
            {
                options.UseSqlServer(connectionString);

            });
            //
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