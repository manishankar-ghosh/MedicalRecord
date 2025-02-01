using Appointment.Application.Queries;
using Appointment.Application.Handlers;
using Appointment.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using RepositoryLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppointmentDbContext>(options =>
{
    string conStr = builder.Configuration.GetConnectionString("AppointmentDb")!;
    options.UseSqlServer(conStr);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  
builder.Services.AddScoped<DbContext, AppointmentDbContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllAppointmentsQueryHandler>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


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
