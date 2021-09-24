using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cdcore5.Domain.Entity
{
    public partial class dbcore5Context : DbContext
    {
        public dbcore5Context()
        {
        }

        public dbcore5Context(DbContextOptions<dbcore5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=dbcore5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.ToTable("autores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("autores_has_libros");

                entity.Property(e => e.AutoresId).HasColumnName("autores_id");

                entity.Property(e => e.LibrosIsbn).HasColumnName("libros_ISBN");

                entity.HasOne(d => d.Autores)
                    .WithMany()
                    .HasForeignKey(d => d.AutoresId)
                    .HasConstraintName("fk_autores_has_autores_libros");

                entity.HasOne(d => d.LibrosIsbnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LibrosIsbn)
                    .HasConstraintName("fk_libros_has_autores_libros");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.ToTable("editoriales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__libros__447D36EB9EAD75C6");

                entity.ToTable("libros");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.EditorialesId).HasColumnName("editoriales_id");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("n_paginas");

                entity.Property(e => e.Sinopsis)
                    .HasColumnType("text")
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Editoriales)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EditorialesId)
                    .HasConstraintName("fk_editoriales_libros");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cal1)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("cal1");

                entity.Property(e => e.Cal2)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("cal2");

                entity.Property(e => e.Cal3)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("cal3");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
