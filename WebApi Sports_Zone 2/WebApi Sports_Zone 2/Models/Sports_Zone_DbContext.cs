using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi_Sports_Zone_2.Models
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
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<OrdersDetails> OrdersDetails { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SportsInfo> SportsInfo { get; set; }
        public virtual DbSet<UserAddresses> UserAddresses { get; set; }
        public virtual DbSet<UserMobileNumbers> UserMobileNumbers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=YASHPC\\SQLEXPRESS; database=Sports_Zone_Db; trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetails>(entity =>
            {
                entity.HasKey(e => e.AccName)
                    .HasName("PK__Account___09224552607B6D50");

                entity.ToTable("Account_Details");

                entity.HasIndex(e => e.AccEmail)
                    .HasName("UQ__Account___66CB83AC5DAFB154")
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
                    .HasName("PK__Admin__A13DEAEA9EA99CA5");

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
                    .HasName("PK__Cart__68A0342E16835828");

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
                    .HasConstraintName("FK__Cart__CusId__5FB337D6");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK__Cart__ProId__60A75C0F");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Categori__6A1C8AFA9B08943A");

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
                    .HasConstraintName("FK__Categorie__ProId__3A81B327");
            });

            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Customer__2F1871100A46D095");

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
                    .HasConstraintName("FK__Customer___CusId__534D60F1");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Feedback__2F187110156050AA");

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
                    .HasConstraintName("FK__Feedback__CusId__5AEE82B9");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK__Feedback__ProId__5BE2A6F2");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvId)
                    .HasName("PK__Invoice__9DC82C6A5E220000");

                entity.Property(e => e.InvId).HasMaxLength(10);

                entity.Property(e => e.CusId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ProId).HasMaxLength(10);

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK__Invoice__CusId__571DF1D5");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK__Invoice__ProId__5812160E");
            });

            modelBuilder.Entity<OrdersDetails>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders_D__C3905BCFD26401C9");

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
                    .HasConstraintName("FK__Orders_De__CusId__6A30C649");
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
                    .HasConstraintName("FK__Payment__CusId__6754599E");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__Product__6202959003D08326");

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
                    .HasName("PK__Sports_I__D86D969D1DFCAFA6");

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

            modelBuilder.Entity<UserAddresses>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.Address })
                    .HasName("PK__User_Add__B48A0D960E49C596");

                entity.ToTable("User_Addresses");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Addr__usern__4CA06362");
            });

            modelBuilder.Entity<UserMobileNumbers>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.MobileNumber })
                    .HasName("PK__User_mob__00DFA7C3398063A4");

                entity.ToTable("User_mobile_numbers");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobile_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserMobileNumbers)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__User_mobi__usern__5070F446");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__CB9A1CFFF2C4825E");

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
