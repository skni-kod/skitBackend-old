using Data;
using Microsoft.EntityFrameworkCore;
using skitBackend.Data.Seeders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"];

// Add services to the container.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add scoped of seeder (QuSZo)
builder.Services.AddScoped<CompanySeeder>();
//Add scoped of automapper (QuSZo)
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

//Add configure of seeder (QuSZo)
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<CompanySeeder>();
seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
