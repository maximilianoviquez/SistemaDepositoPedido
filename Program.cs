using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Obligatorio2_P3.DTO;
using Obligatorio2_P3.HttpAccess;
using Obligatorio2_P3.UseCases;
using Obligatorio2_P3.UseCases.Usuario;
using System.Text;
using System.Security.Claims;

namespace Obligatorio2_P3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped(typeof(IContextHttpLogin), provider => new RestContextLogin(
                builder.Configuration.GetConnectionString("UrlLogin")
            ));

            builder.Services.AddScoped(typeof(IContextHttpArticulo), provider => new RestContextArticulo(
                builder.Configuration.GetConnectionString("UrlArticulo"), new HttpContextAccessor()
            ));

            builder.Services.AddScoped(typeof(IContextHttpTipo), provider => new RestContextTipo(
                builder.Configuration.GetConnectionString("UrlTipoMovimiento"), new HttpContextAccessor()
            ));

            builder.Services.AddScoped(typeof(IContextHttpMovimiento), provider => new RestContextMovimiento(
                builder.Configuration.GetConnectionString("UrlMovimientoStock"), new HttpContextAccessor()
            ));

            builder.Services.AddScoped(typeof(IContextHttpUsuario), provider => new RestContextUsuario(
                builder.Configuration.GetConnectionString("UrlUsuario"), new HttpContextAccessor()
            ));

            builder.Services.AddScoped(typeof(IServicioArticulo), typeof(ServicioArticulo));
            builder.Services.AddScoped(typeof(IServicioTIpoMovimiento), typeof(ServicioTipoMovimiento));
            builder.Services.AddScoped(typeof(IServicioMovimientoStock), typeof(ServicioMovimientoStock));
            builder.Services.AddScoped(typeof(IServicioUsuario), typeof(ServicioUsuario));
            builder.Services.AddScoped(typeof(IServicioLogin<LoginDTO, UsuarioDTOread>), typeof(ServicioLogin));


            builder.Services.AddHttpContextAccessor();




            var claveSecreta = builder.Configuration.GetConnectionString("ClaveJWT");
            var claveBytes = Encoding.ASCII.GetBytes(claveSecreta);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(claveBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            // Configurar la autorizacion
            builder.Services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.AddPolicy("RolEncargado", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Encargado"));

            });




            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
