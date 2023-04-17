using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IInvoiceProductRepository
    {
        List<Invoice_Product_Model> GetAllInvoiceproduct();
        Invoice_Product_Model GetInvoiceProductById(int invoice_id);
        List<Invoice_Product_Model> GetProductWiseInvoiceProduct(int product_id);
        List<Invoice_Product_Model> GetinvoiceWiseInvoiceProduct(int invoice_id);

        List<InvoiceSummary> GetAllInvoicesummary();
        List<Invoice_quantityproduct_model> GetAllInvoiceTotalQuantity();
        void AddInvoiceProduct(tblinvoice_payments payments);
    }
}
