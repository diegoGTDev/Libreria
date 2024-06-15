using WebService.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MiCors = "MiCors";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PruebaContext>(options => options.UseSqlServer("Server=DESKTOP-17OBIDL\\SQLEXPRESS;Database=Prueba;Trusted_Connection=true;TrustServerCertificate=true"));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
        policy =>
        {
            policy.WithHeaders("*");
            policy.WithMethods("*");
            policy.WithOrigins("*");
        });
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();
