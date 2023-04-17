using InoviceProject.Models;
namespace InoviceProject.Services.Interface
{
    public interface IUnitRepository
    {
        List<UnitModel> GetAllUnit();
        UnitModel GetUnitById(int unit_id);
        void AddUnit(tblUnit unit);
        void Updateunit(tblUnit unit);
        void DeleteUnit(int unit_id);
    }
}
