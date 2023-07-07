using Microsoft.EntityFrameworkCore;
using TodoApp.Backend.Data;
using TodoApp.Backend.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoAppBackendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoAppBackendContext") ?? throw new InvalidOperationException("Connection string 'TodoAppBackendContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
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
