using BuildWebAPI.Repository;
using BuildWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiVersioning(c => {
    c.AssumeDefaultVersionWhenUnspecified = true; //�w�]�����Ұ�
    c.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);//�]�w���n����
    c.ReportApiVersions= true;//�|��ܦ�����API�i��
});
//builder.Services.AddVersionedApiExplorer(c => {
//    c.GroupNameFormat = "'v'VVV";
//    c.SubstituteApiVersionInUrl = true;
//});
// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description = "JWT",
    //    Name = "Authorization",
    //    In = ParameterLocation.Header,
    //    Scheme = "Bearer"
    //});
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //{
    //    {
    //    new OpenApiSecurityScheme{
    //        Reference=new OpenApiReference{ Type=ReferenceType.SecurityScheme,Id="Bearer"},
    //        Scheme="oauth2",
    //        Name="Bearer",
    //        In = ParameterLocation.Header
    //        },
    //    new List<string>()
    //    }
    //});

    //c.SwaggerDoc("v1",new OpenApiInfo {  Version="�y�z����",Title = "���D",Description = "�y�z" });
    //c.SwaggerDoc("v2", new OpenApiInfo { Version = "�y�z����", Title = "���D", Description = "�y�z" });

});
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(c => {
    c.RequireHttpsMetadata = false;
    c.SaveToken = true;
    c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        //c.SwaggerEndpoint("/swagger/v1/swagger.json","DEVICE_V1");//�إ�API����1������
        //c.SwaggerEndpoint("/swagger/v2/swagger.json","DEVICE_V2");//�إ�API����2������
    });
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
