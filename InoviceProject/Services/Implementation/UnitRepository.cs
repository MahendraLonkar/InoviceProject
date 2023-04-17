using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class UnitRepository : IUnitRepository
    {
        InvoiceDBContext context;
        public UnitRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public void AddUnit(tblUnit unit)
        {
            context.Units.Add(unit);
            context.SaveChanges();
        }

        public void DeleteUnit(int unit_id)
        {
            tblUnit unit=context.Units.Find(unit_id);
            context.Units.Remove(unit);
            context.SaveChanges();
        }

        public List<UnitModel> GetUnit()
        {
            List<UnitModel> lst = new List<UnitModel>();
            foreach (tblUnit u in context.Units.ToList())
            {
                UnitModel um = new UnitModel()
                {
                    Unit_id = u.Unit_id,
                    Unit_name = u.Unit_name
                };
                lst.Add(um);
            }
            return lst;
        }
        public List<UnitModel> GetAllUnit()
        {
            return GetUnit();
        }

        public UnitModel GetUnitById(int unit_id)
        {
            UnitModel unit = GetUnit().FirstOrDefault(e => e.Unit_id.Equals(unit_id));
            return unit;
        }

        public void Updateunit(tblUnit unit)
        {
            context.Units.Update(unit);
            context.SaveChanges();
        }
    }
}
