using Microsoft.EntityFrameworkCore;
using web_api_permissions.Infrastructure;
using web_api_permissions.Infrastructure.Repositories;
using web_api_permissions.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


ServiceProvider provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<PermissionsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PermissionContext")));

builder.Services.AddScoped<PermisoRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IGetPermissionsService, GetPermissionsService>();
builder.Services.AddScoped<IModifyPermissionService, ModifyPermissionService>();
builder.Services.AddScoped<IRequestPermissionService, RequestPermissionService>();

//builder.Services.AddSingleton<IElasticsearchClient, ElasticsearchClient>();

//var elasticsearchClient = provider.GetService<IElasticsearchClient>();
//elasticsearchClient.CreateIndexAsync().Wait();

builder.Services.AddCors(opciones =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
     
    opciones.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
