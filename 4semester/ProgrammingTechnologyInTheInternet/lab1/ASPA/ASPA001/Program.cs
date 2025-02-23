using Microsoft.AspNetCore.HttpLogging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); // ������� WebApplicationBuilder (������� builder)

        builder.Services.AddHttpLogging(o =>
        { //����� � ������ 

            o.LoggingFields = HttpLoggingFields.RequestMethod |     // request �����
                              HttpLoggingFields.RequestPath |       // request uri
                              HttpLoggingFields.ResponseStatusCode; // request status

        }
        );

        builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information); // ������ ���������

        var app = builder.Build();                        // ������� ��������� WebApplication
        app.UseHttpLogging();                             // middleware: ����� � ������

        app.MapGet("/d", () => "fff");
        app.MapGet("/", () => "��� ������ ASPA");         // ������ �������� �����

        app.Run();                                        // ��������� web-����������
    }
}