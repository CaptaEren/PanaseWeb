using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Models;

namespace PanaseWeb.Data
{
    public class ApiContext : IdentityDbContext<User>
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        // Main Entities
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<TherapySession> TherapySessions { get; set; }
        public DbSet<PatientJournal> PatientJournals { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TherapyNote> TherapyNotes { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Appointment Relationships
            builder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Psychologist)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PsychologistId)
                .OnDelete(DeleteBehavior.Restrict);

            // TherapySession Relationship
            builder.Entity<TherapySession>()
                .HasOne(ts => ts.Appointment)
                .WithOne(a => a.TherapySession)
                .HasForeignKey<TherapySession>(ts => ts.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // User Relationships
            builder.Entity<User>()
                .HasMany(u => u.Journals)
                .WithOne(j => j.User)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(u => u.Assignments)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Psychologist Relationships
            builder.Entity<Psychologist>()
                .HasMany(p => p.Availabilities)
                .WithOne(a => a.Psychologist)
                .HasForeignKey(a => a.PsychologistId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes for Performance
            builder.Entity<Appointment>()
                .HasIndex(a => a.DateTime);

            builder.Entity<Appointment>()
                .HasIndex(a => a.Status);

            builder.Entity<Psychologist>()
                .HasIndex(p => p.Specialty);

            // Unique Constraints
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Psychologist>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
