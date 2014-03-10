using AdomdTests.utils;
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
    
    public class BaseTest
    {

        public BaseTest()
        {
            Properties prop = new Properties("connection.properties");

            int max = 11;
            int count = 1;
            String connStr;
            while (count < max)
            {
                String key = "connStr" + count++;
                connStr = prop.get(key);
                if (!String.IsNullOrEmpty(connStr))
                    connectionsStr.Add(key, connStr);
            }
        }

        public Hashtable connectionsStr = new Hashtable();
    }
}
