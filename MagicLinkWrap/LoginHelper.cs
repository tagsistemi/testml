using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLinkWrap
{
    public class LoginHelper : IDisposable
    {

        public string User { get; set; }
        public string Pass { get; set; }
        public string ServerMago { get; set; }
        public string InstallationName { get; set; }
        public string CompanyName { get; set; }

        public LoginHelper(string user, string pass, string serverMago, string installName, string companyName)
        {
            this.User = user;
            this.Pass = pass;
            this.ServerMago = serverMago;
            this.InstallationName = installName;
            this.CompanyName = companyName;
        }


        public EsitoLogin Login()
        {
            EsitoLogin e = new EsitoLogin();

            using (MagicLinkWrap.myLoginManager.MicroareaLoginManagerSoapClient lmsc = new MagicLinkWrap.myLoginManager.MicroareaLoginManagerSoapClient())
            {
                var ep = string.Format("http://{0}/{1}/loginManager/loginManager.asmx", this.ServerMago, this.InstallationName);
                lmsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(ep);

                string loginName = this.User;
                string companyName = this.CompanyName;
                var authtoken = "";

                try
                {
                    int aRes = lmsc.LoginCompact(ref loginName, ref companyName, this.Pass, "0110H076", true, out authtoken);

                    if (aRes == 0) // 0 means no errors                                     
                    {
                        //vado avanti 
                        e.Token = authtoken;
                        e.okLogin = true;
                        return e;
                    }
                    else
                    {
                        e.okLogin = false;
                        e.Errori = "login non effettuato err:" + aRes.ToString();
                        return e;
                    }
                    
                }
                catch (Exception logExc)
                {
                    var err = string.Format("Exception occurred: {0}", logExc.Message);
                    e.Errori = err;
                    return e;
                }
                
            }
        }

        public void LogOut( string authenticationToken)
        {
            if (authenticationToken != string.Empty)
            {
                using (MagicLinkWrap.myLoginManager.MicroareaLoginManagerSoapClient lmsc = new MagicLinkWrap.myLoginManager.MicroareaLoginManagerSoapClient())
                {
                    var ep = string.Format("http://{0}/{1}/loginManager/loginManager.asmx", this.ServerMago, this.InstallationName);
                    lmsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(ep);
                    lmsc.LogOff(authenticationToken);
                }
            }

        }

        public void Dispose()
        {
           
        }
    }
    public class EsitoLogin
    {
        public bool okLogin { get; set; }
        public string Token { get; set; }
        public string Errori { get; set; }
    }
}



