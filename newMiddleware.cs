using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class newMiddleware
{
    private readonly RequestDelegate _next;

    public newMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine($"Nueva solicitud: {context.Request.Method} {context.Request.Path}");

        await _next(context); // Continúa con el siguiente middleware o controlador
    }
}