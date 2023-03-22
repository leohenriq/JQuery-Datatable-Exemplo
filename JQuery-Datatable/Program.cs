using JQuery_Datatable;
using Microsoft.EntityFrameworkCore;
using System;
using JQuery_Datatable.InMemoryData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatatableContext>(opt => opt.UseInMemoryDatabase("Escola"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Popular InMemoryDb
    using var scope = app.Services.CreateScope();
    await using var context = scope.ServiceProvider.GetRequiredService<DatatableContext>();
    context.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
