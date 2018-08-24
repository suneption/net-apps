using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.EF.Db.Model
{
    [Table("FactProductInventory")]
    public class FactProductInventory
    {
        [Key]
        [Column("ProductKey", Order = 0)]
        public int ProductKey { get; set; }

        [Key]
        [Column("DateKey", Order = 1)]
        public int DateKey { get; set; }

        public DateTime MovementDate { get; set; }

        public virtual DimProduct DimProduct { get; set; }
    }
}
