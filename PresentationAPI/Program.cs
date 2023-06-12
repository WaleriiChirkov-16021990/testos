using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.ExperimentalData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(op =>
{
    op.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.

using (var serviceScope = app.Services.CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();
        await TestDataProvider.Provide(context, 100);
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "Непредвиденная ошибка миграции");
    }
}



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
