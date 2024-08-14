using CleanCode.Domain.Entities;
using CleanCode.Domain.Repositories;
using CleanCode.Infra;
using CleanCode.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureInfra(builder.Configuration);

builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
