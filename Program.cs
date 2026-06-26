using SignalR_Lab.Hubs;
using SignalR_Lab.Services;

var builder = WebApplication.CreateBuilder(args);

// SignalR
builder.Services.AddSignalR();

// Application Service
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

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