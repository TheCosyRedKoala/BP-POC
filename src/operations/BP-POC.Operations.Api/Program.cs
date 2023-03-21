using BP_POC.Operations.Services;
using BP_POC.Persistence;
using Microsoft.EntityFrameworkCore;
using BP_POC.Operations.Api.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    // Add controllers
builder.Services.AddControllers();
    // Add REST services
builder.Services.AddRestServices();
    // SignalR
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

// Swagger | OAS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.DeclaringType is null ? $"{type.Name}" : $"{type.DeclaringType?.Name}.{type.Name}");
    options.EnableAnnotations();
});

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer
    (
        builder.Configuration.GetConnectionString("SqlServer")
    );
});

var app = builder.Build();

// Response Compression
app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Endpoint mapping
    // REST
app.MapControllers();
    // Hubs
app.MapHub<PrinterHub>("/printerhub");

app.Run();
