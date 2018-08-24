using Ado.Net.EF.Db.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.EF.Db
{
    public class RootContext : DbContext
    {
        public RootContext()
            : base()
        { }

        public RootContext(string connectionString)
            : base(connectionString)
        { }

        public virtual DbSet<DimProduct> DimProducts { get; set; }
        public virtual DbSet<FactProductInventory> FactProductInventories { get; set; }
    }
}