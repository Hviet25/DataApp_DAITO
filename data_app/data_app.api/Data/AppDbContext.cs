using Microsoft.EntityFrameworkCore;
using data_app.api.Entities;

namespace data_app.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<UserOtp> UserOtps => Set<UserOtp>();
        public DbSet<AccessLog> AccessLogs => Set<AccessLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(x => x.UserId);

                entity.Property(x => x.UserId).HasColumnName("user_id").ValueGeneratedOnAdd();
                entity.Property(x => x.Username).HasColumnName("username").HasMaxLength(50).IsRequired();
                entity.Property(x => x.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
                entity.Property(x => x.PasswordHash).HasColumnName("password_hash").HasMaxLength(255).IsRequired();
                entity.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();
                entity.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            });

            modelBuilder.Entity<UserOtp>(entity =>
            {
                entity.ToTable("user_otps");

                entity.HasKey(x => x.OtpId);

                entity.Property(x => x.OtpId).HasColumnName("otp_id");
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.OtpHash).HasColumnName("otp_hash").HasMaxLength(255).IsRequired();
                entity.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
                entity.Property(x => x.ExpiresAt).HasColumnName("updated_at").IsRequired();
                entity.Property(x => x.IsUsed).HasColumnName("is_used").IsRequired();
                entity.Property(x => x.Attempts).HasColumnName("attempts").IsRequired();
                entity.Property(x => x.UsedAt).HasColumnName("used_at");
                entity.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AccessLog>(entity =>
            {
                entity.ToTable("access_log");

                entity.HasKey(x => x.LogId);

                entity.Property(x => x.LogId).HasColumnName("log_id");
                entity.Property(x => x.ActionType).HasColumnName("action_type").HasMaxLength(50).IsRequired();
                entity.Property(x => x.Success).HasColumnName("success").IsRequired();
                entity.Property(x => x.IpAddress).HasColumnName("ip_address").HasColumnType("inet");
                entity.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
                entity.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
