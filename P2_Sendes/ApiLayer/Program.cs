using BusinessLayer;
using RepoLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserAuthentication, UserAuthentication>();
builder.Services.AddScoped<IADO_Access, ADO_Access>();
builder.Services.AddScoped<IUserProfileBL, UserProfileBL>();
builder.Services.AddScoped<IProduct_BusinessLayer, Product_BusinessLayer>();
builder.Services.AddCors((options) =>
{
    options.AddPolicy(name: "allowALL", policy1 =>
    {
        policy1.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();//For the policy, allow ANY of these things
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();//Cors must be within Route/Redirection and Authorization
app.UseAuthorization();


app.MapControllers();

app.Run();
