using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class InvoiceDetailsRepository:IInvoiceDetailsRepository
    {
        InvoiceDBContext context;
        public InvoiceDetailsRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public void AddInvoiceDetails(tblInvoice_details invoice_Details)
        {
            context.Invoice_Details.Add(invoice_Details);
            context.SaveChanges();
        }

        public void DeleteInvoiceDetails(int invoice_Id)
        {
            tblInvoice_details invoice_Details=context.Invoice_Details.Find(invoice_Id);
            context.Invoice_Details.Remove(invoice_Details);
            context.SaveChanges();
        }

        public List<Invoice_Details_Model> GetInvoiceDetails()
        {
            List<Invoice_Details_Model> lst = new List<Invoice_Details_Model>();

            foreach (tblInvoice_details c in context.Invoice_Details.ToList())
            {
                tblCustomer cid = context.Customers.Find(c.customer_id);
                Invoice_Details_Model cm = new Invoice_Details_Model()
                {
                    invoice_id = c.invoice_id,
                    invoice_amount = c.invoice_amount,
                    invoice_date = c.invoice_date,
                    customer_id = c.customer_id,
                    customer_name = cid.customer_name,
                    Invoice_Products= new List<Invoice_Product_Model>()
                };

                foreach (tblInvoice_Product oi in context.Invoice_Products.Where(ip => ip.invoice_id == c.invoice_id).ToList())
                {
                    tblProduct p = context.Products.Find(oi.product_id);
                    Invoice_Product_Model om = new Invoice_Product_Model()
                    {
                        invoice_product_id = oi.invoice_product_id,
                        invoice_id = oi.invoice_id,
                        product_id = oi.product_id,
                        product_name = p.Product_name,
                        selling_rate = p.Selling_rate,
                        quantity=oi.quantity
                    };
                    cm.Invoice_Products.Add(om);
                }
                float paid_amount = 0, remaining_amount;
                List<tblinvoice_payments> details = context.Invoice_Payments.ToList().Where(e => e.invoice_id.Equals(c.invoice_id)).ToList();

                foreach (tblinvoice_payments p in details)
                {
                    paid_amount += (float)p.payment_amount;
                }

                remaining_amount = (float)c.invoice_amount - paid_amount;
                string status = "";
                if (paid_amount > 0 && paid_amount < c.invoice_amount)
                {
                    status = "Partial Paid";
                }
                else if (paid_amount == 0)
                {
                    status = "Un Paid";
                }
                else if (paid_amount == c.invoice_amount)
                {

                    status = "Paid";

                }
                cm.paid_amount = paid_amount;
                cm.remaining_amount = remaining_amount;
                cm.status = status;
                lst.Add(cm);


            }
            return lst;
        
        }
        public List<Invoice_Details_Model> GetAllInvoiceDetails()
        {
            return GetInvoiceDetails();
        }

        public List<Invoice_Details_Model> GetCustomerWiseInvoiceDetails(int customer_id)
        {
            return GetInvoiceDetails().Where(e=>e.customer_id.Equals(customer_id)).ToList();
        }

        public Invoice_Details_Model GetInvoice_DetailsById(int invoice_Id)
        {
            Invoice_Details_Model invoice_Details = GetInvoiceDetails().FirstOrDefault(e => e.invoice_id.Equals(invoice_Id));
            return invoice_Details;
        }

        public void UpdateInvoiceDetails(tblInvoice_details invoice_Details)
        {
            context.Update(invoice_Details);
            context.SaveChanges();
        }
    }
}
