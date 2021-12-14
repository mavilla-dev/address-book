using AddressBook.Data;
using AddressBook.Domain;

var localhostCors = "localhost";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InjectDomain();
builder.Services.InjectData();
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: localhostCors, builder =>
  {
    builder.WithOrigins("http://localhost:3000").AllowAnyHeader();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(localhostCors);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
