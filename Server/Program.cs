using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PoryectoSistemaTransporte.Client;
using PoryectoSistemaTransporte.Server.Services;
using ProyectoSistemaTransporte.DataAccess;
using ProyectoSistemaTransporte.DataAccess.Data;
using ProyectoSistemaTransporte.Repositorio.Implementaciones;
using ProyectoSistemaTransporte.Repositorio.Interfacces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

builder.Services.AddTransient<IConductorRepositorio, ConductorRepositorio>();
builder.Services.AddTransient<IVehiculoRepositorio, VehiculoRepositorio>();
builder.Services.AddTransient<IRegistroVehicularRepositorio, RegistroVehicularRepositorio>();
builder.Services.AddTransient<IModeloRepositorio, ModeloRepositorio>();
builder.Services.AddTransient<IMarcaRepositorio,MarcaRepositorio>();
builder.Services.AddTransient<ITipoVehiculoRepositorio, TipoVehiculoRepositorio>();
builder.Services.AddTransient<IUserSerivce,UserService>();


builder.Services.AddTransient<IFileUploader, FileUploader>();

//DbContext para la conexion(el archivo de conexion se le da un nombre)
builder.Services.AddDbContext<SistemaTrasnporteDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionTransporte"));
});

// Configuramos ASP.NET Identity Core
builder.Services.AddIdentity<IdentityUsuarioTransporte, IdentityRole>(policies =>
    {
        policies.Password.RequireDigit = false;
        policies.Password.RequireLowercase = true;
        policies.Password.RequireUppercase = true;
        policies.Password.RequireNonAlphanumeric = false;
        policies.Password.RequiredLength = 8;

        policies.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<SistemaTrasnporteDbContext>()
    .AddDefaultTokenProviders();

//Configuramos el contexto de la segurid aPI

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ??
                                           throw new InvalidOperationException("No se configuro el SecretKey"));

    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// Autenticacion
app.UseAuthentication();
// Autorizacion
app.UseAuthorization();




//app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


using (var scope = app.Services.CreateScope())
{
    await UsuarioDataSeeder.Seed(scope.ServiceProvider);
}

app.Run();
