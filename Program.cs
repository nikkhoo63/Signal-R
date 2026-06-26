using SignalR_Lab.Hubs;
using SignalR_Lab.Services;

var builder = WebApplication.CreateBuilder(args);

// SignalR
builder.Services.AddSignalR();

// Application Service
builder.Services.AddScoped<OrderService>();

// CORS - Allow all origins for development
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();

app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();

// Hub endpoint
app.MapHub<OrderHub>("/orderHub");

// Test endpoint برای ساخت order
app.MapGet("/create-order", async (OrderService service) =>
{
    // -------------------------------
    // تست ساده بدون Controller
    // -------------------------------
    await service.CreateOrderAsync("Pizza Margherita");

    return Results.Ok("Order created");
});

app.Run();