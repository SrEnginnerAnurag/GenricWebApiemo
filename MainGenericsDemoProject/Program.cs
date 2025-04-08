
using MainGenericsDemoProject.GenericsDBContextFolder;
using MainGenericsDemoProject.Repo;
using MainGenericsDemoProject.Repo.ServiceFolder;
using Microsoft.EntityFrameworkCore;

namespace MainGenericsDemoProject
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


            builder.Services.AddDbContext<GenericsDbContextClass>(res => 
            {
                res.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"));
            });

            builder.Services.AddScoped(typeof(IGenericsService<>), typeof(GenericsService<>));


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
