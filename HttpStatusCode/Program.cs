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
//category servisini container içerisine register ediyoruz
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<ISehirDAL, SehirDAL>();
builder.Services.AddScoped<IilceDAL, IlceDAL>();
#region Cors ayarlarının eklenmesi
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p => p.AllowAnyHeader()
                                 .AllowAnyOrigin()
                                 .AllowAnyMethod());
});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Cors u middleWare icerisine ekliyoruz
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
