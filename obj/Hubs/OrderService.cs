using Microsoft.AspNetCore.SignalR;
using SignalR_Lab.Hubs;

namespace SignalR_Lab.Services
{
    public class OrderService
    {
        private readonly IHubContext<OrderHub> _hubContext;
    
        public OrderService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }
    
        public async Task CreateOrderAsync(string productName)
        {
            // -------------------------------
            // 1. شبیه‌سازی ذخیره در دیتابیس
            // -------------------------------
            Console.WriteLine($"Saving order: {productName}");
    
            // -------------------------------
            // 2. بعد از ذخیره، اطلاع به همه ادمین‌ها
            // -------------------------------
            await _hubContext.Clients.All.SendAsync(
                "NewOrder",
                new
                {
                    Product = productName,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}

