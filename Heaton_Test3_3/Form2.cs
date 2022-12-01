using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heaton_Test3_3
{
    public partial class browserForm : Form
    {
        public browserForm()
        {
            InitializeComponent();

        }

        public browserForm(string query)
        {
            InitializeComponent();

            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser__DocumentCompleted);

            webBrowser.Url = new Uri(query);
            this.Text = query;
        }

        private void WebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            this.Text = webBrowser.Url.ToString();
            HtmlElementCollection htmlElementCollection = webBrowser.Document.Body.GetElementsByTagName("*");

            Random rnd = new Random();

            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                int failNum = rnd.Next(0, 15);

                if (failNum == 0)
                {
                    htmlElement.InnerHtml = "";
                }
                
            }
        }
    }
}
