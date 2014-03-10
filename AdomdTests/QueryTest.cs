using AdomdTests.utils;
using System;
using System.Collections;
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
            
            foreach(DictionaryEntry entry in connectionsStr)
            {
                List<String> queriesList = new List<string>();
                bool exit = false;
                int count = 1;
                String query;

                while (!exit)
                {
                    query = prop.get((String)(entry.Key) + ".queryString" + count);
                    if (!String.IsNullOrEmpty(query))

                        queriesList.Add(query);
                    else exit = true;
                    count++;
                }
                queries.Add((String)(entry.Key), queriesList);
            }
        }

        public Hashtable queries = new Hashtable();
    }
}
