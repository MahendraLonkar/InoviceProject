using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace InoviceProject.Models
{
    
    [Index(nameof(Category_name),IsUnique = true)]
    public class tblCategory
    {
        
        [Key]
        public int Category_id { get; set; }
        public string Category_name { get; set; }
        public int Flag { get; set; }

        public virtual ICollection<tblSubCategory> SubCategories { get; set; }

    }
}
