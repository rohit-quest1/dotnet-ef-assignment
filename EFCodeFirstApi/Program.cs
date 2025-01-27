using Microsoft.EntityFrameworkCore;
using EFCodeFirstApi.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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


void RollbackDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ShopContext>();
        dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Products', RESEED, 0);"); 
        dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Suppliers', RESEED, 0);");
        dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Categories', RESEED, 0);");
    }
}

// Call the rollback method if needed
// RollbackDatabase(); // Uncomment to execute rollback

app.Run();