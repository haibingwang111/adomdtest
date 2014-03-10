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
    public class ConnectionTest : BaseTest
    {
        protected Hashtable adoConnections = new Hashtable();

        [SetUp]
        public virtual void initConnections()
        {
            if (adoConnections.Count == 0)
            {
                foreach (DictionaryEntry entry in connectionsStr)
                {
                    adoConnections.Add(entry.Key, new AdomdConnection((String)entry.Value));
                }
            }

            foreach (DictionaryEntry entry in adoConnections)
            {
                AdomdConnection conn = (AdomdConnection)entry.Value;

                if (conn == null || conn.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    { }
                }
            }
        }
    }
}
