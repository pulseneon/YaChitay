using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Data.Repositories.Repository;
using YaChitay.Entities;
using YaChitay.Entities.Repository;
using YaChitay.Mapper;
using YaChitay.Services.Interface;
using YaChitay.Services.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YaChitayContext") ?? throw new InvalidOperationException("Connection string 'YaChitayContext' not found.")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IGenresRepository, GenresRepository>();

builder.Services.AddScoped<AuthorsService>();
builder.Services.AddScoped<BooksService>();

builder.Services.AddSingleton<SelectionBooksCache>();
builder.Services.AddHostedService<SelectionBooksService>();

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
app.UseEndpoints(endpoints => endpoints.MapRazorPages());
app.MapRazorPages();

app.Run();
