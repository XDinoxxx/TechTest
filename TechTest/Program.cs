using ServiceReference;
using TechTest.Services;
using TechTest.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ICUTechClient>(sp =>
{
    return new ICUTechClient(ICUTechClient.EndpointConfiguration.IICUTechPort);
});

var app = builder.Build();

app.UseCors();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>           
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
