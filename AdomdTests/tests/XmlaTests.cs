using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdomdTests
{
    [TestFixture]
    public class XmlaTests : BaseTest
    {
        private String _soapEnvelope;

        [Test]
        public void Connection()
        {
            WebResponse response = null;
            String strResponse = "";
            HttpWebRequest req = this.CreateWebRequest();
            Stream stream = req.GetRequestStream();
            StreamWriter stmw = new StreamWriter(stream);
            stmw.Write(this.createSoapEnvelope());
            response = req.GetResponse();
            Stream str = response.GetResponseStream();
            StreamReader sr = new StreamReader(str);
            strResponse = sr.ReadToEnd();
        }

        private String createSoapEnvelope() 
        {
            _soapEnvelope = @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope""> <soap:Body></soap:Body></soap:Envelope>";
            String methodCall = @"<Discover xmlns=""urn:schemas-microsoft-com:xml-analysis"">"
                                +   "<RequestType>DISCOVER_DATASOURCES</RequestType>"
                                +       "<Restrictions />"
                                +       "<Properties>"
                                +           "<PropertyList>"
                                +               "<Catalog>SteelWheels</Catalog>"
                                +               "<LocaleIdentifier>2070</LocaleIdentifier>"
                                +               "<Content>SchemaData</Content>"
                                +               "<Format>Tabular</Format>"
                                +           "</PropertyList>"
                                +       "</Properties>"
                                + "</Discover>";
            StringBuilder sb = new StringBuilder(_soapEnvelope);
            sb.Insert(sb.ToString().IndexOf("</soap:Body>"), methodCall);
            Console.WriteLine(createSoapEnvelope());
            return sb.ToString();
        }

        private HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(connectionString);

            webRequest.Headers.Add("Version", "Sequence=\"300\" xmlns=\"http://schemas.microsoft.com/analysisservices/2003/engine/2\"");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            return webRequest;
        }
    }
}
