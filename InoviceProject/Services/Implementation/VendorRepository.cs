using InoviceProject.Models;
using InoviceProject.Services.Interface;
using System.Net.Mail;

namespace InoviceProject.Services.Implementation
{
    public class VendorRepository : IVendorRepository
    {
        InvoiceDBContext context;
        public VendorRepository(InvoiceDBContext context)
        {
            this.context = context;
        }
        public void AddVendor(tblVendor vendor)
        {
            context.Vendors.Add(vendor);
            context.SaveChanges();
        }

        public void DeleteVendor(int vendor_id)
        {
            tblVendor vendor= context.Vendors.Find(vendor_id);
            context.Vendors.Remove(vendor);
            context.SaveChanges();
        }

        public List<VendorModel> GetVendor()
         {
            List<VendorModel> lst = new List<VendorModel>();
            foreach (tblVendor v in context.Vendors.ToList())
            {
                tblLocation l = context.Locations.Find(v.Location_id);
                VendorModel cm = new VendorModel()
                {
                    Vendor_id = v.Vendor_id,
                    Vendor_name = v.Vendor_name,
                    Firm_name = v.Firm_name,
                    Firm_address = v.Firm_address,
                    Location_id = v.Location_id,
                    Location_Name = l.Location_name,
                    Mobile_number=v.Mobile_number,
                    Alternate_number=v.Alternate_number,
                    Email_address=v.Email_address
                };
                lst.Add(cm);
            }
            return lst;
        }
        public List<VendorModel> GetAllVendor()
        {
            return GetVendor();
        }

        public VendorModel GetVendorById(int vendor_id)
        {
            VendorModel vendor = GetVendor().FirstOrDefault(e => e.Vendor_id.Equals(vendor_id));
            return vendor;
        }

        public List<VendorModel> LocationWiseVendor(int location_id)
        {
            return GetVendor().Where(e => e.Location_id.Equals(location_id)).ToList();
        }

        public void UpdateVendor(tblVendor vendor)
        {
            context.Vendors.Update(vendor);
            context.SaveChanges();
        }
    }
}
