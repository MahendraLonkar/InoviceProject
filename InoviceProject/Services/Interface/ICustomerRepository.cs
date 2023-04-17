using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface ICustomerRepository
    {
        List<Customer_Model> GetAllCustomer();
        Customer_Model GetCustomerById(int customer_id);
        void AddCustomer(tblCustomer customer);
        void UpdateCustomer(tblCustomer customer);
        void DeleteCustomer(int customer_id);

    }
}
