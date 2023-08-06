using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Data.Repositories.Repository;
using YaChitay.Entities.Cache;
using YaChitay.Entities.Repository;
using YaChitay.Mapper;
using YaChitay.Services.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddLogging();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YaChitayContext") ?? throw new InvalidOperationException("Connection string 'YaChitayContext' not found.")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBookImagesRepository, BookImagesRepository>();
builder.Services.AddScoped<IGenresRepository, GenresRepository>();

builder.Services.AddScoped<AuthorsService>();
builder.Services.AddScoped<BooksService>();

builder.Services.AddSingleton<BooksOfDayCache>();
builder.Services.AddSingleton<NewBooksCache>();
builder.Services.AddSingleton<PopularBooksCache>();
builder.Services.AddHostedService<UpdateBooksOfDayService>();
builder.Services.AddHostedService<UpdateNewBooksService>();
builder.Services.AddHostedService<UpdatePopularBooksService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints => {
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllers();
    });
app.MapRazorPages();

app.Run();
