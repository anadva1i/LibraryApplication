using LibraryApplication.Core.Interfaces;
using LibraryApplication.Data;
using LibraryApplication.Data.Interfaces;
using LibraryApplication.Services;
using LibraryApplication.Services.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDbConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddMediatR(typeof(AddAuthorCommandHandler).Assembly);
//builder.Services.AddMediatR(typeof(AddBookCommandHandler));
//builder.Services.AddMediatR(typeof(DeleteBookCommandHandler));
//builder.Services.AddMediatR(typeof(DeleteAuthorCommandHandler));
//builder.Services.AddMediatR(typeof(GetBooksQueryHandler));
//builder.Services.AddMediatR(typeof(GetBooksByAuthorQueryHandler));
//builder.Services.AddMediatR(typeof(UpdateBookCommandHandler));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

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
