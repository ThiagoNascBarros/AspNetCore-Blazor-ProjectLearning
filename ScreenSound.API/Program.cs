using Microsoft.EntityFrameworkCore;
using ScreenSound.Data;
using ScreenSound.Domain;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:ScreenSoundDB"]!;
builder.Services.AddDbContext<ScreenSoundContext>(options =>
    options
        .UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0)),
            b => b.MigrationsAssembly("ScreenSound.API"))
        .UseLazyLoadingProxies());

builder.Services.AddScoped<DAL<Artist>>();
builder.Services.AddScoped<DAL<Song>>();
builder.Services.AddScoped<DAL<Genre>>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(options =>
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
