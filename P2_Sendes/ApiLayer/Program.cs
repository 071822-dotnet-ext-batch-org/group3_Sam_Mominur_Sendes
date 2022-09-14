using BusinessLayer;
using RepoLayer;
using System.Data.SqlClient;

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
// Add services to the container.

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
Console.WriteLine($"\n\n\tThis is a connection string test {ConnString}\n\n");


var app = builder.Build();
//TODO add the mechanism to hide connection string
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors("allowALL");//Cors must be within Route/Redirection and Authorization
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();


app.MapControllers();

app.Run();
