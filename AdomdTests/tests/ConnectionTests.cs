using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    [TestFixture]
    class ConnectionTests : BaseTest
    {
        [Test]
        public void Connection()
        {
            try
            {
                Console.WriteLine("Testing Connections");

                foreach (DictionaryEntry entry in connectionsStr)
                {
                    AdomdConnection conn = new AdomdConnection((String)entry.Value);
                    conn.Open();
                    Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);
                    Assert.AreNotEqual(conn, null);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConnectionException()
        {
            Console.WriteLine("Testing Connection Exception");
            new AdomdConnection("");
        }

        [Test]
        public void Disconnect()
        {
            try
            {
                Console.WriteLine("Testing Disconnections");
                foreach (DictionaryEntry entry in connectionsStr)
                {
                    AdomdConnection conn = new AdomdConnection((String)entry.Value);
                    conn.Open();
                    Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);
                    conn.Close(true);
                    Assert.AreEqual(System.Data.ConnectionState.Closed, conn.State);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
