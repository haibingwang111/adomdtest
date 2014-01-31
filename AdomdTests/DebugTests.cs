using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    class DebugTests
    {
        static void Main(string[] args)
        {
            QueryTests q = new QueryTests();
            q.initConnection();
            q.CellSet();
        }
    }
}
