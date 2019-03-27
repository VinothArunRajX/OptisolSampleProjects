using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppServices.DataModels
{
    public partial class ConferenceRoomBookingContext : DbContext
    {
        public virtual DbSet<BookingHistory> BookingHistory { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ConferenceRoomBooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingHistory>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DurationFrom).HasColumnType("datetime");

                entity.Property(e => e.DurationTo).HasColumnType("datetime");

                entity.Property(e => e.MeetinName).HasMaxLength(500);

                entity.HasOne(d => d.BookedByUser)
                    .WithMany(p => p.BookingHistory)
                    .HasForeignKey(d => d.BookedByUserId)
                    .HasConstraintName("FK_BookingHistory_Users");

                entity.HasOne(d => d.BookedRoom)
                    .WithMany(p => p.BookingHistory)
                    .HasForeignKey(d => d.BookedRoomId)
                    .HasConstraintName("FK_BookingHistory_Rooms");

                entity.HasOne(d => d.BookedStatusNavigation)
                    .WithMany(p => p.BookingHistory)
                    .HasForeignKey(d => d.BookedStatus)
                    .HasConstraintName("FK_BookingHistory_Status");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.RoomName).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RoomStatusNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomStatus)
                    .HasConstraintName("FK_Rooms_Status");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusDetails).HasMaxLength(1000);

                entity.Property(e => e.StatusName).HasMaxLength(100);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.EmailId).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserName).HasMaxLength(500);
            });
        }
    }
}
