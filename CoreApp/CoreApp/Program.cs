using CoreApp.Data;
using CoreApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("secret.json", optional: false, reloadOnChange: true);
// Add services to the container.
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddDbContext<CoreAppDbContext>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
