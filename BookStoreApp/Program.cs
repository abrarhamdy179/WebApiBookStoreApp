using BookStoreApp.Data;
using BookStoreApp.Repositories.AuthorRelationsRepo;
using BookStoreApp.Repositories.AuthorRepository;
using BookStoreApp.Repositories.BookRelationsRepo;
using BookStoreApp.Repositories.BookRepository;
using BookStoreApp.Repositories.SellerRelationsRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connect = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect));

builder.Services.AddScoped<IAuthorRelationsRepo, AuthorRelationsRepo>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddScoped<IBookRelationsRepo, BookRelationsDto>();
builder.Services.AddScoped<ISellerRelationsRepo, SellerRelationsRepo>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
