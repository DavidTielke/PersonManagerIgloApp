
using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using ConsoleClient.Logic;

namespace ServiceClient
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

            builder.Services.AddTransient<IFileStore, FileStore>();
            builder.Services.AddTransient<IPersonParser, PersonParser>();
            builder.Services.AddTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddTransient<IPersonManager, PersonManager>();
            builder.Services.AddTransient<IPersonLogicValidator, PersonLogicValidator>();
            builder.Services.AddTransient<IPersonDataValidator, PersonDataValidator>();
            builder.Services.AddSingleton<IConfigurator, Configurator>();

            var app = builder.Build();

            var config = app.Services.GetService<IConfigurator>();
            config.Set("AgeTreshold", 10);
            config.Set("CsvPath", "data.csv");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
