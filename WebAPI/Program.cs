using Core.CrossCuttingConcerns.Exceptions.Extensions;
using RentACar.Application;
using RentACar.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

//builder.Services.AddDistributedMemoryCache(); //Cacheleme

builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379"); 


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

//if(app.Environment.IsProduction()) //development'ta son kullan�c� gibi davranmamas� i�in
app.ConfigureCustomExceptionMiddleware(); //b�t�n proje i�in try-catch �al��t�r�r.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
