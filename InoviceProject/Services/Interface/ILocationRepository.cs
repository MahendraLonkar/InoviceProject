using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface ILocationRepository
    {
        List<LocationModel> GetAllLocation();
        LocationModel GetLocationById(int location_id);
        void AddLocation(tblLocation location);
        void UpdateLocation(tblLocation location);
        void DeleteLocation(int location_id);
    }
}
