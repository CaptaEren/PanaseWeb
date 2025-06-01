using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritaban� Ba�lant�s� Ekleme
builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null);
        }));

// 2. Geli�tirme ortam�nda hata sayfas�

var app = builder.Build();

// 3. Otomatik migration uygulama
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiContext>();
    db.Database.Migrate(); // Bekleyen migration'lar� uygular
}

// 4. HTTP Pipeline Konfig�rasyonu
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();