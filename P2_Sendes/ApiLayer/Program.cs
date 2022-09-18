using BusinessLayer;
using RepoLayer;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";// gotten from Microsoft Docs to allow cors to all origins with a url
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

//Add authentication for Auth0 on the API side - Who the user sending a request is
//builder.Services.AddAuthentication(options =>
//{
//    //Needs APS.Core JWTBearer Package
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.Authority = builder.Configuration["Auth0:Domain"];
//    options.Audience = builder.Configuration["Auth0: Audience"];
//});


Console.WriteLine($"\n\n\n\t\t{builder.Configuration["Auth0:API_Issuer"]}\n\t\t{builder.Configuration["Auth0:ClientSecret"]}\n\n\n");
builder.Services.AddAuthentication(options =>
{
    //Needs APS.Core JWTBearer Package
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Auth0:API_Issuer"],
        ValidAudience = builder.Configuration["Auth0:API_Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth0:ClientSecret"]))
    };
});

//Auth0 Team Method for Authorization
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//    .AddCookie()
//    .AddOpenIdConnect("Auth0", options =>
//    {
//        //Set the Auth0 domain
//        options.Authority = $"{builder.Configuration["Auth0: Domain"]}";

//        //Configure Auth0 credentials
//        options.ClientId = builder.Configuration["Auth0:ClientId"];
//        options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];

//        //Set Scrope - used during authentication to give access to things.
//        //Indicatiing API iwill use OIDC to authenticate user's token
//        options.Scope.Clear();
//        options.Scope.Add("openid");

//        //Set issuer - to say we are using Auth0
//        options.ClaimsIssuer = "Auth0";
//    });


//Add authorization for Auth0 - What a user is ALLOWED to do
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:user", p =>
    p.RequireAuthenticatedUser()
    .RequireClaim("permission", "read:user"));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.SetBasePath
//    (
//        Directory.GetCurrentDirectory()
//    ).AddJsonFile("secrets.json").AddUserSecrets<Program>(true);

builder.Services.AddScoped<IUserAuthentication, UserAuthentication>();
builder.Services.AddScoped<IADO_Access, ADO_Access>();
builder.Services.AddScoped<IUserProfileBL, UserProfileBL>();
builder.Services.AddScoped<IProduct_BusinessLayer, Product_BusinessLayer>();
//builder.Services.AddCors((options) =>//For this options we're gonna have a function 
//{
//    options.AddPolicy(name: "allowAll", policy1 =>//in the function, the options adds a policy with a name and policy function
//    {
//        policy1.WithOrigins("https://localhost:7029").AllowAnyHeader().AllowAnyMethod();
//        //The function for the policy runs these methods to allow these conditions for each request permission
//    });
//});

var ConnString = builder.Configuration["ConnectionString:EcomProjectAPIDB"];

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors("allowALL");//Cors must be within Route/Redirection and Authorization
app.UseCors(MyAllowSpecificOrigins);

//Add Use Authentication from Auth0 builder
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
