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
    public class DatabaseTests
    {
        [TestMethod()]
        public void GetCreateDDLTest()
        {
            Database db = new Database("testName", null);
            Assert.AreEqual("CREATE DATABASE testName;", db.GetCreateDDL());
        }
    }
}