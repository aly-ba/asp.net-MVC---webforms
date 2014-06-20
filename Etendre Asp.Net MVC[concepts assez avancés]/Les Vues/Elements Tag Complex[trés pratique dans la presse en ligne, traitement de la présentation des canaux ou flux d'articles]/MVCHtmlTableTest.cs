using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  LesVues.TableBuilder;

namespace LesVuesTest
{
    [TestClass]
    public class MVCHtmlTableTest
    {
        [TestMethod]
        public void SimpleTableCreated()
        {
            using (var writer = new StringWriter())
            {
                using (var table = new MvcHtmlTable(writer))
                {

                }

                Assert.AreEqual(writer.ToString(), "<table></table>");
            }

        }

        [TestMethod]
        public void TableCreatedWithAttributes()
        {
            using (var writer = new StringWriter())
            {
                using (var table = new MvcHtmlTable(writer, new  { id = "test" }))
                {

                }

                Assert.AreEqual(writer.ToString(), @"<table id=""test""></table>");
            }

        }

        [TestMethod]
        public void TableCreatedWithRow()
        {
            using (var writer = new StringWriter())
            {
                using (var table = new MvcHtmlTable(writer, null))
                {
                    using (var row = new MvcHtmlTableRow(writer, CellType.Data, null))
                    {

                    }
                }

                Assert.AreEqual(writer.ToString(), @"<table id=""test""></table>");
            }

        } 
    }
}
