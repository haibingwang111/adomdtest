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
        private String _connString =
           @"Data Source=http://localhost:8089/pentaho/Xmla?userid=admin&password=password; Initial Catalog=SteelWheels; DataSourceInfo=Pentaho; User Id =admin; Password=password";
        
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
