using Hr.LeaveManagement.Application;
using Hr.LeaveManagement.Infrastructure;
using Hr.LeaveManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurationInfrastrutureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureApplicationServices();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
