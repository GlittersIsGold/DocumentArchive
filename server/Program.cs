using DocumentArchiveWebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<ElectronicDocumentArchiveManagementContext>
	(context => context.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

//builder.Services.AddTransient<,>();
//builder.Services.AddScoped<,>();

builder.Services.AddAuthentication
	(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer
	(config => {
		config.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(
				System.Text.Encoding.UTF8.GetBytes(
					builder.Configuration.GetSection("SecurityKeys:JwtToken").Value!
						)),
			ValidateIssuer = false,
			ValidateAudience = false,
		};
	});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
	config =>
	{
		config.AddSecurityDefinition("Oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
		{
			Description = "Standart authentication",
			In = Microsoft.OpenApi.Models.ParameterLocation.Header,
			Name = "Authorization",
			Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
		});
		config.OperationFilter<SecurityRequirementsOperationFilter>();
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