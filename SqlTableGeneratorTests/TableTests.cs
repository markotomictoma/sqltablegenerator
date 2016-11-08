using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlTableGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableGenerator.Tests
{
    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void GetCreateDDLTest()
        {
            List<Column> columns = new List<Column>
            {
                new Column() {Name = "Id", Type = "Integer" },
                new Column() {Name = "Name", Type = "Text" }
            };
            Table t = new Table("testName", columns);
            Assert.AreEqual("CREATE TABLE testName(Id Integer,Name Text)", t.GetCreateDDL());
        }
    }
}