using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne;
using WebApplicationForMilitaria.Domain.Entities.JsonFIle;
using WebApplicationForMilitaria.Domain.Entities.SecondProviderFileTwo;

namespace WebApplicationForMilitaria.Infrastructure.Persistance
{
    public class WebAppDbContext : IdentityDbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options) { }

        public DbSet<BillingEntry> BillingEntries { get; set; }
        public DbSet<Domain.Entities.JsonFIle.Type> Types { get; set; }
        public DbSet<Domain.Entities.JsonFIle.Value> Values { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Domain.Entities.JsonFIle.Order> Orders { get; set; }
        public DbSet<Domain.Entities.JsonFIle.Offer> Offer { get; set; }


        //FirstProviderFileOne
        public DbSet<Domain.Entities.FirstProviderFileOne.Offer> Offers2 { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileOne.Products> ProductsSet { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileOne.Product> Products { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileOne.Price> Prices { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileOne.Srp> Srps { get; set; }
        public DbSet<Sizes> SizesSet { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileOne.Size> SizeList { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileOne.Stock> Stocks { get; set; }

        //FirstProviderFileTwo
        public DbSet<Domain.Entities.FirstProviderFileTwo.Product> Products5 { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileTwo.Image> Images5 { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileTwo.Icon> Icons5 { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileTwo.Size> Sizes5 { get; set; }
        public DbSet<Domain.Entities.FirstProviderFileTwo.Parameter> Parameters5 { get; set; }





        //SecondProviderFileOne
        public DbSet<Domain.Entities.SecondProviderFileOne.Product> Products2 { get; set; }


        //SecondProviderFileTwo
        public DbSet<Domain.Entities.SecondProviderFileTwo.Product> Products3 { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }

        //ThirdProviderFileOne
        public DbSet<Domain.Entities.ThirdProviderFileOne.Product> Products4 { get; set; }
        public DbSet<Domain.Entities.ThirdProviderFileOne.Photo> Photos4 { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Files Json
            modelBuilder.Entity<BillingEntry>()
                 .HasOne(e => e.Type)
                 .WithMany()
                 .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<BillingEntry>()
                .HasOne(e => e.Value)
                .WithMany()
                .HasForeignKey(e => e.ValueId);

            modelBuilder.Entity<BillingEntry>()
            .HasOne(be => be.Offer)
            .WithMany()
            .HasForeignKey(be => be.OfferId);

            modelBuilder.Entity<BillingEntry>()
                .HasOne(e => e.Tax)
                .WithMany()
                .HasForeignKey(e => e.TaxId);

            modelBuilder.Entity<BillingEntry>()
                .HasOne(e => e.Balance)
                .WithMany()
                .HasForeignKey(e => e.BalanceId);

            modelBuilder.Entity<BillingEntry>()
                .HasOne(e => e.Order)
                .WithMany()
                .HasForeignKey(e => e.OrderId);


            //FirstProviderFileOne
            modelBuilder.Entity<Domain.Entities.FirstProviderFileOne.Products>()
            .HasOne(p => p.Offer)
            .WithOne(o => o.Products)
            .HasForeignKey<Domain.Entities.FirstProviderFileOne.Products>(p => p.OfferId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileOne.Product>()
                .HasOne(p => p.Products)
                .WithMany(pr => pr.ProductList)
                .HasForeignKey(p => p.ProductsId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileOne.Product>()
                .HasOne(p => p.Price)
                .WithOne(pr => pr.Product)
                .HasForeignKey<Domain.Entities.FirstProviderFileOne.Price>(pr => pr.ProductId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileOne.Product>()
                .HasOne(p => p.Srp)
                .WithOne(sr => sr.Product)
                .HasForeignKey<Domain.Entities.FirstProviderFileOne.Srp>(sr => sr.ProductId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileOne.Product>()
                .HasOne(p => p.Sizes)
                .WithOne(sz => sz.Product)
                .HasForeignKey<Sizes>(sz => sz.ProductId);

            modelBuilder.Entity<Sizes>()
                .HasOne(sz => sz.Product)
                .WithOne(p => p.Sizes)
                .HasForeignKey<Sizes>(sz => sz.ProductId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileOne.Size>()
                .HasOne(sz => sz.Sizes)
                .WithMany(s => s.SizeList)
                .HasForeignKey(sz => sz.SizesId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileOne.Size>()
                .HasOne(sz => sz.Stock)
                .WithOne(st => st.Size)
                .HasForeignKey<Domain.Entities.FirstProviderFileOne.Stock>(st => st.SizeId);


            //FirstProviderFileTwo
            modelBuilder.Entity<Domain.Entities.FirstProviderFileTwo.Product>()
            .HasMany(p => p.Images)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileTwo.Product>()
                .HasMany(p => p.Icons)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileTwo.Product>()
                .HasMany(p => p.Sizes)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Domain.Entities.FirstProviderFileTwo.Product>()
                .HasMany(p => p.Parameters)
                .WithOne(par => par.Product)
                .HasForeignKey(par => par.ProductId);

            //SecondProviderOneFile
            modelBuilder.Entity<Domain.Entities.SecondProviderFileOne.Product>().ToTable("Products2");


            //SecondProviderTwoFile
            modelBuilder.Entity<Domain.Entities.SecondProviderFileTwo.Product>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Products);

            modelBuilder.Entity<Domain.Entities.SecondProviderFileTwo.Product>()
                .HasMany(p => p.Photos)
                .WithOne(ph => ph.Product)
                .HasForeignKey(ph => ph.ProductId);



            //ThirdProviderOneFile
            modelBuilder.Entity<Domain.Entities.ThirdProviderFileOne.Product>()
            .HasMany(p => p.Photos)
            .WithOne(ph => ph.Product)
            .HasForeignKey(ph => ph.ProductId);
        }
    }
}
