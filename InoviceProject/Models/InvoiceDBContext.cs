using Microsoft.EntityFrameworkCore;

namespace InoviceProject.Models
{
    public class InvoiceDBContext : DbContext
    {
        public InvoiceDBContext()
        {
        }
        public InvoiceDBContext(DbContextOptions options)
           : base(options)
        {
        }

        public virtual DbSet<tblCategory> Categories { get; set; }
        public virtual DbSet<tblSubCategory> SubCategories { get; set; }
        public virtual DbSet<tblUnit> Units { get; set; }
        public virtual DbSet<tblLocation> Locations { get; set; }
        public virtual DbSet<tblVendor> Vendors { get; set; }   
        public virtual DbSet<tblProduct> Products { get; set; }
        public virtual DbSet<tblOrder_details> OrderDetails { get; set; }
        public virtual DbSet<tblReceived_details> ReceivedDetails { get; set; }
        public virtual DbSet<tblOrder_items> OrderItems { get; set; }
        public virtual DbSet<tblReceived_Items> ReceivedItems { get; set; }
        public virtual DbSet<tblCustomer> Customers { get; set; }
        public virtual DbSet<tblInvoice_details> Invoice_Details { get; set; }
        public virtual DbSet<tblInvoice_Product> Invoice_Products { get; set; }
        public virtual DbSet<tblinvoice_payments> Invoice_Payments { get; set; }

        public virtual DbSet<tblCompanyDetails> CompanyDetails { get; set; }
    }
}
