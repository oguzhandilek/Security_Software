using Business;
using Entity;
using Dal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityServices();
builder.Services.AddBusinessServices();
builder.Services.AddDalServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();

/*
option =>
{
option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    In = ParameterLocation.Header,
    Description = "Please enter a valid token",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "Bearer"
});
option.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        new string[]{}
    }
});
});
*/
/* Basic Authentication için geliştirilmiştir
builder.Services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOption, BasicAuthenticationHandler>("Basic", null);
*/

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(config =>
    {
        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            //Request'in ValidIssuer bilgisinin kontrol edilip edilmemesini ayarladığımız ksıım
            ValidateIssuer = true,
            //Request'in ValidAudience bilgisinin kontrol edilip edilmemesini ayarlar
            ValidateAudience = false,
            //Request'in IssuerSigningKey bilgisinin kontrol edilip edilmemesini ayarladığımız ksıım
            ValidateIssuerSigningKey = true,
            //Token'ın hangi sunucu tarafından oluşturulduğu bilgisi
            ValidIssuer = "jsga.edu.tr",
            //Token'a vereceğimiz özel bir bilgi. Request esnasında doğruluğunu kontrol edebilriiz
            ValidAudience = "client.jsga.edu.tr",
            //Token secret key(istediğimizi yazabiliriz)
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ne Mutlu Türküm Diyene - Mustafa Kemal Atatürk"))
        };
    });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .WithOrigins("https://localhost:7040")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
