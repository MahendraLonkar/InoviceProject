using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IInvoiceDetailsRepository
    {
        List<Invoice_Details_Model> GetAllInvoiceDetails();
        Invoice_Details_Model GetInvoice_DetailsById(int invoice_Id);
        void AddInvoiceDetails(tblInvoice_details invoice_Details);
        void UpdateInvoiceDetails(tblInvoice_details invoice_Details);
        void DeleteInvoiceDetails(int invoice_Id);
        List<Invoice_Details_Model> GetCustomerWiseInvoiceDetails(int customer_id);
    }
}
