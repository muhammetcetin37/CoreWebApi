using HttpStatusCode.Infrastructure.Contex;
using HttpStatusCode.Infrastructure.Repository.Abstract;
using HttpStatusCode.Infrastructure.Repository.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDb"));
});
//category servisini container išerisine register ediyoruz
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<ISehirDAL, SehirDAL>();
builder.Services.AddScoped<IilceDAL, IlceDAL>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
