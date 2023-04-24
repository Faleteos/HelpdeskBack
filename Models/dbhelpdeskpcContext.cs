using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HELPDESKPC.Models
{
    public partial class dbhelpdeskpcContext : DbContext
    {
        public dbhelpdeskpcContext()
        {
        }

        public dbhelpdeskpcContext(DbContextOptions<dbhelpdeskpcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adcr> Adcrs { get; set; } = null!;
        public virtual DbSet<Informe> Informes { get; set; } = null!;
        public virtual DbSet<Modulo> Modulos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<RemisionCab> RemisionCabs { get; set; } = null!;
        public virtual DbSet<RemisionDet> RemisionDets { get; set; } = null!;
        public virtual DbSet<Repuesto> Repuestos { get; set; } = null!;
        public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UF84PQ1\\SQLEXPRESS; Database=dbhelpdeskpc; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adcr>(entity =>
            {
                entity.HasKey(e => e.IdAdcr);

                entity.ToTable("adcr");

                entity.Property(e => e.IdAdcr).HasColumnName("id_adcr");

                entity.Property(e => e.Barrio)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("barrio");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Pais)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                //entity.HasOne(d => d.IdPersonaNavigation)
                //    .WithMany(p => p.Adcrs)
                //    .HasForeignKey(d => d.IdPersona)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_adcr_persona");
            });

            modelBuilder.Entity<Informe>(entity =>
            {
                entity.HasKey(e => e.IdInforme);

                entity.ToTable("informes");

                entity.Property(e => e.IdInforme)
                    .ValueGeneratedNever()
                    .HasColumnName("id_informe");

                entity.Property(e => e.DescInforme)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("desc_informe");

                entity.Property(e => e.EstadoInforme)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estado_informe");

                entity.Property(e => e.FechaInforme)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_informe");

                entity.Property(e => e.TipoInforme)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tipo_informe");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo);

                entity.ToTable("modulos");

                entity.Property(e => e.IdModulo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_modulo");

                entity.Property(e => e.Get)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("get")
                    .IsFixedLength();

                entity.Property(e => e.Getbyid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("getbyid")
                    .IsFixedLength();

                entity.Property(e => e.Mdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("mdelete")
                    .IsFixedLength();

                entity.Property(e => e.NameModul)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("name_modul");

                entity.Property(e => e.Post)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("post")
                    .IsFixedLength();

                entity.Property(e => e.Put)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("put")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__228148B01FDD504B");

                entity.ToTable("persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NumCel).HasColumnName("num_cel");

                entity.Property(e => e.NumDoc).HasColumnName("num_doc");

                entity.Property(e => e.PApellido)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("p_apellido");

                entity.Property(e => e.PNombre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("p_nombre");

                entity.Property(e => e.SApellido)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("s_apellido");

                entity.Property(e => e.SNombre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("s_nombre");

                entity.Property(e => e.TipoDoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tipo_doc")
                    .IsFixedLength();
            });

            modelBuilder.Entity<RemisionCab>(entity =>
            {
                entity.HasKey(e => e.IdRemision);

                entity.ToTable("remision_cab");

                entity.Property(e => e.IdRemision)
                    .ValueGeneratedNever()
                    .HasColumnName("id_remision");

                entity.Property(e => e.EstadoRemision)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado_remision");

                entity.Property(e => e.FechaRemision)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_remision");

                entity.Property(e => e.NumTicket).HasColumnName("num_ticket");
            });

            modelBuilder.Entity<RemisionDet>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.ToTable("remision_det");

                entity.Property(e => e.IdDetalle)
                    .ValueGeneratedNever()
                    .HasColumnName("id_detalle");

                entity.Property(e => e.IdRemision).HasColumnName("id_remision");

                entity.Property(e => e.IdTicket).HasColumnName("id_ticket");

                entity.Property(e => e.PosDetalle).HasColumnName("pos_detalle");

                //entity.HasOne(d => d.IdRemisionNavigation)
                //    .WithMany(p => p.RemisionDets)
                //    .HasForeignKey(d => d.IdRemision)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_remision_det_remision_cab");

                //entity.HasOne(d => d.IdTicketNavigation)
                //    .WithMany(p => p.RemisionDets)
                //    .HasForeignKey(d => d.IdTicket)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_remision_det_tickets");
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.HasKey(e => e.IdRepuesto);

                entity.ToTable("repuestos");

                entity.Property(e => e.IdRepuesto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_repuesto");

                entity.Property(e => e.CapRep)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cap_rep");

                entity.Property(e => e.Marca)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.StockRep).HasColumnName("stock_rep");

                entity.Property(e => e.TipoRep)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo_rep");

                entity.Property(e => e.ValorRep)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor_rep");
            });

            modelBuilder.Entity<RolesUsuario>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("roles_usuario");

                entity.Property(e => e.IdRol)
                    .ValueGeneratedNever()
                    .HasColumnName("id_rol");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.TipoRol)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tipo_rol");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio);

                entity.ToTable("servicios");

                entity.Property(e => e.IdServicio)
                    .ValueGeneratedNever()
                    .HasColumnName("id_servicio");

                entity.Property(e => e.EstadoServicio)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estado_servicio");

                entity.Property(e => e.NombServ)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomb_serv");

                entity.Property(e => e.ValorServicio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor_servicio");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket);

                entity.ToTable("tickets");

                entity.HasIndex(e => e.IdCaseTicket, "IX_tickets");

                entity.Property(e => e.IdTicket).HasColumnName("id_ticket");

                entity.Property(e => e.EstadoTicket)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estado_ticket");

                entity.Property(e => e.FechaTicket)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_ticket");

                entity.Property(e => e.IdCaseTicket).HasColumnName("id_case_ticket");

                entity.Property(e => e.IdInforme).HasColumnName("id_informe");

                entity.Property(e => e.IdRepuesto).HasColumnName("id_repuesto");

                entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.TipoTicket)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tipo_ticket");

                //entity.HasOne(d => d.IdInformeNavigation)
                //    .WithMany(p => p.Tickets)
                //    .HasForeignKey(d => d.IdInforme)
                //    .HasConstraintName("FK_tickets_informes");

              //  entity.HasOne(d => d.IdRepuestoNavigation)
                //    .WithMany(p => p.Tickets)
                  //  .HasForeignKey(d => d.IdRepuesto)
                    //.HasConstraintName("FK_tickets_repuestos");

              // entity.HasOne(d => d.IdServicioNavigation)
                  //  .WithMany(p => p.Tickets)
                  //  .HasForeignKey(d => d.IdServicio)
                   // .HasConstraintName("FK_tickets_servicios");

                //entity.HasOne(d => d.IdUsuarioNavigation)
                //    .WithMany(p => p.Tickets)
                //    .HasForeignKey(d => d.IdUsuario)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_tickets_usuarios");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.EstadoUsuario)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estado_usuario");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("password");

                //entity.HasOne(d => d.IdPersonaNavigation)
                //    .WithMany(p => p.Usuarios)
                //    .HasForeignKey(d => d.IdPersona)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_usuarios_persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
