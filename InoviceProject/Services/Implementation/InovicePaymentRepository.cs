using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class InovicePaymentRepository : IInovicePaymentRepository
    {
        InvoiceDBContext context;
        public InovicePaymentRepository(InvoiceDBContext context)
        {
            this.context = context;
        }
        public void AddInvoicePayment(tblinvoice_payments payment)
        {
            context.Invoice_Payments.Add(payment);
            context.SaveChanges();
        }

        public void DeleteInvoicePayment(int payment_id)
        {
            tblinvoice_payments Payments = context.Invoice_Payments.Find(payment_id);
            context.Invoice_Payments.Remove(Payments);
            context.SaveChanges();
        }

        public List<Invoice_Payment_Model> GetAllInvoicePayment()
        {
            List<Invoice_Payment_Model> lst = new List<Invoice_Payment_Model>();

            foreach (tblinvoice_payments i in context.Invoice_Payments.ToList())
            {
                tblInvoice_details id = context.Invoice_Details.Find(i.invoice_id);
                tblCustomer c = context.Customers.Find(id.customer_id);
                Invoice_Payment_Model cm = new Invoice_Payment_Model()
                {
                    invoice_id = i.invoice_id,
                    customer_id = id.customer_id,
                    customer_name = c.customer_name,
                    invoice_date = id.invoice_date,
                    invoice_amount = id.invoice_amount,
                    payment_date=i.payment_date,
                    payment_amount=i.payment_amount,
                    payment_mode=i.payment_mode,
                    description=i.description
                };
                lst.Add(cm);
            }
            return lst;
        }

        public List<Invoice_Payment_Model> GetInvoiceDetailWisePayment(int invoice_id)
        {
            return GetAllInvoicePayment().Where(e=>e.invoice_id.Equals(invoice_id)).ToList();
        }

        public List<Invoice_Payment_Model> GetInvoicePayment()
        {
            return GetAllInvoicePayment();
        }

        public Invoice_Payment_Model GetInvoicePaymentById(int payment_id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInvoicePayment(tblinvoice_payments payment)
        {
            throw new NotImplementedException();
        }

        

        
    }
}
