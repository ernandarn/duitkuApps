namespace DuitkuApps.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1Duitku : DbContext
    {
        public Model1Duitku()
            : base("name=Model1Duitku")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Anggaran> Anggaran { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cicilan> Cicilan { get; set; }
        public virtual DbSet<Komp_Pengeluaran> Komp_Pengeluaran { get; set; }
        public virtual DbSet<Master_Status> Master_Status { get; set; }
        public virtual DbSet<Master_SumberPenghasilan> Master_SumberPenghasilan { get; set; }
        public virtual DbSet<Pengeluaran> Pengeluaran { get; set; }
        public virtual DbSet<Pengguna> Pengguna { get; set; }
        public virtual DbSet<Penghasilan> Penghasilan { get; set; }
        public virtual DbSet<Realisasi> Realisasi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Cicilan>()
                .Property(e => e.Jmlh_bayar)
                .HasPrecision(19, 4);


            modelBuilder.Entity<Komp_Pengeluaran>()
                .HasMany(e => e.Pengeluaran)
                .WithRequired(e => e.Komp_Pengeluaran)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Komp_Pengeluaran>()
             .HasMany(e => e.Cicilan)
             .WithRequired(e => e.Komp_Pengeluaran)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<Komp_Pengeluaran>()
              .HasMany(e => e.Realisasi)
              .WithRequired(e => e.Komp_Pengeluaran)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Master_Status>()
                .HasMany(e => e.Pengguna)
                .WithRequired(e => e.Master_Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Master_SumberPenghasilan>()
                .HasMany(e => e.Pengguna)
                .WithRequired(e => e.Master_SumberPenghasilan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pengeluaran>()
                .Property(e => e.Jumlah)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pengguna>()
                .Property(e => e.Alamat)
                .IsUnicode(false);

            modelBuilder.Entity<Pengguna>()
                .Property(e => e.NoNPWP)
                .IsFixedLength();

            modelBuilder.Entity<Pengguna>()
                .Property(e => e.NoKTP)
                .IsFixedLength();

            modelBuilder.Entity<Realisasi>()
                .Property(e => e.Jumlah)
                .HasPrecision(19, 4);
        }
    }
}
