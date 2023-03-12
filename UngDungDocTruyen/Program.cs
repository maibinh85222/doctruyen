using Microsoft.EntityFrameworkCore;
using UngDungDocTruyen.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//-------------viết API------------
builder.Services.AddCors(option => option.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// đăng ký 
builder.Services.AddDbContext<bookStoreContext>(options =>
 {
     options.UseSqlServer(builder.Configuration.GetConnectionString("bookStore"));
 });


//đăng ký

//-------------Viết API--------------------


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
