
using Microsoft.EntityFrameworkCore;
using schoolManagementBussenesslogic.MapperProfileFolder;
using schoolManagementBussenesslogic.RepoFolder;
using schoolManagementBussenesslogic.RepoFolder.InterfaceServiceFolder;
using SchoolManagementDto;
using SchoolManagementModel.DbContexFolder;
using SchoolManagementModel.MolderFolder;
using SchoolMangementDto;

namespace SchoolManagementWebApiProjectGenerics
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


            builder.Services.AddDbContext<TeacherDbContext>(res=> 
            {
                res.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"));
            });

            builder.Services.AddAutoMapper(typeof(MapperProfileClass));

            builder.Services.AddScoped(typeof(IServiceClass<TeacherDto> ), typeof(ServiceClass<TeachersModel ,TeacherDto>));
            builder.Services.AddScoped(typeof(IServiceClass<StudentDto> ), typeof(ServiceClass<StudentModel ,StudentDto>));




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
