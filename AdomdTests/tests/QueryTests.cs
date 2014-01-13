using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdomdTests
{
    [TestFixture]
    public class QueryTests : QueryTest
    {
        [Test]
        public void MdxQuery()
        {
            try
            {
                AdomdCommand command = new AdomdCommand(queryString, connection);
                var obj = command.Execute();

                Assert.AreNotEqual(obj, null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

        }

        [Test]
        [ExpectedException(typeof(AdomdErrorResponseException))]
        public void MdxQueryException()
        {
            AdomdCommand command = new AdomdCommand(queryString + "ERROR", connection);
            command.Execute();
        }

        [Test]
        public void NonQuery()
        {
            try
            {
                AdomdCommand command = new AdomdCommand(queryString, connection);
                int result = command.ExecuteNonQuery();
                Assert.AreEqual(1, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void XMLReader()
        {
            try
            {
                AdomdCommand command = new AdomdCommand(queryString, connection);
                var result = command.ExecuteXmlReader();
                //String str = System.Xml.Linq.XDocument.Parse(result.ReadOuterXml()).ToString();

                Assert.IsNotNull(result);
                /*System.Console.WriteLine(str);
                XmlTextReader reader = new XmlTextReader("XmlReaderResponse.xml");
                reader.Read();
                String readerText = System.Xml.Linq.XDocument.Parse(reader).ToString();
                System.Console.WriteLine(readerText);*/
                //Assert.Fail(str);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void CellSet()
        {
            try
            {
                AdomdCommand command = new AdomdCommand(queryString, connection);
                var cs = command.ExecuteCellSet();
                Assert.IsNotNull(cs);
                if (cs != null)
                {
                    var axes = cs.Axes;
                    Assert.IsNotNull(axes);
                    Assert.AreEqual(2, axes.Count);
                    foreach (var ax in axes)
                    {
                        Assert.IsNotNull(ax);
                        var positions = ax.Positions;
                        Assert.IsNotNull(positions);
                        foreach (var pos in positions)
                        {
                            Assert.IsNotNull(pos);
                            var members = pos.Members;
                            Assert.IsNotNull(members);
                            foreach (var mb in members)
                            {
                                Assert.IsNotNullOrEmpty(ax.Name);
                                Assert.IsInstanceOf(typeof(int), pos.Ordinal);
                                Assert.IsNotNull(pos.Ordinal);
                                Assert.IsNotNullOrEmpty(mb.Caption);
                            }
                        }
                    }
                    var cells = cs.Cells;
                    Assert.IsNotNull(cells);
                    foreach (var cell in cells)
                    {
                        Assert.IsNotNullOrEmpty(cell.Value.ToString());
                        var cellProperties = cell.CellProperties;
                        Assert.IsNotNull(cellProperties);
                        foreach (var cellProperty in cellProperties)
                        {
                            Assert.IsNotNullOrEmpty(cellProperty.Name);
                            Assert.IsNotNull(cellProperty.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
