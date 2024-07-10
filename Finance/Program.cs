using Finance_console;
using FinanceManagement.Shared.Data.DB;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles  );

var app = builder.Build();

app.MapGet("/", () =>
{
    var dal = new DAL<Conta>(new FinanceContext());

    return dal.Read();
});

app.Run();
