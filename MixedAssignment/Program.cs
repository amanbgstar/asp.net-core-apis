using Microsoft.EntityFrameworkCore;
using MixedAssignment.Domain.Context;
using MixedAssignment.Domain.Models.Settings;
using MixedAssignment.Mapper;
using MixedAssignment.Repository.UserRepo;
using MixedAssignment.Service.UserService;
using MixedAssignment.Service.Mail;
using MixedAssignment.Service.OtpService;
using MixedAssignment.Repository.OtpRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using MixedAssignment.Repository.ProductRepo;
using MixedAssignment.Service.ProductService;
using MixedAssignment.Repository.CartRepo;
using MixedAssignment.Service.CartService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

//twilio set
Environment.SetEnvironmentVariable("Sid", "AC07f8e23fdab85e5550984b4f6f7e9324");
Environment.SetEnvironmentVariable("Token", "37ba5540a1141533622292c5c7f554cb");

// Add services to the container.

builder.Services.AddDbContext<UserContext>(options =>
options.
UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")
));

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOtpService, OtpService>();

builder.Services.AddTransient<IMailServices, MailService>();
builder.Services.AddScoped<IOtpRepo, OtpRepo>();


builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddTransient<ICartService, CartService>();


builder.Services.AddAutoMapper(typeof(UserProfile));

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
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
