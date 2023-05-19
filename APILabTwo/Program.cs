
using APIBLayer.Managers.Departments;
using APIBLayer.Managers.Tickets;
using APIDAL.Data.Context;
using APIDALayer.Repos.Departments;
using APIDALayer.Repos.Tickets;
using Microsoft.EntityFrameworkCore;

namespace APILabTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connection_String = builder.Configuration.GetConnectionString("AirPortConnection");
            builder.Services.AddDbContext<DataBaseContext>(options => 
            options.UseSqlServer(connection_String));

            builder.Services.AddScoped<ITicket,TicketRepo>();
            builder.Services.AddScoped<ITicketManager,TicketManager>();

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
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