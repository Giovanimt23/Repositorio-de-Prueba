using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoSistemaTransporte.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.DataAccess.Configuracion
{
    public class MarcaConfiguracion : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.Property(m => m.Id)
             .HasColumnName("IdMarca");

            builder.Property(m => m.Descripcion)
                .HasMaxLength(100);

            builder.Property(m => m.UrlImagen)
                .HasMaxLength(500);

            var lista = new List<Marca>
            {
                new() { Id = 1, Descripcion = "Toyota",UrlImagen = "link" ,TipovehiculoId = 1,UsuarioCreacion ="administrador", UsuarioModificacion = "administrador"},
                new() { Id = 2, Descripcion = "Kia",UrlImagen = "link" , TipovehiculoId = 1,UsuarioCreacion ="administrador", UsuarioModificacion = "administrador"},
                new() { Id = 3, Descripcion = "Hyunday", UrlImagen = "link" ,TipovehiculoId = 1,UsuarioCreacion ="administrador", UsuarioModificacion = "administrador"}
            };
            builder.HasData(lista);
        }
    }
}
