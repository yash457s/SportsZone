using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_App.Models
{
    public partial class Sports_Zone_DbContext : DbContext
    {
        public Sports_Zone_DbContext()
        {
        }

        public Sports_Zone_DbContext(DbContextOptions<Sports_Zone_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetails> AccountDetails { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<OrdersDetails> OrdersDetails { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SportsInfo> SportsInfo { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:sportszone123.database.windows.net,1433;Initial Catalog=Sports_Zone_Db;Persist Security Info=False;User ID=Admin0901;Password=Admin@0901;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetails>(entity =>
            {
                entity.HasKey(e => e.AccName)
                    .HasName("PK__Account___092245521C17718F");

                entity.ToTable("Account_Details");

                entity.HasIndex(e => e.AccEmail)
                    .HasName("UQ__Account___66CB83ACE2CF30EC")
                    .IsUnique();

                entity.Property(e => e.AccName).HasMaxLength(50);

                entity.Property(e => e.AccAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AccEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AccPassword)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AccPhone)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdmId)
                    .HasName("PK__Admin__A13DEAEA76AF03F4");

                entity.Property(e => e.AdmId).HasMaxLength(10);

                entity.Property(e => e.AdmEmail)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AdmName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AdmPassword)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__Cart__68A0342E95C5B104");

                entity.Property(e => e.CarId).HasMaxLength(10);

                entity.Property(e => e.CusId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProId).HasMaxLength(10);

                entity.Property(e => e.Quantity)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK__Cart__CusId__32AB8735");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK__Cart__ProId__339FAB6E");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Categori__6A1C8AFA35CE7FBA");

                entity.Property(e => e.CatId).HasMaxLength(10);

                entity.Property(e => e.CatDescription)
                    .IsRequired()
                    .HasColumnName("catDescription")
                    .HasMaxLength(200);

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProId).HasMaxLength(10);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK__Categorie__ProId__60A75C0F");
            });

            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Customer__2F187110440910A6");

                entity.ToTable("Customer_info");

                entity.Property(e => e.CusId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cus)
                    .WithOne(p => p.CustomerInfo)
                    .HasForeignKey<CustomerInfo>(d => d.CusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer___CusId__2645B050");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Feedback__2F187110B01F70D1");

                entity.Property(e => e.CusId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Comment).HasMaxLength(300);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ProId).HasMaxLength(10);

                entity.HasOne(d => d.Cus)
                    .WithOne(p => p.Feedback)
                    .HasForeignKey<Feedback>(d => d.CusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__CusId__2DE6D218");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK__Feedback__ProId__2EDAF651");
            });

            modelBuilder.Entity<OrdersDetails>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders_D__C3905BCFFF87BE08");

                entity.ToTable("Orders_Details");

                entity.Property(e => e.OrderId).HasMaxLength(10);

                entity.Property(e => e.CusId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShipCity)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShipName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShipPostalCode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK__Orders_De__CusId__395884C4");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId)
                    .HasColumnName("Payment_Id")
                    .HasMaxLength(10);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CusId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("Payment_Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK__Payment__CusId__367C1819");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__Product__62029590F987D931");

                entity.Property(e => e.ProId).HasMaxLength(10);

                entity.Property(e => e.ProDescription).HasMaxLength(200);

                entity.Property(e => e.ProName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProPrice).HasColumnType("money");
            });

            modelBuilder.Entity<SportsInfo>(entity =>
            {
                entity.HasKey(e => e.SpoId)
                    .HasName("PK__Sports_I__D86D969DBFF3FC2F");

                entity.ToTable("Sports_Info");

                entity.Property(e => e.SpoId).HasMaxLength(10);

                entity.Property(e => e.SpoCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpoDescription)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SpoGears)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpoName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserLogi__1788CC4C1F4C6C3D");

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(40);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserLogin)
                    .HasForeignKey<UserLogin>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserLogin__UserI__3F115E1A");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__CB9A1CFF27572F10");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddress).HasMaxLength(100);

                entity.Property(e => e.UserMobile).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
