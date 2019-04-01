using Microsoft.EntityFrameworkCore;

namespace WeatherDataDal.Models
{
    public partial class WeatherDataContext : DbContext
    {
        public WeatherDataContext()
        {
        }

        public WeatherDataContext(DbContextOptions<WeatherDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clouds> Clouds { get; set; }
        public virtual DbSet<Coord> Coords { get; set; }
        public virtual DbSet<Main> Mains { get; set; }
        public virtual DbSet<Sys> Sys { get; set; }
        public virtual DbSet<Weather> Weathers { get; set; }
        public virtual DbSet<WeatherData> WeatherData { get; set; }
        public virtual DbSet<Wind> Winds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Data Source=SSIEVERTS-PC;Initial Catalog=WeatherData;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Clouds>(entity =>
            {
                entity.HasIndex(e => e.WeatherDataRefId)
                    .IsUnique();

                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Coord>(entity =>
            {
                entity.HasIndex(e => e.WeatherDataRefId)
                    .IsUnique();

                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Main>(entity =>
            {
                entity.HasIndex(e => e.WeatherDataRefId)
                    .IsUnique();

                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Sys>(entity =>
            {
                entity.HasIndex(e => e.WeatherDataRefId)
                    .IsUnique();

                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Weather>(entity =>
            {
                entity.HasIndex(e => e.WeatherDataRefId);

                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<WeatherData>(entity =>
            {
                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Wind>(entity =>
            {
                entity.HasIndex(e => e.WeatherDataRefId)
                    .IsUnique();

                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}