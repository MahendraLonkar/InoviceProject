using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class CompanyDetailsRepository : ICompanyDetailsRepository
    {
        InvoiceDBContext context;
        public CompanyDetailsRepository(InvoiceDBContext context)
        {
            this.context = context;
        }
        public void AddCompanyDetails(tblCompanyDetails companyDetails)
        {
            throw new NotImplementedException();
        }

        public List<CompanyModel> GetCompany()
        {
            List<CompanyModel> lst = new List<CompanyModel>();
            foreach (tblCompanyDetails c in context.CompanyDetails.ToList())
            {
                CompanyModel cm = new CompanyModel()
                {
                    company_id = c.company_id,
                    company_name = c.company_name,
                    address=c.address,
                    mobile_number=c.mobile_number,
                    email_address=c.email_address,
                    gst_number=c.gst_number,
                };
                lst.Add(cm);
            }
            return lst;
        }

        public List<CompanyModel> GetAllCompanyDetails()
        {
            return GetCompany();
        }

        public CompanyModel GetCompanybyId(int company_id)
        {
            CompanyModel cd=GetCompany().FirstOrDefault(e=>e.company_id.Equals(company_id));
            return cd;
        }
    }
}
