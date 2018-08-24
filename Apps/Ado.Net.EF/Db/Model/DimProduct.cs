using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.EF.Db.Model
{
    [Table("DimProduct")]
    public class DimProduct
    {
        public DimProduct()
        {
            FactProductInventories = new HashSet<FactProductInventory>();
        }

        [Key]
        public int ProductKey { get; set; }

        [Column("ProductAlternateKey")]
        [MaxLength(25)]
        [Required]
        public string ProductAlternateKey { get; set; }

        [Column("EnglishProductName")]
        [MaxLength(50)]
        public string EnglishProductName { get; set; }

        public virtual ICollection<FactProductInventory> FactProductInventories { get; private set; }
    }
}
