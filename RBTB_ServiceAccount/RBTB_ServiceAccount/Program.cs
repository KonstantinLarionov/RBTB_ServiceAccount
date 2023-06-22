using System.Text.Json.Serialization;

using RBTB_ServiceAccount.Application;
using RBTB_ServiceAccount.Database;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions( o =>
    {
        o.JsonSerializerOptions.Converters.Add( new JsonStringEnumConverter() );
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    } );

builder.Services.AddInfrastructureDataBase( builder.Configuration );
builder.Services.AddApplication();

#region Swagger Configuration

builder.Services.AddSwaggerGen( swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc( "v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "RBTB_ServiceAccount API",
        Description = "Список всех запросов сервиса RBTB_ServiceAccount"
    } );
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition( "Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    } );
    swagger.AddSecurityRequirement( new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    } );
} );
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI( c =>
{
    c.SwaggerEndpoint( "/swagger/v1/swagger.json", "RBTB_ServiceAccount" );
    c.RoutePrefix = string.Empty;
} );

app.MapControllers();

app.Run();