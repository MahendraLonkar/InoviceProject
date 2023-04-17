using InoviceProject.Models;
using InoviceProject.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace InoviceProject.Services.Implementation
{
    public class InvoiceProductRepository : IInvoiceProductRepository
    {
        InvoiceDBContext context;
        public InvoiceProductRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public List<Invoice_Product_Model> GetInvoiceProduct()
        {
            List<Invoice_Product_Model> lst = new List<Invoice_Product_Model>();
            foreach (tblInvoice_Product ip in context.Invoice_Products.ToList())
            {
                tblInvoice_details c = context.Invoice_Details.Find(ip.invoice_id);
                tblProduct p=context.Products.Find(ip.product_id);
                Invoice_Product_Model sm = new Invoice_Product_Model()
                {
                   invoice_product_id= ip.invoice_product_id,
                   invoice_id= ip.invoice_id,
                   product_id=ip.product_id,
                   product_name=p.Product_name,
                   selling_rate=p.Selling_rate,
                   tax=p.Tax,
                   quantity=ip.quantity,
                   
                };
                
                lst.Add(sm);
            }
            return lst;
        }

        public List<InvoiceSummary> GetInvoiceSummaries()
        {
           return context.Set<tblInvoice_details>()
            .Join(context.Set<tblInvoice_Product>(),
                i => i.invoice_id,
                p => p.invoice_id,
                (i, p) => new { Invoice = i, Product = p })
            .GroupBy(x => x.Invoice.invoice_date)
            .Select(g => new InvoiceSummary
            {
                InvoiceDate = g.Key,
                InvoiceAmount = g.Sum(x => x.Invoice.invoice_amount),
                TotalQuantity = g.Sum(x => x.Product.quantity),
            })
            .OrderBy(x => x.InvoiceDate)
            .ToList();
        }

        public List<InvoiceSummary> GetAllInvoicesummary()
        {
            return GetInvoiceSummaries();
        }

        public List<Invoice_quantityproduct_model> GetInvoicetotaquantity()
        {
            return context.Set<tblInvoice_Product>()
                .Join(context.Set<tblProduct>(),
                i => i.product_id,
                p => p.Product_id,
                (i, p) => new { invoice = i, product = p })
                .GroupBy(p => new { p.invoice.product_id, p.product.Product_name })
                .Select(g => new Invoice_quantityproduct_model
                {
                    product_id = g.Key.product_id,
                    product_name = g.Key.Product_name,
                    TotalQuantity = g.Sum(p => p.invoice.quantity)
                })
                .ToList();

            
        }

        public List<Invoice_quantityproduct_model> GetAllInvoiceTotalQuantity()
        {
            return GetInvoicetotaquantity();
        }

        public List<Invoice_Product_Model> GetAllInvoiceproduct()
        {
            return GetInvoiceProduct();
        }

        public Invoice_Product_Model GetInvoiceProductById(int invoice_product_id)
        {
            Invoice_Product_Model product = GetInvoiceProduct().FirstOrDefault(e=>e.invoice_product_id.Equals(invoice_product_id));
            return product;
        }

        public List<Invoice_Product_Model> GetProductWiseInvoiceProduct(int product_id)
        {
            return GetInvoiceProduct().Where(e=>e.product_id==product_id).ToList();
        }

        public void AddInvoiceProduct(tblinvoice_payments payments)
        {
            context.Invoice_Payments.Add(payments);
            context.SaveChanges();
        }

        public List<Invoice_Product_Model> GetinvoiceWiseInvoiceProduct(int invoice_id)
        {
            return GetInvoiceProduct().Where(e=>e.invoice_id.Equals(invoice_id)).ToList();
        }

        
    }
}
