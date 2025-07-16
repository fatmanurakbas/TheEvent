using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TheEvent.Context;

var builder = WebApplication.CreateBuilder(args);

// 📌 1) DbContext DI Container'a ekleniyor
builder.Services.AddDbContext<TheEventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 📌 2) MVC servisini de ekle
builder.Services.AddControllersWithViews();

// 3️⃣ Bildirim servisi
//builder.Services.AddScoped<NotificationService>();

// 4️⃣ Cookie Authentication (login için)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";     // Giriş yapılmamışsa yönlendirilecek adres
        options.LogoutPath = "/Login/Logout";   // Çıkış adresi
        options.AccessDeniedPath = "/Login/AccessDenied"; // Yetki yoksa yönlendirme (opsiyonel)
    });
var app = builder.Build();
// 5️⃣ 404 error page middleware
app.UseStatusCodePagesWithReExecute("/ErrorPage/Page404");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
