using flowers_web.Service;
using flowers_web.Service.Config;
using flowers_web.Service.User;
using flowers_web.Service.Order;
using flowers_web.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var CorsPolicy = "_CorsPolicy";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination");
                      });
});

// 注册 AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));
// 注册JWT
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
// 注册 Service 层服务
builder.Services.AddTransient<IFlowersService,FlowersService>();
builder.Services.AddTransient<IUserServices, UserService>();
builder.Services.AddTransient<IOrderService,OrderService>();
builder.Services.AddTransient<ICustomerJWRService,CustomerJWRService>();

#region jwt校验
{
    JWTTokenOptions tokenOptions = new JWTTokenOptions();
    builder.Configuration.Bind("JWTTokenOptions", tokenOptions);
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,// 是否验证失效时间
                ValidateIssuerSigningKey = true,
                ValidAudience = tokenOptions.Audience,
                ValidIssuer = tokenOptions.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
            };
        });
}
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(CorsPolicy);

app.UseAuthorization();
app.UseAuthorization();


app.MapControllers();

app.Run();
