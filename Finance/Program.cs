using Finance.Endpoints;
using Finance_console;
using FinanceManagement.Shared.Data.DB;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles  );

builder.Services.AddDbContext<FinanceContext>();
builder.Services.AddTransient<DAL<Conta>>();
builder.Services.AddTransient<DAL<Transacao>>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndpointsConta();
app.AddEndpointsTransacao();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
