using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        InvoiceDBContext context;
        public CustomerRepository(InvoiceDBContext context)
        {
            this.context = context;
        }
        public void AddCustomer(tblCustomer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(int customer_id)
        {
            tblCustomer customer = context.Customers.Find(customer_id);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public List<Customer_Model> GetCustomer()
        {
            List<Customer_Model> lst = new List<Customer_Model>();
            foreach (tblCustomer c in context.Customers.ToList())
            {
                Customer_Model cm = new Customer_Model()
                {
                    customer_id = c.customer_id,
                    customer_name = c.customer_name,
                    mobile_number=c.mobile_number
                };
                lst.Add(cm);
            }
            return lst;
        }
        public List<Customer_Model> GetAllCustomer()
        {
            return GetCustomer();
        }

        public Customer_Model GetCustomerById(int customer_id)
        {
            Customer_Model customer= GetCustomer().FirstOrDefault(e=>e.customer_id.Equals(customer_id));
            return customer;
        }

        public void UpdateCustomer(tblCustomer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
