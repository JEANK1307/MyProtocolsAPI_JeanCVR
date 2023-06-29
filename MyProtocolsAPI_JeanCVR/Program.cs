using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyProtocolsAPI_JeanCVR.Models;

namespace MyProtocolsAPI_JeanCVR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //VAMOS A LEER LA ETIQUETA A CNNSTR DE APPSETTINGS.JSON PARA CONFIGURAR LA CONEXIÓN
            //A LA BASE DE DATOS.
            var CnnStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CNNSTR"));

            //eliminamos de la CNNSTR el dato de password ya que seria muy sencillo obtener la info de conexion
            //del usuario de SQL Server del archivo de config appsettings.json.
            CnnStrBuilder.Password = "123456";
            
            string cnnStr = CnnStrBuilder.ConnectionString;

            //ahora conectamos el proyecto a la base de datos usando cnnStr
            builder.Services.AddDbContext<MyProtocolsDBContext>(options => options.UseSqlServer(cnnStr));

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

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}