using Microsoft.EntityFrameworkCore;
using SalaryProject.DAL.EFCore.Contexts;
using SalaryProject.DAL.EFCore.Factories;
using SalaryProject.DAL.EFCore.Repositores;
using SalaryProject.Domain.Interfaces;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }); ;

var connectionString = builder.Configuration.GetConnectionString("SalaryDatabase");

builder.Services.AddDbContext<SalaryDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddSingleton<SalaryDbContextFactory>(new SalaryDbContextFactory(options =>
{
    options.UseSqlServer(connectionString);
}));

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject = new ConfigObject
        {
            ShowCommonExtensions = true
        };
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
