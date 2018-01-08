using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLinkWrap
{
    public class TBHelper : IDisposable
    {

        private string ServerName { get; set; }
        private string InstallationName { get; set; }
        private string EndPointString {get; set;}
        private bool okSetData { get; set; }
        public bool tbCreated { get; set; }

        public TBHelper (string serverName , string installationName)
        {
            ServerName = serverName;
            InstallationName = installationName;
            EndPointString = string.Format("http://{0}/{1}/Tbservices/Tbservices.asmx", serverName, installationName);
            okSetData = false;
        }



        public esitoInitTbLoader CreateTBInstance (myTaskBuilderServices.TbServicesSoapClient tbs, string token, DateTime data)
        {
            int res = 0;
            var etb = new esitoInitTbLoader();
            try
            {
                string easyLookToken;
                res = tbs.CreateTB(token, data, false, out easyLookToken);

                tbCreated = res > 0;
            }
            catch (Exception exc)
            {
                etb.msg = exc.ToString();
            }

            switch (res)
            {
                
                case 0: etb.msg = (Strings.Error_3); break;
                case -1: etb.msg = (Strings.Error_1); break;
                case -2: etb.msg = (Strings.Error_2); break;
                case -3: etb.msg = (Strings.Error_3); break;
                case -4: etb.msg = (Strings.Error_4); break;
                case -5: etb.msg = (Strings.Error_5); break;
                default: etb.msg = (string.Format(Strings.NoError, res)); break;
            }

            return etb;
        }

        public string mySetData(string token , string strxml, bool inittb = false)
        {
            string ro = "";
            using (myTaskBuilderServices.TbServicesSoapClient tbs = new myTaskBuilderServices.TbServicesSoapClient())
            {

                tbs.Endpoint.Address =
                    new System.ServiceModel.EndpointAddress(EndPointString);

                if(inittb)
                {
                    var initres = this.CreateTBInstance(tbs, token, DateTime.Now);

                    if (!this.tbCreated)
                    {
                        return "creazione tbloader fallita";
                    }
                }
               

                if (tbs.SetData(token, strxml, DateTime.Today, 1, true, out ro))
                {
                    okSetData = true;
                    return ro;
                }
                else
                    okSetData = false;
               
            }

            return ro;
        }

        public string mySetDataInData(string token, string strxml, DateTime indata, bool inittb = false)
        {
            string ro = "";
            using (myTaskBuilderServices.TbServicesSoapClient tbs = new myTaskBuilderServices.TbServicesSoapClient())
            {


                tbs.Endpoint.Address =
                    new System.ServiceModel.EndpointAddress(EndPointString);


                if (inittb)
                {
                    var initres = this.CreateTBInstance(tbs, token, DateTime.Now);

                    if (!this.tbCreated)
                    {
                        return "creazione tbloader fallita";
                    }

                }

                if (tbs.SetData(token, strxml, indata, 1, true, out ro))
                {
                    okSetData = true;
                    return ro;
                }
                else
                    okSetData = false;

            }

            return ro;
        }


        public void Dispose()
        {
            
        }
    }

    public class esitoInitTbLoader
    {
        public string msg { get; set; }
        public int res { get; set; }
    }
}
