using System.Text;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Registering controllers and API endpoints.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuring Swagger for API documentation.
builder.Services.AddSwaggerGen(SwaggerConfig =>
{
    // Creating a Swagger document.
    SwaggerConfig.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Adding JWT Authentication definition to Swagger.
    // This allows Swagger UI to send the JWT token in the Authorization header.
    SwaggerConfig.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    // Telling SwaggerUI that the API uses Bearer(JWT) authentication so i don't need to add the Bearer infront of pasted token
    SwaggerConfig.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});


builder.Services.AddApplication().AddInfrastructure();

// Configuring JWT Bearer authentication.
builder.Services.AddAuthentication(options =>
{
    // Setting the schemes to JWT Bearer.
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Setting the parameters for validating incoming JWT tokens.
    options.TokenValidationParameters = new TokenValidationParameters
    {
        
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,       
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        // Setting signing key from the configuration.
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
    };
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();
app.Run();
