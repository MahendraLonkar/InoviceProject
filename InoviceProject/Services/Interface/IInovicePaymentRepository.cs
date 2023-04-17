using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IInovicePaymentRepository
    {
        void AddInvoicePayment(tblinvoice_payments payment);
        void UpdateInvoicePayment(tblinvoice_payments payment);
        void DeleteInvoicePayment(int payment_id);
        List<Invoice_Payment_Model> GetInvoicePayment();
        Invoice_Payment_Model GetInvoicePaymentById(int payment_id);
        List<Invoice_Payment_Model> GetInvoiceDetailWisePayment(int invoice_id);
    }
}
