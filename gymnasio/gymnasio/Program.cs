
using Contracts;
using gymnasio.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

#region extension services methods
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
#endregion  
builder.Services.Configure<ApiBehaviorOptions>(options =>
{           
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers(
    config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
    }
).AddXmlDataContractSerializerFormatters()
 .AddCustomCSVFormatter()
 .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);//it is used to route the incoming request to the class library that contains the controllers

var app = builder.Build();

#region extension application methods
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
#endregion

if (!app.Environment.IsDevelopment()) app.UseHsts();
//app.UseDeveloperExceptionPage();


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
