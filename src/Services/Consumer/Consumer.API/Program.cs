using Consumer.API.Data;
using Microsoft.EntityFrameworkCore;
using Consumer.API.Repository;
using Consumer.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDbContext<ConsumerDbContext>(option =>
    {
        string userName = null;

        if (builder.Environment.IsProduction())
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_PolicyAdmin");
            if (connectionString is null)
                option.UseInMemoryDatabase("ConsumerDB");
            else
                option.UseSqlServer(connectionString);
            return;
        }

        if (OperatingSystem.IsLinux())
        {
            userName = Environment.GetEnvironmentVariable("USERNAME")
            ?? throw new Exception("env variable USERNAME not found");
        }
        else if (OperatingSystem.IsWindows())
        {
            userName = Environment.GetEnvironmentVariable("COMPUTERNAME")
             ?? throw new Exception("env variable USERNAME not found");
        }

        if (userName is null) throw new Exception("userName is null");

        option.UseSqlServer(builder
            .Configuration
            .GetConnectionString($"{userName}ConsumerDB"));
    });

builder
    .Services
    .AddScoped<IConsumerRepository, ConsumerRepository>();

builder
    .Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder
    .Services
    .AddControllers();

builder
    .Services
    .AddEndpointsApiExplorer();

builder
    .Services
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DocumentTitle = builder.Configuration["ApplicationName"]);
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
