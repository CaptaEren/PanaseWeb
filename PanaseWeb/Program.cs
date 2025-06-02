using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Services;
using PanaseWeb.Services.Interfaces;
using AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Baðlantýsý
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

// 2. Razor Pages desteði
builder.Services.AddRazorPages();

// 3. AutoMapper Profilleri
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// 4. Servisleri DI Konteynerine Ekle
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPsychologistService, PsychologistService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ITherapyNoteService, TherapyNoteService>();
builder.Services.AddScoped<ITherapySessionService, TherapySessionService>();
builder.Services.AddScoped<IResourceService, ResourceService>();

// 5. Swagger ve API istemiyorsan ekleme (isteðe baðlý)
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// 6. Migration’larý otomatik uygula
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiContext>();
    db.Database.Migrate();
}

// 7. HTTP Pipeline Yapýlandýrmasý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();  // Razor Pages için gerekmez
    // app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 8. Razor Pages rotasýný tanýmla
app.MapRazorPages();

app.Run();
