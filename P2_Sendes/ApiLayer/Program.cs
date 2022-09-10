using BusinessLayer;
using RepoLayer;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.SetBasePath(
    Directory.GetCurrentDirectory()).AddJsonFile("secrets.json");
var ConnString = builder.Configuration["ConnectionString: EcomProjectAPIDB"];

builder.Services.AddScoped<IUserAuthentication, UserAuthentication>();
builder.Services.AddScoped<IADO_Access, ADO_Access>();
builder.Services.AddScoped<IUserProfileBL, UserProfileBL>();
builder.Services.AddScoped<IProduct_BusinessLayer, Product_BusinessLayer>();
builder.Services.AddCors((options) =>//For this options we're gonna have a function 
{
    options.AddPolicy(name: "allowAll", policy1 =>//in the function, the options adds a policy with a name and policy function
    {
        policy1.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        //The function for the policy runs these methods to allow these conditions for each request permission
    });
});


var app = builder.Build();
//TODO add the mechanism to hide connection string
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("allowALL");//Cors must be within Route/Redirection and Authorization
app.UseAuthorization();


app.MapControllers();

app.Run();
