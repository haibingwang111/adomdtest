using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    public class QueryTest : ConnectionTest
    {
        private String _query = "SELECT {[Measures].[Sales], [Measures].[Quantity]} ON COLUMNS, NON EMPTY [Time].Children ON ROWS FROM [SteelWheelsSales]";
    
        public String queryString
        {
            get
            {
                return _query;
            }
            set
            {
                _query = value;
            }
        }
    }
}
