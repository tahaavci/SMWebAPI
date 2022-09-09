using Microsoft.EntityFrameworkCore;
using SMWebApi.Context;
using SMWebApi.Repository.Implementation;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Implementations;
using SMWebApi.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ISessionRepository,SessionRepository>();


builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();


builder.Services.AddScoped<ISettlementService, SettlementService>();
builder.Services.AddScoped<ISettlementRepository, SettlementRepository>();


builder.Services.AddScoped<IFlatService, FlatService>();
builder.Services.AddScoped<IFlatRepository, FlatRepository>();


builder.Services.AddScoped<IFlatUserService, FlatUserService>();
builder.Services.AddScoped<IFlatUserRepository, FlatUserRepository>();


builder.Services.AddScoped<IDebtService, DebtService>();
builder.Services.AddScoped<IDebtRepository, DebtRepository>();


builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--------------------------------------
builder.Services.AddDbContext<DataContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


});


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
