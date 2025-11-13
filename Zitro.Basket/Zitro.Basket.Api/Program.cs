using Zitro.Basket.Api;
using Zitro.Basket.Application;
using Zitro.Basket.Domain;
using Zitro.Basket.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInfrastructure(builder.Configuration);

builder.Services.AddScoped<ICartService, CartService>();


// Add services to the container.
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

app.MapPost("/cart/services/normalize", async (AddCartServicesRequest request, ICartService cartService) =>
{
    try
    {
        var result = await cartService.AddCartServiceItemAsync(
            request.CartItem,
            request.ProductProperty);

        return Results.Ok(result);
    }
    catch (DomainException ex)
    {
        return Results.BadRequest(new { message = ex.Message });
    }
});

app.Run();
