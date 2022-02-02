using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace My2Cents.DataInfrastructure
{
    public partial class My2CentsContext : DbContext
    {
        public My2CentsContext()
        {
        }

        public My2CentsContext(DbContextOptions<My2CentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountType).HasMaxLength(40);

                entity.Property(e => e.Interest).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalBalance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Account__UserID__70DDC3D8");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Authorized).HasMaxLength(20);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionName).HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Transacti__Accou__73BA3083");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User_Pro__1788CCACB4290265");

                entity.ToTable("User_Profile");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Employer).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.MailingAddress).HasMaxLength(250);

                entity.Property(e => e.SecondaryEmail).HasMaxLength(250);

                entity.Property(e => e.State)
                    .HasMaxLength(40)
                    .HasColumnName("State_");

                entity.Property(e => e.WorkAddress).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
