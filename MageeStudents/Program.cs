using Microsoft.EntityFrameworkCore;
using MVC6Crud.Data;
using MVC6Crud.Database;
using MVC6Crud.Interfaces;
using MVC6Crud.Service;

var builder = WebApplication.CreateBuilder(args);

////// add swagger for API testing
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
//});


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
    //// Enable middleware to serve generated Swagger as a JSON endpoint.
    //app.UseSwagger();
    //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    //// specifying the Swagger JSON endpoint.
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //});


    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("MVC6CrudConnetionString")
//        )
//    );

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
