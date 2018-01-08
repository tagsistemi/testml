using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testml
{
    public partial class Form1 : Form
    {

        private string SERVERMAGO = "192.168.2.210";
        private string INSTALLATIONNAME = "Mago4";
        private string COMPANY = "DBPrefixCompany";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            var esitosetdata = "";

            using (var lm = new MagicLinkWrap.LoginHelper(this.textBoxUser.Text, this.textBoxPass.Text, this.SERVERMAGO, this.INSTALLATIONNAME, this.COMPANY))
            {
                var esitologin = lm.Login();
                if (esitologin.okLogin)
                {
                    try
                    {

                        //questa stringa può essere utilizzata sull'azienda DBPrefixCompany

                        var stringaSetData = "<?xml version=\"1.0\"?><maxs:Invoice xmlns:maxs=\"http://www.microarea.it/Schema/2004/Smart/ERP/Sales/Invoice/Standard/DefaultLight.xsd\" tbNamespace=\"Document.ERP.Sales.Documents.Invoice\" xTechProfile=\"DefaultLight\"><maxs:Data><maxs:SaleDocument master=\"true\"><maxs:DocNo>000032</maxs:DocNo><maxs:DocumentDate>2018-01-08</maxs:DocumentDate><maxs:CustSupp>0017</maxs:CustSupp><maxs:OurReference></maxs:OurReference><maxs:YourReference></maxs:YourReference><maxs:Payment>RBFM3</maxs:Payment><maxs:PostingDate>2018-01-08</maxs:PostingDate><maxs:Currency>EUR</maxs:Currency><maxs:Issued>true</maxs:Issued></maxs:SaleDocument><maxs:Detail><maxs:DetailRow><maxs:SaleDocId>76</maxs:SaleDocId><maxs:Line>1</maxs:Line><maxs:LineType>3538946</maxs:LineType><maxs:Description>Acconto</maxs:Description><maxs:Item></maxs:Item><maxs:UoM></maxs:UoM><maxs:Qty>1.000000000000000</maxs:Qty><maxs:UnitValue>200.000000000000000</maxs:UnitValue><maxs:DiscountFormula></maxs:DiscountFormula><maxs:DiscountAmount>0.000000000000000</maxs:DiscountAmount></maxs:DetailRow></maxs:Detail></maxs:Data></maxs:Invoice>";

                        //var ep = string.Format("http://{0}/{1}/Tbservices/Tbservices.asmx", magoNetSettings.loginServerMago, magoNetSettings.loginInstallationName);
                        using (MagicLinkWrap.TBHelper tbh = new MagicLinkWrap.TBHelper(this.SERVERMAGO, this.INSTALLATIONNAME))
                        {
                            esitosetdata = tbh.mySetData(esitologin.Token, stringaSetData, true);
                           
                            lm.LogOut(esitologin.Token);
                            this.richTextBoxEsito.Text = esitosetdata;

                        }

                    }
                    catch (Exception em)
                    {
                        var err = em.Message;
                        lm.LogOut(esitologin.Token);
                        esitosetdata = err;
                       
                    }
                }
                else
                {
                    var testlogin = esitologin.Errori;
                }
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            MagicLinkWrap.reportrequest rr = new MagicLinkWrap.reportrequest();
            rr.Application = "ERP";
            rr.Module = "Company";
            rr.reportname = "Titles";
            rr.Port = "80";


            MagicLinkWrap.EasyLookReportHelper rm = new MagicLinkWrap.EasyLookReportHelper(rr, this.SERVERMAGO, this.INSTALLATIONNAME, this.COMPANY, textBoxUser.Text, textBoxPass.Text);
            rm.executePDFReport();
            var base64EncodedPDF = System.Convert.ToBase64String(rm.myPDFresult);

            this.richTextBoxPdfString.Text = base64EncodedPDF;
        }
    }
}
