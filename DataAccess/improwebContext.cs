using improweb2022_02.Models;
using improweb2022_02.PayGate;
using Microsoft.EntityFrameworkCore;

namespace improweb2022_02.DataAccess
{
    public class improwebContext : DbContext
    {
        public improwebContext()
        {            
        }
        public improwebContext(DbContextOptions<improwebContext> options) 
            : base(options)
        {
        } 

        #region Access
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAccount> RoleAccounts { get; set; }
        #endregion
        #region Account
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountCreditType> AccountCreditTypes { get; set; }
        public virtual DbSet<MapPoint> MapPoints { get; set; }
        #endregion
        #region Bank
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankAccountTypex> BankAccountTypes { get; set; }        
        #endregion
        #region Category
        public virtual DbSet<Category> Categories { get; set; }   
        public virtual DbSet<ProdGroupLink> ProdGroupLinks { get; set; }
        public virtual DbSet<ProductGroupHead> ProductGroupHeads { get; set; }
        public virtual DbSet<ProductGroups> ProductGroups { get; set; }
        public virtual DbSet<ProductGroupTop> ProductGroupTops { get; set; }
        public virtual DbSet<ProductGroupTopLink> ProductGroupTopLinks { get; set; }
                
        #endregion
        #region Delivery
        public virtual DbSet<WEBDelivery> WEBDeliveries { get; set; }
        public virtual DbSet<WEBDeliveryRule> WEBDeliveryRules { get; set; }
        public virtual DbSet<WEBDeliveryDesc> WEBDeliveryDescs { get; set; }
        #endregion
        #region Manufacturer
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<ManufacturerList> ManufacturerLists { get; set; }
        public virtual DbSet<ManufacturersExt> ManufacturersExts { get; set; }
        #endregion
        #region Organisation 
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<OrganisationSetting> OrganisationSettings { get; set; }
        public virtual DbSet<UpdatePriority> UpdatePriorities { get; set; }
        public virtual DbSet<BranchStock> BranchStocks { get; set; }
        public virtual DbSet<OrganisationSource> OrganisationSources { get; set; }
        public virtual DbSet<OrganisationBranch> OrganisationBranches { get; set; }
        public virtual DbSet<SourceList> SourceLists { get; set; }
        #endregion
        #region Product
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<Specifications> Specifications { get; set; }
        #endregion
        #region Reviews
        public virtual DbSet<ReviewProduct> ReviewProducts { get; set; }
        public virtual DbSet<ReviewStatus> ReviewStatuses { get; set; }
        public virtual DbSet<ReviewFlags> ReviewFlags { get; set; }
        public virtual DbSet<ReviewFlagTypes> ReviewFlagTypes { get; set; }
        #endregion
        #region SlideShows
        public virtual DbSet<SlideShow> SlideShows { get; set; }
        public virtual DbSet<Banners> Banners { get; set; }
        public virtual DbSet<Bannersx> Bannersx { get; set; }
        #endregion
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Couriers> Couriers { get; set; }
        public virtual DbSet<PayMethod> PayMethods { get; set; }
        public virtual DbSet<OrgPayMethod> OrgPayMethods { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Invoice> Invoices{ get; set; }
        public virtual DbSet<Wishlist> Wishlists{ get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<WEBBilling> WEBBillings { get; set; }
        public virtual DbSet<WEBShipping> WEBShippings { get; set; }
        //public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<GlobalSettings> GlobalSettings { get; set; }
        public virtual DbSet<DistProduct> DistProducts{ get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Users>(entity =>
            {
                //entity.HasKey(e => e.UserID);
                entity.Property(e => e.EMailAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Surname)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                
                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                
                entity.Property(e => e.EMailAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            });   
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.InverseParents)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Category_Category");
            });   
            modelBuilder.Entity<Role>(entity => 
            { 
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            
            });
            modelBuilder.Entity<RoleAccount>(entity => 
            {
                entity.HasKey(e => new {e.RoleId, e.UserId});

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.RoleAccounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role_User");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role_Role");

            });
            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.Property(e => e.OrgName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.InverseParents)
                    .HasForeignKey(d => d.ParentOrgId)
                    .HasConstraintName("FK_Organisation_Organisation");
                
                entity.HasOne(d => d.parent)
                    .WithMany(p => p.InverseParents)
                    .HasForeignKey(d => d.ParentOrgId)
                    .HasConstraintName("FK_Organisation_Organisation");
                
                /*entity.HasOne(d => d.Industryx)
                    .WithMany(p => p.Organisations)
                    .HasForeignKey(d => d.Industry)
                    .HasConstraintName("FK_Industry_Organisation");*/

            });
            modelBuilder.Entity<Product>(entity =>
            {    
                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OrgID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisation_Product");   

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manufacturer_Product");
                    
                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OrgSourceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganisationSource_Product");
            });
            modelBuilder.Entity<BranchStock>(entity => 
            {
                entity.HasKey(e => new {e.ProdID, e.OrgBraID});
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BranchStocks)
                    .HasForeignKey(d => d.ProdID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BranchStock_OrgnisarionBranch_Product");

                entity.HasOne(d => d.OrganisationBranch)
                    .WithMany(p => p.BranchStocks)
                    .HasForeignKey(d => d.OrgBraID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BranchStock_Product_OrgnisarionBranch");

            });
            modelBuilder.Entity<Industry>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Couriers>(entity =>
            {
                entity.Property(e => e.Courier)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<UpdatePriority>(entity =>
            {
                entity.Property(e => e.UpdatePriorityName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });            
            modelBuilder.Entity<PayMethod>(entity =>
            {
                entity.Property(e => e.Method)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<OrgPayMethod>(entity => 
            {
                entity.HasKey(e => new {e.PayID, e.OrgID});
                entity.HasOne(d => d.PayMethod)
                    .WithMany(p => p.OrgPayMethods)
                    .HasForeignKey(d => d.PayID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisation_OrgPayMethod_PayMethod");

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.OrgPayMethods)
                    .HasForeignKey(d => d.OrgID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisation_OrgPayMethod_OrgPayMethod");

            });
            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.HasOne(d => d.Productx)
                    .WithMany(p => p.ProductImagesx)
                    .HasForeignKey(d => d.ProdID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductImages");
            });
            modelBuilder.Entity<Features>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.ProdID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Features");
            });
            modelBuilder.Entity<Specifications>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Specifications)
                    .HasForeignKey(d => d.ProdID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Specifications");
            });
            modelBuilder.Entity<ReviewProduct>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ReviewProducts)
                    .HasForeignKey(d => d.ProdID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ReviewProduct");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReviewProducts)
                    .HasForeignKey(d => d.CustID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewProduct_Customer");
                
                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.ReviewProducts)
                    .HasForeignKey(d => d.OrgID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewProduct_Organisation");
            });
            modelBuilder.Entity<ReviewFlags>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReviewFlags)
                    .HasForeignKey(d => d.CustID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_ReviewFlag");

                entity.HasOne(d => d.ReviewFlagType)
                    .WithMany(p => p.ReviewFlags)
                    .HasForeignKey(d => d.ReviewFlagTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewFlagType_ReviewFlag");

                entity.HasOne(d => d.ReviewProduct)
                    .WithMany(p => p.ReviewFlagsx)
                    .HasForeignKey(d => d.ProdRevID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewProduct_ReviewFlag");
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Customer");

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.OrgID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisation_Customer");
            });
            
            modelBuilder.Entity<WEBBilling>(entity =>
            {
                entity.HasOne(c => c.Customer)
                    .WithMany(b => b.WEBBillings)
                    .HasForeignKey(c => c.CustID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Billing");
            });            
            modelBuilder.Entity<WEBShipping>(entity =>
            {
                entity.HasOne(c => c.Customer)
                    .WithMany(b => b.WEBShippings)
                    .HasForeignKey(c => c.CustID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Shipping");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.CustID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Wishlist");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.ProdID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Wishlist"); 
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_Product");
            });
            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                
                entity.HasKey(e => new {e.InvoiceID, e.ProdID});
                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_Invoice");
                
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProdID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_product");
            });
            modelBuilder.Entity<ProductGroupHead>(entity => 
            { 
                entity.Property(e => e.HeadName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.ProductGroupHeads)
                    .HasForeignKey(d => d.OrgID)
                    .HasConstraintName("FK_ProductGroupHead_Organisation");
            
            });
            modelBuilder.Entity<ProductGroupTop>(entity => 
            { 
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
              
                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.ProductGroupTops)
                    .HasForeignKey(d => d.OrgID)
                    .HasConstraintName("FK_ProductGroupTop_Organisation");
            
            });
            modelBuilder.Entity<ProductGroupTopLink>(entity => 
            {
                entity.HasKey(e => new {e.GroupHeadID, e.ProductGroupTopId});

                entity.HasOne(d => d.ProductGroupHead)
                    .WithMany(p => p.ProductGroupTopLinks)
                    .HasForeignKey(d => d.GroupHeadID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductGroupTopLink_ProductGroupHead_ProductGroupTop");

                entity.HasOne(d => d.ProductGroupTop)
                    .WithMany(p => p.ProductGroupTopLinks)
                    .HasForeignKey(d => d.ProductGroupTopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductGroupTopLink_ProductGroupTop_ProductGroupHead");

            });
            modelBuilder.Entity<ProductGroups>(entity =>
            {
                /*entity.HasOne(d => d.Industry)
                    .WithMany(p => p.ProductGroups)
                    .HasForeignKey(d => d.IndustryNo)
                    .HasConstraintName("FK_ProductGroup_Industry");*/

            });             
            modelBuilder.Entity<ProdGroupLink>(entity =>
            {
                entity.HasOne(d => d.ProductGroupHead)
                    .WithMany(p => p.ProdGroupLinks)
                    .HasForeignKey(d => d.GroupHeadID)
                    .HasConstraintName("FK_ProdGroupLink_ProductGroupHead");

            }); 
            modelBuilder.Entity<ManufacturersExt>(entity =>
            {
                /*entity.HasOne(d => d.Manufacturerx)
                    .WithMany(p => p.ManufacturersExts)
                    .HasForeignKey(d => d.ManufID)
                    .HasConstraintName("FK_ManufacturersExt_Manufacturer");*/

            }); 
            modelBuilder.Entity<ManufacturerList>(entity =>
            {
                entity.HasNoKey();
                entity.Property(v => v.ManufacturerName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            }); 
                   
        }
    }
}