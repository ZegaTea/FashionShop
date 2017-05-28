namespace Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FashionShopDbContext : DbContext
    {
        public FashionShopDbContext()
            : base("name=FashionShopDbContext")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<GroupDetail> GroupDetail { get; set; }
        public virtual DbSet<GroupPr> GroupPr { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDetail> ProductDetail { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<ReceiptDetail> ReceiptDetail { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<GroupDetail>()
                .Property(e => e.maLoaiSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<GroupDetail>()
                .Property(e => e.nhomMa)
                .IsUnicode(false);

            modelBuilder.Entity<GroupDetail>()
                .Property(e => e.meta_tittle)
                .IsUnicode(false);

            modelBuilder.Entity<GroupDetail>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.GroupDetail)
                .HasForeignKey(e => e.loaiSanPhamMa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupPr>()
                .Property(e => e.maNhom)
                .IsUnicode(false);

            modelBuilder.Entity<GroupPr>()
                .Property(e => e.meta_tittle)
                .IsUnicode(false);

            modelBuilder.Entity<GroupPr>()
                .HasMany(e => e.GroupDetail)
                .WithRequired(e => e.GroupPr)
                .HasForeignKey(e => e.nhomMa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.loaiSanPhamMa)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.urlAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductDetail)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.size)
                .IsUnicode(false);

            modelBuilder.Entity<ProductDetail>()
                .HasMany(e => e.ReceiptDetail)
                .WithRequired(e => e.ProductDetail)
                .HasForeignKey(e => new { e.maSanPham, e.size })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Receipt>()
                .HasMany(e => e.ReceiptDetail)
                .WithRequired(e => e.Receipt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiptDetail>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiptDetail>()
                .Property(e => e.size)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.soDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Receipt)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.username)
                .WillCascadeOnDelete(false);
        }
    }
}
