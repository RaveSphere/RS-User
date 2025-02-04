using Application;
using Application.Interfaces;
using Application.Services;
using Sql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IVaultService>(provider =>
    new VaultService(
        Environment.GetEnvironmentVariable("VAULT_ADDR"),
        Environment.GetEnvironmentVariable("VAULT_ROLE"),
        File.ReadAllText("/var/run/secrets/kubernetes.io/serviceaccount/token")
    ));

// Add Services
builder.Services
    .AddUserServiceDb()
    .AddApplicationServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
