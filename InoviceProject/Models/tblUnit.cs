using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InoviceProject.Models
{
    [Index(nameof(Unit_name), IsUnique = true)]
    public class tblUnit
    {
        [Key]
        public int Unit_id { get; set; }
        public string Unit_name { get; set; }

      public virtual ICollection<tblProduct> Products { get; set; }

    }
}
