using bodata_calon_karyawan.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace bodata_calon_karyawan.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Biodata> Biodata { get; set; }

        public DbSet<Pendidikan> Pendidikan { get; set; }

        public DbSet<Pelatihan> Pelatihan { get; set; }

        public DbSet<Pekerjaan> Pekerjaan { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Biodata>()
                .HasOne(x => x.User)
                .WithMany(x => x.Biodatas)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Biodata>()
                .Property(x => x.TanggalLahir)
                .HasColumnType("timestamp without time zone");

            builder.Entity<Pendidikan>()
                .HasOne(x => x.Biodata)
                .WithMany(x => x.PendidikanList)
                .HasForeignKey(x => x.BiodataId);

            builder.Entity<Pelatihan>()
                .HasOne(x => x.Biodata)
                .WithMany(x => x.PelatihanList)
                .HasForeignKey(x => x.BiodataId);

            builder.Entity<Pekerjaan>()
                .HasOne(x => x.Biodata)
                .WithMany(x => x.PekerjaanList)
                .HasForeignKey(x => x.BiodataId);
        }
    }
}
