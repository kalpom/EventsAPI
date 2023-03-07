public class Program
{
    public static void Main(string[] args)
    {

        // calling Configure method

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        var startup = new Startup(builder.Configuration);

        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
       

        // Configure the HTTP request pipeline.

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors("AllowOrigin");

        app.Run();
    }
}