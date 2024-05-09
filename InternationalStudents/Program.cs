using Microsoft.EntityFrameworkCore;
using InternationalStudents.Database;
using InternationalStudents.Interfaces;
using InternationalStudents.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// create EF dbContext
builder.Services.AddDbContextPool<StudentContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDatabase")));

// add dependency injection
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();

