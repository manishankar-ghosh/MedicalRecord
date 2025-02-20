using Microsoft.EntityFrameworkCore;
using Patient.Infrastructure.Database;
using RepositoryLibrary;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PatientDbContext>(options =>
{
    string conStr = builder.Configuration.GetConnectionString("PatientDb")!;
    options.UseSqlServer(conStr);
});
builder.Services.AddScoped<DbContext, PatientDbContext>();
//builder.Services.AddScoped<IRepository, IRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(Program));
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
