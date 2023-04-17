using InoviceProject.Models;
using Microsoft.EntityFrameworkCore;
using InoviceProject.Services.Interface;
using InoviceProject.Services.Implementation;
using InoviceProject.BL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductReceivedStockRepository, ProductReceivedStockRepository>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IOrder_detailsRepository, Order_detailsRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInvoiceDetailsRepository, InvoiceDetailsRepository>();
builder.Services.AddScoped<IInvoiceProductRepository, InvoiceProductRepository>();
builder.Services.AddScoped<IInovicePaymentRepository, InovicePaymentRepository>();
builder.Services.AddScoped<ICompanyDetailsRepository, CompanyDetailsRepository>();
builder.Services.AddScoped<IProductReceivedItemsRepository, ProductReceivedItemsRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InvoiceDBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
         
builder =>
        {
            builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();
//app.UseCors();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
