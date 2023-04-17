using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class LocationRepository:ILocationRepository
    {
        InvoiceDBContext context;
        public LocationRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public void AddLocation(tblLocation location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
        }

        public void DeleteLocation(int location_id)
        {
            tblLocation location=context.Locations.Find(location_id);
            context.Locations.Remove(location);
            context.SaveChanges();
        }

        public List<LocationModel> GetLocation()
        {
            List<LocationModel> lst = new List<LocationModel>();
            foreach (tblLocation l in context.Locations.ToList())
            {
                LocationModel lm = new LocationModel()
                {
                    Location_id = l.Location_id,
                    Location_name = l.Location_name
                };
                lst.Add(lm);
            }
            return lst;
        }
        public List<LocationModel> GetAllLocation()
        {
            return GetLocation();
        }

        public LocationModel GetLocationById(int location_id)
        {
            LocationModel location = GetLocation().FirstOrDefault(e => e.Location_id.Equals(location_id));
            return location;
        }

        public void UpdateLocation(tblLocation location)
        {
            context.Locations.Update(location);
            context.SaveChanges();
        }
    }
}
