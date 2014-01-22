using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    [TestFixture]
    public class CubeTests : ConnectionTest
    {
        [Test]
        public void FetchAllCubes()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                var cubes = connection.Cubes;

                if (cubes.Count == 0)
                    Assert.Fail("Cubes can't be equal to 0.");
            }
            else
                Assert.Inconclusive("No connection found for test");
        }
    }
}
