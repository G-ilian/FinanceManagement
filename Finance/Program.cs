using Finance.Endpoints;
using Finance_console;
using FinanceManagement.Shared.Data.DB;
using FinanceManagement.Shared.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles  );

builder.Services.AddDbContext<FinanceContext>();
builder.Services.AddTransient<DAL<Conta>>();
builder.Services.AddTransient<DAL<Transacao>>();
builder.Services.AddTransient<DAL<Investimentos>>();

// Identity
builder.Services
    .AddIdentityApiEndpoints<AccessUser>()
    .AddEntityFrameworkStores<FinanceContext>();

// Auth
builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Auth - apply
app.UseAuthorization();

// Endpoints
app.AddEndpointsConta();
app.AddEndpointsTransacao();
app.AddEndpointsInvestimento();

// Identity - Endpoints
app.MapGroup("auth").MapIdentityApi<AccessUser>().WithTags("Authorization");
app.MapPost("auth/logout", async ([FromServices] SignInManager<AccessUser> 
    signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Authorization");

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
