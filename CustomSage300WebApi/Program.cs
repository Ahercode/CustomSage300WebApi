using CustomSage300WebApi.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var workFlowConnection = builder.Configuration.GetConnectionString("WorkFlowConnection");
builder.Services.AddDbContext<SageDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<WorkFlowDbContext>(options => options.UseSqlServer(workFlowConnection));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "AhercodeWebAPI v1"));

app.UseHttpsRedirection();
app.UseCors(options=> {

    const string devUrl = "http://localhost:3000";
    const string devUrlBack = "http://localhost:5173/";
    const string productionEndUrl = "http://208.177.44.15/";
    const string sipEndpoint = "https://app.sipconsult.net";
    const string productionEndUrls = "https://208.177.44.15/";
    const string enpNew = "https://enp.sipconsult.net/";

    options.WithOrigins(devUrl, productionEndUrl, productionEndUrls, devUrlBack, sipEndpoint, enpNew)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseAuthorization();

app.MapControllers();

app.Run();