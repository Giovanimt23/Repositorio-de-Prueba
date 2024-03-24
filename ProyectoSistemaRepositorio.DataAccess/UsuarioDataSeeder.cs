

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PoryectoSistemaTransporte.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.DataAccess;

    public static class UsuarioDataSeeder
    {
            public static async Task Seed(IServiceProvider service)
            {
                // UserManager (Repositorio de Usuarios)
                var userManager = service.GetRequiredService<UserManager<IdentityUsuarioTransporte>>();
                // RoleManager (Repositorio de Roles)
                var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

                // Crear los roles
                var adminRole = new IdentityRole(Constantes.RolAdministrador);
                var clienteRole = new IdentityRole(Constantes.RolRegistrador);

                if (!await roleManager.RoleExistsAsync(Constantes.RolAdministrador))
                {
                    await roleManager.CreateAsync(adminRole);
                }

                if (!await roleManager.RoleExistsAsync(Constantes.RolRegistrador))
                {
                    await roleManager.CreateAsync(clienteRole);
                }

                // Creamos el usuario Administrador
                var adminUser = new IdentityUsuarioTransporte
                {
                    NombreCompleto = "Administrador del Sistema",
                    FechaNacimiento = DateTime.Parse("2000-06-06"),
                    PreguntaSecreta = "Chavo del 8",
                    RespuestaSecreta = "Soy chavo del 8",
                    Telefono = "965066921",
                    Direccion = "Av. La Floro MZ T2",
                    UserName = "admin",
                    Email = "ronygiovani343@gmail.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "passwor##D@12345");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Constantes.RolAdministrador);
                }
            }
    }

