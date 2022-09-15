var builder = WebApplication.CreateBuilder(args);

/*var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";// gotten from Microsoft Docs to allow cors to all origins with a url
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                      });
 });
*/
string MyAllowAllOrigins = "_myAllowAllOrigins";
builder.Services.AddCors( options =>
{
    options.AddPolicy( name: MyAllowAllOrigins,
    builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});




//var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

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
//app.UseCors(MyAllowSpecificOrigins);
app.UseCors(MyAllowAllOrigins);


app.UseAuthorization();

app.MapControllers();

app.Run();
