using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
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
                AdomdConnection conn = new AdomdConnection(connectionString);
                conn.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);
                Assert.AreNotEqual(conn, null);
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
            new AdomdConnection("");
        }

        [Test]
        public void Disconnect()
        {
            try
            {
                AdomdConnection conn = new AdomdConnection(connectionString);
                conn.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);
                conn.Close(true);
                Assert.AreEqual(System.Data.ConnectionState.Closed, conn.State);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
