using Ado.Net.EF.Db;
using Ado.Net.EF.Db.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.EF.Tests
{
    [TestFixture]
    public class RootContextTests
    {
        private readonly RootContext _rootContext;

        public RootContextTests()
        {
            _rootContext = new RootContext("name=AdventureWorksDW2016_EXT__Connection");
        }

        [Test]
        public void CreateContext_Succeed()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksDW2016_EXT__Connection"];
            var dbContext = new RootContext("name=AdventureWorksDW2016_EXT__Connection");

            Console.WriteLine(connectionString);
            Console.WriteLine(dbContext.Database.Connection.ConnectionString);

            Assert.That(connectionString.ConnectionString.Equals(dbContext.Database.Connection.ConnectionString, StringComparison.Ordinal));
            Assert.That(!string.IsNullOrEmpty(dbContext.Database.Connection.ConnectionString));
        }

        [Test]
        public void ReadDimProduct_Succeed()
        {
            var dimProducts = _rootContext.DimProducts.Take(10).ToList();
            var dimProductEntry = _rootContext.Entry(dimProducts.First());

            var dimProductNew = new DimProduct() { };
            var dimProductNewEntry = _rootContext.Entry(dimProductNew);
            _rootContext.DimProducts.Attach(dimProductNew);
            dimProductNewEntry = _rootContext.Entry(dimProductNew);

            var dimProductNewFromContext = _rootContext.DimProducts.Create();
            var dimProductNewFromContextEntry = _rootContext.Entry(dimProductNewFromContext);


            Assert.That(dimProducts.Any());
            Assert.That(dimProductEntry.State == System.Data.Entity.EntityState.Unchanged);
        }

        [Test]
        public void UpdateDimProductProperty_NewPropertyValue_Succeed()
        {
            var dimProduct = _rootContext.DimProducts.First(x => x.ProductKey == 1);

            var dimProductEntry = _rootContext.Entry(dimProduct);
            dimProduct.EnglishProductName += "!";
            var dimProductEntryChanged = _rootContext.Entry(dimProduct);
            var dimProduct1 = _rootContext.DimProducts.First(x => x.ProductKey == 1);
            var dimProducts = _rootContext.DimProducts.Take(10).ToList();

            Assert.That(dimProducts.Any());
        }
    }
}