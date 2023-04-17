using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IVendorRepository
    {
        List<VendorModel> GetAllVendor();
        VendorModel GetVendorById(int vendor_id);
        void AddVendor(tblVendor vendor);
        void UpdateVendor(tblVendor vendor);
        void DeleteVendor(int vendor_id);
        List<VendorModel> LocationWiseVendor(int location_id);
    }
}
