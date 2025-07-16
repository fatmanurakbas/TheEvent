using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TheEvent.Context;
using TheEvent.DAL.Interfaces;
using TheEvent.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IVenueRepository, VenueRepository>();

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
