using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface ICompanyDetailsRepository
    {
        List<CompanyModel> GetAllCompanyDetails();
        CompanyModel GetCompanybyId(int company_id);
        void AddCompanyDetails(tblCompanyDetails companyDetails);
    }
}
