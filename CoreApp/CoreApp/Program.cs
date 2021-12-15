using CoreApp.Data;
using CoreApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("secret.json", optional: false, reloadOnChange: true);
var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_MyAllowSubdomainPolicy",
        builder =>
        {
            builder.AllowAnyOrigin();
        });
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<CoreAppDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("_MyAllowSubdomainPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
