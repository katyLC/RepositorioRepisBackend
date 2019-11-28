using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Data
{
    public partial class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Ciclo> Ciclo { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<Paper> Paper { get; set; }
//        public virtual DbSet<PaperAdicional> PaperAdicional { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<ProyectoAutor> ProyectoAutor { get; set; }
        public virtual DbSet<ProyectoKeyword> ProyectoKeyword { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLEXPRESS;Database=db_repositorio_upt;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__0FE822AAE7392EFD");

                entity.Property(e => e.IdAdministrador).HasColumnName("id_administrador");

                entity.Property(e => e.AdministradorApellido)
                    .IsRequired()
                    .HasColumnName("administrador_apellido")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AdministradorNombre)
                    .IsRequired()
                    .HasColumnName("administrador_nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumno__6D77A7F113B770B2");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.AlumnoApellidos)
                    .IsRequired()
                    .HasColumnName("alumno_apellidos")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AlumnoCodigoUniversitario)
                    .IsRequired()
                    .HasColumnName("alumno_codigo_universitario")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AlumnoNombre)
                    .IsRequired()
                    .HasColumnName("alumno_nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdCiclo).HasColumnName("id_ciclo");

                entity.HasOne(d => d.Ciclo)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.IdCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Alumno__id_ciclo__4D5F7D71");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new {e.LoginProvider, e.ProviderKey});

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.RoleId});

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.LoginProvider, e.Name});

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autor__5FC3872DD6D0110E");

                entity.Property(e => e.IdAutor).HasColumnName("id_autor");

                entity.Property(e => e.AutorNombreApellido)
                    .IsRequired()
                    .HasColumnName("autor_nombre_apellido")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.HasOne(d => d.IdAlumnoRepositorioNavigation)
                    .WithMany(p => p.Autor)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("FK__Autor__id_alumno__05D8E0BE");
            });

            modelBuilder.Entity<Ciclo>(entity =>
            {
                entity.HasKey(e => e.IdCiclo)
                    .HasName("PK__Ciclo__A78E2FA398F0406F");

                entity.Property(e => e.IdCiclo).HasColumnName("id_ciclo");

                entity.Property(e => e.CicloDescripcion)
                    .IsRequired()
                    .HasColumnName("ciclo_descripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__5D3F75028A7CAE4B");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.CursoNombre)
                    .IsRequired()
                    .HasColumnName("curso_nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdCiclo).HasColumnName("id_ciclo");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.HasOne(d => d.Ciclo)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Curso__id_ciclo__75A278F5");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Curso__id_perfil__76969D2E");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__86989FB2E2AC3FCD");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.EstadoDescripcion)
                    .IsRequired()
                    .HasColumnName("estado_descripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.IdKeyword)
                    .HasName("PK__Keyword__00A87CD6FCB8916E");

                entity.Property(e => e.IdKeyword).HasColumnName("id_keyword");

                entity.Property(e => e.KeywordDescripcion)
                    .IsRequired()
                    .HasColumnName("keyword_descripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paper>(entity =>
            {
                entity.HasKey(e => e.IdPaper)
                    .HasName("PK__Paper__3D957617A397DDD1");

                entity.Property(e => e.IdPaper).HasColumnName("id_paper");

                entity.Property(e => e.PaperResumen)
                    .IsRequired()
                    .HasColumnName("paper_resumen")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaperIntroduccion)
                    .IsRequired()
                    .HasColumnName("paper_introduccion")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaperAdicional>(entity =>
            {
                entity.HasKey(e => e.IdPaperAdicional)
                    .HasName("PK__PaperAdi__0CE54793712DD669");

                entity.Property(e => e.IdPaperAdicional).HasColumnName("id_paper_adicional");

                entity.Property(e => e.IdPaper).HasColumnName("id_paper");

                entity.Property(e => e.PaperAdicionalDetalle)
                    .IsRequired()
                    .HasColumnName("paper_adicional_detalle")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaperAdicionalTitulo)
                    .IsRequired()
                    .HasColumnName("paper_adicional_titulo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

//                entity.HasOne(d => d.Paper)
//                    .WithMany(p => p.PaperAdicional)
//                    .HasForeignKey(d => d.IdPaper)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__PaperAdic__id_pa__0C85DE4D");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfil__1D1C87687B778215");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.PerfilDescripcion)
                    .IsRequired()
                    .HasColumnName("perfil_descripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PerfilColor)
                    .HasColumnName("perfil_color")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__Profesor__159ED61774209BA4");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

                entity.Property(e => e.ProfesorApellido)
                    .IsRequired()
                    .HasColumnName("profesor_apellido")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProfesorEmail)
                    .IsRequired()
                    .HasColumnName("profesor_email")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProfesorNombre)
                    .IsRequired()
                    .HasColumnName("profesor_nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK__Proyecto__F38AD81D40D9B2C5");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdPaper).HasColumnName("id_paper");

                entity.Property(e => e.ProyectoDocumentoUrl)
                    .HasColumnName("proyecto_documento_url")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProyectoGithubUrl)
                    .IsRequired()
                    .HasColumnName("proyecto_github_url")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProyectoNombre)
                    .IsRequired()
                    .HasColumnName("proyecto_nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProyectoPortadaUrl)
                    .HasColumnName("proyecto_portada_url")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProyectoTema)
                    .IsRequired()
                    .HasColumnName("proyecto_tema")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto__id_cur__797309D9");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto__id_est__7B5B524B");

                entity.HasOne(d => d.Paper)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdPaper)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto__id_pap__7A672E12");
            });

            modelBuilder.Entity<ProyectoAutor>(entity =>
            {
                entity.HasKey(e => e.IdProyectoAutor)
                    .HasName("PK__Proyecto__525A78CB7FD663CC");

                entity.ToTable("Proyecto_Autor");

                entity.Property(e => e.IdProyectoAutor).HasColumnName("id_proyecto_autor");

                entity.Property(e => e.IdAutor).HasColumnName("id_autor");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.ProyectoAutor)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto___id_au__09A971A2");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.ProyectoAutor)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto___id_pr__08B54D69");
            });

            modelBuilder.Entity<ProyectoKeyword>(entity =>
            {
                entity.HasKey(e => e.IdProyectoKeyword)
                    .HasName("PK__Proyecto__57C3B55756DDC534");

                entity.ToTable("Proyecto_Keyword");

                entity.Property(e => e.IdProyectoKeyword).HasColumnName("id_proyecto_keyword");

                entity.Property(e => e.IdKeyword).HasColumnName("id_keyword");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.HasOne(d => d.IdKeywordNavigation)
                    .WithMany(p => p.ProyectoKeyword)
                    .HasForeignKey(d => d.IdKeyword)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto___id_ke__7F2BE32F");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.ProyectoKeyword)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proyecto___id_pr__7E37BEF6");
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PK__Solicitu__5C0C31F36E713714");

                entity.Property(e => e.IdSolicitud).HasColumnName("id_solicitud");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.Property(e => e.SolicitudDescripcion)
                    .HasColumnName("solicitud_descripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Solicitud__id_pr__0F624AF8");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__4E3E04ADB016CC03");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.UsuarioCorreo)
                    .IsRequired()
                    .HasColumnName("usuario_correo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioPassword)
                    .IsRequired()
                    .HasColumnName("usuario_password")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}