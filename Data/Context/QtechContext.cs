using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public partial class QtechContext : DbContext
{
    public QtechContext()
    {
    }

    public QtechContext(DbContextOptions<QtechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lectura> Datos { get; set; }

    public virtual DbSet<EspecieTerrario> EspecieTerrarios { get; set; }

    public virtual DbSet<Especie> Especies { get; set; }

    public virtual DbSet<Logro> Logros { get; set; }

    public virtual DbSet<Notificacion> Notificaciones { get; set; }

    public virtual DbSet<Observacion> Observaciones { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Terrario> Terrarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioLogro> UsuarioLogros { get; set; }

    public virtual DbSet<UsuarioUsuario> UsuarioUsuarios { get; set; }

    public virtual DbSet<Visita> Visitas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Lectura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("datos");

            entity.HasIndex(e => e.Idterrario, "fk_datos_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Humedad).HasColumnName("humedad");
            entity.Property(e => e.Idterrario).HasColumnName("idterrario");
            entity.Property(e => e.Luz).HasColumnName("luz");
            entity.Property(e => e.Temperatura).HasColumnName("temperatura");

            entity.HasOne(d => d.IdterrarioNavigation).WithMany(p => p.Datos)
                .HasForeignKey(d => d.Idterrario)
                .HasConstraintName("fk_datos");
        });

        modelBuilder.Entity<EspecieTerrario>(entity =>
        {
            entity.HasKey(e => new { e.Idterrario, e.Idespecie }).HasName("PRIMARY");

            entity.ToTable("especie_terrario");

            entity.HasIndex(e => e.Idespecie, "fk_especie_idx");

            entity.Property(e => e.Idterrario).HasColumnName("idterrario");
            entity.Property(e => e.Idespecie).HasColumnName("idespecie");
            entity.Property(e => e.FechaInsercion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_insercion");

            entity.HasOne(d => d.Especie).WithMany(p => p.EspecieTerrarios)
                .HasForeignKey(d => d.Idespecie)
                .HasConstraintName("fk_especie");

            entity.HasOne(d => d.Terrario).WithMany(p => p.EspecieTerrarios)
                .HasForeignKey(d => d.Idterrario)
                .HasConstraintName("fk_terrario");
        });

        modelBuilder.Entity<Especie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("especies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionVida).HasColumnName("duracion_vida");
            entity.Property(e => e.Ecosistema)
                .HasMaxLength(50)
                .HasColumnName("ecosistema");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .HasColumnName("genero");
            entity.Property(e => e.Hiberna).HasColumnName("hiberna");
            entity.Property(e => e.HorasLuz).HasColumnName("horas_luz");
            entity.Property(e => e.HorasLuzHib).HasColumnName("horas_luz_hib");
            entity.Property(e => e.HumedadMaxima).HasColumnName("humedad_maxima");
            entity.Property(e => e.HumedadMinima).HasColumnName("humedad_minima");
            entity.Property(e => e.Imagen)
                .HasMaxLength(150)
                .HasColumnName("imagen");
            entity.Property(e => e.NombreComun)
                .HasMaxLength(50)
                .HasColumnName("nombre comun");
            entity.Property(e => e.Sp)
                .HasMaxLength(50)
                .HasColumnName("sp");
            entity.Property(e => e.TemperaturaHibMaxima).HasColumnName("temperatura_hib_maxima");
            entity.Property(e => e.TemperaturaHibMinima).HasColumnName("temperatura_hib_minima");
            entity.Property(e => e.TemperaturaMaxima).HasColumnName("temperatura_maxima");
            entity.Property(e => e.TemperaturaMinima).HasColumnName("temperatura_minima");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("Tipo");
        });

        modelBuilder.Entity<Logro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("logros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechadesde)
                .HasColumnType("datetime")
                .HasColumnName("fechadesde");
            entity.Property(e => e.Fechahasta)
                .HasColumnType("datetime")
                .HasColumnName("fechahasta");
            entity.Property(e => e.Icono)
                .HasMaxLength(150)
                .HasColumnName("icono");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notificacion");

            entity.HasIndex(e => e.Idterrario, "fk_notificacion_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idterrario).HasColumnName("idterrario");
            entity.Property(e => e.Texto)
                .HasMaxLength(250)
                .HasColumnName("texto");
            entity.Property(e => e.Vista).HasColumnName("vista");
            entity.Property(e => e.Gravedad).HasColumnName("gravedad");

            entity.HasOne(d => d.Terrario).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.Idterrario)
                .HasConstraintName("fk_notificacion");
        });

        modelBuilder.Entity<Observacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("observaciones");

            entity.HasIndex(e => e.Idterrario, "fk_observaciones_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idterrario).HasColumnName("idterrario");
            entity.Property(e => e.Texto)
                .HasMaxLength(150)
                .HasColumnName("texto");

            entity.HasOne(d => d.IdterrarioNavigation).WithMany(p => p.Observaciones)
                .HasForeignKey(d => d.Idterrario)
                .HasConstraintName("fk_observaciones");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tareas");

            entity.HasIndex(e => e.Idterrario, "fk_tareas_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'INICIADA'")
                .HasColumnType("enum('REALIZADA','CANCELADA','EN PROGRESO','INICIADA')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaResolucion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_resolucion");
            entity.Property(e => e.Idterrario).HasColumnName("idterrario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(75)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdterrarioNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.Idterrario)
                .HasConstraintName("fk_tareas");
        });

        modelBuilder.Entity<Terrario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("terrarios");

            entity.HasIndex(e => e.Idusuario, "fk_terrario_usuario_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(150)
                .HasColumnName("contrasena");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.Ecosistema)
                .HasMaxLength(150)
                .HasColumnName("ecosistema");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaUltimaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_modificacion");
            entity.Property(e => e.Foto)
                .HasMaxLength(150)
                .HasColumnName("foto");
            entity.Property(e => e.Hibernacion).HasColumnName("hibernacion");
            entity.Property(e => e.HorasLuz)
                .HasDefaultValueSql("'0'")
                .HasColumnName("horas_luz");
            entity.Property(e => e.HorasLuzHiber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("horas_luz_hiber");
            entity.Property(e => e.HumedadMaxima)
                .HasDefaultValueSql("'0'")
                .HasColumnName("humedad_maxima");
            entity.Property(e => e.HumedadMinima)
                .HasDefaultValueSql("'0'")
                .HasColumnName("humedad_minima");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Privado).HasColumnName("privado");
            entity.Property(e => e.Sustrato)
                .HasMaxLength(150)
                .HasColumnName("sustrato");
            entity.Property(e => e.Tamano).HasColumnName("tamano");
            entity.Property(e => e.TemperaturaMaxima)
                .HasDefaultValueSql("'0'")
                .HasColumnName("temperatura_maxima");
            entity.Property(e => e.TemperaturaMaximaHiber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("temperatura_maxima_hiber");
            entity.Property(e => e.TemperaturaMinima)
                .HasDefaultValueSql("'0'")
                .HasColumnName("temperatura_minima");
            entity.Property(e => e.TemperaturaMinimaHiber)
                .HasDefaultValueSql("'0'")
                .HasColumnName("temperatura_minima_hiber");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Terrarios)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("id_terrarios_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "nombre_usuario_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(45)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(45)
                .HasColumnName("apellido 2");
            entity.Property(e => e.Borrado).HasColumnName("borrado");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(150)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(150)
                .HasColumnName("foto_perfil");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.Perfil)
                .HasDefaultValueSql("'CLIENTE'")
                .HasColumnType("enum('ADMIN','CLIENTE')")
                .HasColumnName("perfil");
            entity.Property(e => e.Salt)
                .HasColumnType("blob")
                .HasColumnName("salt");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<UsuarioLogro>(entity =>
        {
            entity.HasKey(e => new { e.Idusuario, e.Idlogro }).HasName("PRIMARY");

            entity.ToTable("usuario_logro");

            entity.HasIndex(e => e.Idlogro, "fk_logro_idx");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idlogro).HasColumnName("idlogro");
            entity.Property(e => e.FechaAdquisicion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_adquisicion");

            entity.HasOne(d => d.IdlogroNavigation).WithMany(p => p.UsuarioLogros)
                .HasForeignKey(d => d.Idlogro)
                .HasConstraintName("fk_logros");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.UsuarioLogros)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("fk_usuarios");
        });

        modelBuilder.Entity<UsuarioUsuario>(entity =>
        {
            entity.HasKey(e => new { e.Idcontacto, e.Idusuario }).HasName("PRIMARY");

            entity.ToTable("usuario_usuario");

            entity.HasIndex(e => e.Idusuario, "fk_usuario_idx");

            entity.Property(e => e.Idcontacto).HasColumnName("idcontacto");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.FechaContacto)
                .HasColumnType("datetime")
                .HasColumnName("fecha_contacto");

            entity.HasOne(d => d.IdcontactoNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.Idcontacto)
                .HasConstraintName("fk_contacto");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.UsuarioUsuarioIdusuarioNavigations)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<Visita>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Idusuario, e.Idterrario }).HasName("PRIMARY");

            entity.ToTable("visita");

            entity.HasIndex(e => e.Idterrario, "fk_vista_terrario_idx");

            entity.HasIndex(e => e.Idusuario, "fk_vista_usuario_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idterrario).HasColumnName("idterrario");
            entity.Property(e => e.Comentario)
                .HasMaxLength(300)
                .HasColumnName("comentario");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");

            entity.HasOne(d => d.IdterrarioNavigation).WithMany(p => p.Visitas)
                .HasForeignKey(d => d.Idterrario)
                .HasConstraintName("fk_vista_terrario");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Visita)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("fk_vista_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
