using CourseService.Gateway.Infrastrcuture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  
builder.Services.ConfigureOptionsBll(builder.Configuration)
    .AddScopedClients();

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
app.UseHttpsRedirection();
app.MapControllers();

app.Run();