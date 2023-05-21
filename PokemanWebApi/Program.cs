using Microsoft.EntityFrameworkCore;
using PokemanWebApi.Data;
using PokemanWebApi.Interfaces;
using PokemanWebApi.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

//Add it to solve for many to many relationships for reviewer 
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// auto wireing autoMapper model <--> modelDTO
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// auto wireing repository layer
builder.Services.AddScoped<IPokeman,PokemanRepository>();
builder.Services.AddScoped<ICatagory,CatagoryRepository>();
builder.Services.AddScoped<ICountry,CountryRepository>();
builder.Services.AddScoped<IOwner,OwnerRepository>();
builder.Services.AddScoped<IReview,ReviewRepository>(); 
builder.Services.AddScoped<IReviewer,ReviewerRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
