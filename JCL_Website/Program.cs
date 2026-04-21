using JCL_Website.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// allows the website to access the database connection string found in appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// makes database work i think
builder.Services.AddTransient<ProductRepository, EfProductRepository>();
builder.Services.AddTransient<OrderRepository, EfOrderRepository>();

builder.Services.AddScoped<CartRepository>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//creates a new session
builder.Services.AddMemoryCache();
builder.Services.AddSession();


var app = builder.Build();

// Create all of the products for the database here
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Apply migrations automatically
    context.Database.Migrate();

    //only create the product if it doesn't exist yet
    if (!context.Products.Any(p => p.name == "JCL Headset"))
    {
        context.Products.Add(new Product
        {
            name = "JCL Headset",
            price = 59.99f,
            category = "Headphones",
            description = "Audio device for gamers.",
            imageSrc = "Logoless_Headset.png"
        });

    }
    if (!context.Products.Any(p => p.name == "JCL Headphones"))
    {
        context.Products.Add(new Product
        {
            name = "JCL Headphones",
            price = 69.99f,
            category = "Headphones",
            description = "Sound device for your ears.",
            imageSrc = "JCL_Headset.png"
        });

    }
    if (!context.Products.Any(p => p.name == "JCL Earbuds"))
    {
        context.Products.Add(new Product
        {
            name = "JCL Earbuds",
            price = 49.95f,
            category = "Earbuds",
            description = "Small & easy to carry audio device",
            imageSrc = "JCL_Earbuds.png"
        });

    }
    if (!context.Products.Any(p => p.name == "JCL Speakers"))
    {
        context.Products.Add(new Product
        {
            name = "JCL Speakers",
            price = 249.99f,
            category = "Speakers",
            description = "Audio device for gatherings.",
            imageSrc = "Logoless_Speakers.png"
        });

    }
    if (!context.Products.Any(p => p.name == "JCL Comfy Headphones"))
    {
        context.Products.Add(new Product
        {
            name = "JCL Comfy Headphones",
            price = 74.99f,
            category = "Headphones",
            description = "Audio Device for travellers.",
            imageSrc = "Logoless_Headphones.png"
        });

    }
    context.SaveChanges();
    
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// MAP ROUTES HERE
// The controller name is both the name of a controller file (ex: HomeController)
// AND the name of a view folder (ex: Views/Home) or else it won't work
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "shoppingCart",
    pattern: "shoppingCart",
    defaults: new { controller = "Cart", action = "Index"});



app.UseSession();

app.Run();
