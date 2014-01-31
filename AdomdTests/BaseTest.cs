using AdomdTests.utils;
using Microsoft.AnalysisServices.AdomdClient;
using NUnit.Framework;
using System;
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
            _connString = prop.get("connectionString");
        } 

        private String _connString =
           @"Data Source=http://es2.pentaho.com:8081/pentaho/Xmla?userid=admin&password=password; Initial Catalog=mfv40m_payer_product2_4; DataSourceInfo=Pentaho; User Id =admin; Password=password";

            //@"Data Source=http://192.168.123.35:8080/pentaho/Xmla?userid=admin&password=password; Initial Catalog=SteelWheels; DataSourceInfo=Pentaho; User Id =admin; Password=password";

        


        public String connectionString
        {
            get
            {
                return _connString;
            }
            set
            {
                _connString = value;
            }
        }
    }
}
