using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyWeb.Middlewares;
using NLog.Web;
using Service;
using Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShulamitHome");
builder.Host.UseNLog();
// Add services to the container.
builder.Services.AddDbContext<WebSiteContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRatingService, RatingService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseErrorHandlingMiddleware();
app.UseCacheMiddleware();



app.UseRating();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.


app.UseStaticFiles();

app.UseAuthorization();


app.MapControllers();

app.Run();
