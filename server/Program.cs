using DocumentArchiveWebAPI.Controllers.Services;
using DocumentArchiveWebAPI.Interface;
using DocumentArchiveWebAPI.Models;	
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ElectronicDocumentArchiveManagementContext>
	(context => context.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<,>();
//builder.Services.AddTransient <,> ();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication
	(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
	config => 
	{
		config.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
					builder.Configuration.GetSection("SecurityKeys:Token").Value!
						)),
			ValidateIssuer = false,
			ValidateAudience = false,
		};
	});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
	opt =>
	{
		opt.AddSecurityDefinition(
			"oauth2", new OpenApiSecurityScheme
			{
				Description = "Auth standart ",
				In = ParameterLocation.Header,
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey
			});
		opt.OperationFilter<SecurityRequirementsOperationFilter>();
	});

builder.Services.AddCors(
		config =>
		{
			config.AddPolicy(
				"Allow",
				policy =>
				{
					policy
					.SetIsOriginAllowed((string origin) => true)
					.AllowCredentials()
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
		});

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("Allow");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();