using AutoMapper;
using Fiap.Api.WasteManagementApplication.Data.Context;
using Fiap.Api.WasteManagementApplication.Data.Repository;
using Fiap.Api.WasteManagementApplication.Models;
using Fiap.Api.WasteManagementApplication.Services;
using Fiap.Api.WasteManagementApplication.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

#region MySqlDatabase initializing
var connectionString = builder.Configuration.GetConnectionString("MySqlDatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(connectionString,new MySqlServerVersion(new Version(8, 3, 0))));
#endregion

#region Repositorys DI
builder.Services.AddScoped<IGarbageCollectionRepository, GarbageCollectionRepository>();
#endregion

#region Services DI
builder.Services.AddScoped<IGarbageCollectionService, GarbageCollectionService>();
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<GarbageCollection, GarbageCollectionViewModel>();

    c.CreateMap<CreateGarbageCollectionViewModel, GarbageCollection>();
    c.CreateMap<UpdateGarbageCollectionViewModel, GarbageCollection>();
    c.CreateMap<GarbageCollectionViewModel, GarbageCollection>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region TokemJWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
