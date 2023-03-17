using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using RBTB_ServiceAccount.Application;
using RBTB_ServiceAccount.Database;

var builder = WebApplication.CreateBuilder(args);
string _specificCorsName = "CustomCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy
    (name: _specificCorsName, builder =>
    {
        builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
    });
});
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAplication(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddSwaggerGen(options=>
{options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Description = "RBTB",
    });
        
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BARS.BotWebApi");
    c.RoutePrefix = string.Empty;
});
app.MapControllers();

app.Run();