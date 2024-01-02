using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using OdataInclude.Data;
using OdataInclude.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Book>("Books");

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Odata;Integrated Security=True"));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Initialize(context);

}




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
