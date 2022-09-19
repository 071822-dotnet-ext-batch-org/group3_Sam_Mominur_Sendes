using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RepoLayer;
using ModelLayer;
using BusinessLayer;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//Adding CORS-----------------------------
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";// gotten from Microsoft Docs to allow cors to all origins with a url

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

var ConnString = builder.Configuration["_AppSecrets:ConnectionString"];//from secrets.json
//END of CORS



//Adding Interface Dependencies-------------
builder.Services.AddScoped<IADO_ACCESS, ADO_ACCESS>();
builder.Services.AddScoped<IUser_BusinessLayer, User_BusinessLayer>();

builder.Services.AddScoped<IADO_PRODUCTS_ACCESS, ADO_PRODUCTS_ACCESS>();
builder.Services.AddScoped<IProduct_BusinessLayer, Product_BusinessLayer>();

builder.Services.AddScoped<IADO_ORDERS_ACCESS, ADO_ORDERS_ACCESS>();
builder.Services.AddScoped<IOrder_BusinessLayer, Order_BusinessLayer>();


builder.Services.AddScoped<IVerifyAnswers, VerifyAnswers>();



//END OF INTERFACE DEPENDENCIES


//Adding Authentication-----------------
builder.Services.AddAuthentication(options =>
{
    //Needs APS.Core JWTBearer Package
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["_AppSecrets:Auth0Domain"],
        ValidAudience = builder.Configuration["_AppSecrets:Auth0Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["_AppSecrets:Auth0SecretKey"]))
    };
});

//Adding Authorization-----------------
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:user", p =>
    p.RequireAuthenticatedUser()
    .RequireClaim("permission", "read:user"));
});


//END OF AUTHORIZATION










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
app.UseCors(MyAllowSpecificOrigins);//CORS ADDED HERE
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

