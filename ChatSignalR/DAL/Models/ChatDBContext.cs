using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class ChatDBContext : DbContext
    {
        public ChatDBContext()
        {
        }

        public ChatDBContext(DbContextOptions<ChatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppSettings> AppSettings { get; set; }
        public virtual DbSet<Error> Error { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserSession> UserSession { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2F3RP54;Initial Catalog=ChatDB;User ID=Suren;Password=************");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AppSettings>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__AppSetti__737584F681303715")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.HasIndex(e => e.Key)
                    .HasName("UQ__Error__C41E0289AE0A095E")
                    .IsUnique();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Translation).IsRequired();
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Permissi__737584F6B7901C9C")
                    .IsUnique();

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Description).HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Role__737584F6CE33B6A5")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__RolePermi__Permi__3E52440B");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RolePermi__RoleI__3D5E1FD2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__User__A9D1053489CD6CA9")
                    .IsUnique();

                entity.HasIndex(e => e.LoginName)
                    .HasName("UQ__User__DB8464FFC16E4399")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LastUpdateDate).HasColumnType("date");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__User__RoleId__45F365D3");
            });

            modelBuilder.Entity<UserSession>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.ModificationDate).HasColumnType("date");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSession)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__UserSessi__UserI__48CFD27E");
            });
        }
    }
}
