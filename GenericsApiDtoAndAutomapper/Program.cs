
using GenericsApiDtoAndAutomapper.DbContextFolder;
using GenericsApiDtoAndAutomapper.DtoFolder;
using GenericsApiDtoAndAutomapper.ModelFolder;
using GenericsApiDtoAndAutomapper.ProfileFolder;
using GenericsApiDtoAndAutomapper.RepoFolder;
using GenericsApiDtoAndAutomapper.RepoFolder.ServiceFolder;
using Microsoft.EntityFrameworkCore;

namespace GenericsApiDtoAndAutomapper
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



            builder.Services.AddDbContext<EmployeeDbContext>(res => 
            {
                res.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"));
            });

            builder.Services.AddAutoMapper(typeof(EmployeeMapper)); //builder.Services.AddAutoMapper(typeof(Program)); galat hai, kyunki Program class mein AutoMapper ka configuration nahi hota. 

            builder.Services.AddScoped(typeof(IEmployeeService<EmployeeDto>), typeof(EmployeeService<EmployeeModel , EmployeeDto>));
            builder.Services.AddScoped(typeof(IEmployeeService<CochingDto>), typeof(EmployeeService<CochingModel , CochingDto>));


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
