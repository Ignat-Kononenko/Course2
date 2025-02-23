using Microsoft.AspNetCore.HttpLogging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); // создаем WebApplicationBuilder (паттерн builder)

        builder.Services.AddHttpLogging(o =>
        { //вывод в журнал 

            o.LoggingFields = HttpLoggingFields.RequestMethod |     // request метод
                              HttpLoggingFields.RequestPath |       // request uri
                              HttpLoggingFields.ResponseStatusCode; // request status

        }
        );

        builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information); // фильтр сообщений

        var app = builder.Build();                        // создаем экземпляр WebApplication
        app.UseHttpLogging();                             // middleware: вывод в журнал

        app.MapGet("/d", () => "fff");
        app.MapGet("/", () => "Мое первое ASPA");         // задаем конечную точку

        app.Run();                                        // запускаем web-приложение
    }
}