using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    public class ConnectionTest : BaseTest
    {
        

        protected AdomdConnection connection;

        [SetUp]
        public virtual void initConnection()
        {
            if (connection == null ||
                connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection = new AdomdConnection(connectionString);
                    connection.Open();
                }
                catch
                { }
            }
        }
    }
}
