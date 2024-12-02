using BookShop.Web.Middleware;
using BookShop.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddHelpers();
builder.Services.AddDataServices();
builder.Services.AddMappers();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<DatabaseSeedMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
