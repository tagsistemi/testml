using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MagicLinkWrap
{
    
    public class EasyLookReportHelper
    {
        public EasyLookReportHelper(reportrequest rh, string servermago, string nomeinstallazione, string aziendalogin ,string user, string pass)
        {
            this.myReportrequest = rh;
            //this.myMagonetsettings = magoNetSettings;
            this.User = user;
            this.Pass = pass;
            this.loginServerMago = servermago;
            this.loginInstallationName = nomeinstallazione;
            this.loginCompany = aziendalogin;

            this.setParamsTemplate();
            this.valorizzaParametri();


        }

       
        public reportrequest myReportrequest { get; private set; }
        public string myXMLforfind { get; private set; }
        public string myXMLrequest { get; private set; }
        public myEasyLook.ArrayOfString myXMLresult { get; private set; }
        public byte[] myPDFresult { get; private set; }
        public myEasyLook.PdfExecuteReportResponse myPDFresponse { get; private set; }
        public string myJsonResult { get; private set; }
        public string User { get; set; }
        public string Pass { get; set; }

        public string loginServerMago { get; set; }
        public string loginInstallationName { get; set; }
        public string loginCompany { get; set; }

        public void setParamsTemplate()
        {
            string docparam = "";
            docparam = myReportrequest.getDocParameter();
            using (var lm = new MagicLinkWrap.LoginHelper(this.User, this.Pass, this.loginServerMago, this.loginInstallationName, this.loginCompany))
            {
                var esitologin = lm.Login();
                if (esitologin.okLogin)
                {
                    using (MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient elsc = new MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient())
                    {
                        var EasyLookServiceConnectionString = "http://{0}:{1}/{2}/EasyLook/EasyLookService.asmx";
                        var ep = string.Format(EasyLookServiceConnectionString, this.loginServerMago, myReportrequest.Port, this.loginInstallationName);
                        elsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(ep);

                        myXMLforfind = elsc.XmlGetParameters(esitologin.Token, docparam, DateTime.Now, "AllUsers", true);


                    }
                    lm.LogOut(esitologin.Token);
                }
            }

        }

        public void valorizzaParametri()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(myXMLforfind);

            XmlNode root = xDoc.DocumentElement;
            XmlNodeList elemList;

            foreach (var item in myReportrequest.parametri)
            {
                elemList = xDoc.GetElementsByTagName("maxs:" + item.name);
                foreach (XmlNode element in elemList)
                {
                    element.InnerText = item.value;
                }
            }

            this.myXMLrequest = xDoc.OuterXml;
        }



        public void executePDFReport()
        {
            string diagnosi = "";
            try
            {
                using (var lm = new MagicLinkWrap.LoginHelper(this.User, this.Pass, this.loginServerMago, this.loginInstallationName, this.loginCompany))
                {
                    var esitologin = lm.Login();
                    if (esitologin.okLogin)
                    {
                        using (MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient elsc = new MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient())
                        {
                            var EasyLookServiceConnectionString = "http://{0}:{1}/{2}/EasyLook/EasyLookService.asmx";
                            var ep = string.Format(EasyLookServiceConnectionString, this.loginServerMago, myReportrequest.Port, this.loginInstallationName);
                            elsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(ep);
                            myPDFresult = elsc.PdfExecuteReport(esitologin.Token, myXMLrequest, DateTime.Now, "AllUsers", true, ref diagnosi);
                            lm.LogOut(esitologin.Token);
                        }
                       
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<byte[]> executePDFReportAsync()
        {
            string diagnosi = "";

            byte[] r = null;

            try
            {
                using (var lm = new MagicLinkWrap.LoginHelper(this.User, this.Pass, this.loginServerMago, this.loginInstallationName, this.loginCompany))
                {
                    var esitologin = lm.Login();
                    if (esitologin.okLogin)
                    {
                        using (MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient elsc = new MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient())
                        {
                            var EasyLookServiceConnectionString = "http://{0}:{1}/{2}/EasyLook/EasyLookService.asmx";
                            var ep = string.Format(EasyLookServiceConnectionString, this.loginServerMago, myReportrequest.Port, this.loginInstallationName);
                            elsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(ep);
                            var result  = await elsc.PdfExecuteReportAsync(esitologin.Token, myXMLrequest, DateTime.Now, "AllUsers", true,  diagnosi);

                            lm.LogOut(esitologin.Token);

                            return result.Body.PdfExecuteReportResult.ToArray<byte>();
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return r;
        }


        public void executeXMLReport()
        {
            try
            {
                using (var lm = new MagicLinkWrap.LoginHelper(this.User, this.Pass, this.loginServerMago, this.loginInstallationName, this.loginCompany))
                {
                    var esitologin = lm.Login();
                    if (esitologin.okLogin)
                    {
                        using (MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient elsc = new MagicLinkWrap.myEasyLook.EasyLookServiceSoapClient())
                        {
                            var EasyLookServiceConnectionString = "http://{0}:{1}/{2}/EasyLook/EasyLookService.asmx";
                            var ep = string.Format(EasyLookServiceConnectionString, this.loginServerMago, myReportrequest.Port, this.loginInstallationName);
                            elsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(ep);
                            myXMLresult = elsc.XmlExecuteReport(esitologin.Token, myXMLrequest, DateTime.Now, "AllUsers", true);
                            lm.LogOut(esitologin.Token);

                            
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

    public class reportrequest
    {

        public reportrequest()
        {
            this.parametri = new List<reportparam>();
        }


        public const string DefaultReportParameters = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ns:{0} xmlns:ns=\"{2}\" tbNamespace=\"{1}\"><ns:Parameters /></ns:{0}>";

        public const string DefaultUri = "http://www.microarea.it/Schema/2004/Smart/";

       

        public const string user = "AllUsers";
        public string Module { get; set; }
        public string reportname { get; set; }
        public string Application { get; set; }
        public string Port { get; set; }
        public List<reportparam> parametri { get; set; }


        public string getDocParameter()
        {
            string uri = string.Format("{0}{1}/{2}/{3}/{4}.xsd",
                     DefaultUri,
                     Application,
                     Module,
                     user,
                     reportname);

            string NameSpace = string.Format("Report.{0}.{1}.{2}",
                  Application,
                  Module,
                  reportname);

            string content = string.Format(DefaultReportParameters, reportname, NameSpace, uri);

            return content;
        }

    }


    public class reportparam
    {
        public string name { get; set; }
        public string type { get; set; }
        public string mode { get; set; }
        public string value { get; set; }

    }

    public class reportrequestbody
    {
        public string namespacereport { get; set; }
        public List<reportparam> parametri { get; set; }
    }

}
