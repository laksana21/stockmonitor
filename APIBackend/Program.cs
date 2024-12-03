using APIBackend;
using APIBackend.Core;
using APIBackend.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(
    x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                //.LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableSensitiveDataLogging()
                //.EnableDetailedErrors()
                );

builder.Services.AddTransient<IDomainService, DomainService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemFacade, ItemFacade>();
builder.Services.AddScoped<IPOSService, POSService>();
builder.Services.AddScoped<IPOSFacade, POSFacade>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<GeneralService>();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Upload")),
    RequestPath = "/resources"
});

using (var scope = app.Services.CreateScope())
{
    var dbContex = scope.ServiceProvider.GetRequiredService<DataContext>();

    if (!dbContex.Database.CanConnect())
    {
        throw new NotImplementedException("Cannot connect to database!");
    }
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
