using FluentValidation;
using FluentValidation.AspNetCore;
using learn_aspcore_webapi_net6.Data;
using learn_aspcore_webapi_net6.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped(typeof(IRegionRepository), typeof(RegionRepository));
builder.Services.AddScoped(typeof(IWalksRepository), typeof(WalksRepository));
builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenHandler, learn_aspcore_webapi_net6.Repositories.TokenHandler>();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddSwaggerGen(c =>
{
    //Bearer ��scheme����
    var securityScheme = new OpenApiSecurityScheme()
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        //���������ͷ��
        In = ParameterLocation.Header,
        //ʹ��Authorizeͷ��
        Type = SecuritySchemeType.Http,
        //����Ϊ�� bearer��ͷ
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme,
        }
    };

    //�����з�������Ϊ����bearerͷ����Ϣ
    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] {} }
    };

    //ע�ᵽswagger��
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddDbContext<NZWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConn"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
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