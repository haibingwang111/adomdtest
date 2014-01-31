using AdomdTests.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    public class QueryTest : ConnectionTest
    {
        public QueryTest()
        {
            Properties prop = new Properties("connection.properties");
            bool exit = false;
            int count = 1;
            String query;
            while(!exit)
            {
                query = prop.get("queryString" + count);
                if (!String.IsNullOrEmpty(query))
                    queries.Add(query);
                else exit = true;
                count++;
            }
        }

        public List<String> queries = new List<string>();
    }
}
