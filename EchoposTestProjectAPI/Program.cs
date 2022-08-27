using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Abstract;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------Service-------------------- /

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddScoped<IProductService, ProductManager>();


// ----------------DAL------------------ /
builder.Services.AddScoped(typeof(IRepositoryDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductDal, ProductRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
