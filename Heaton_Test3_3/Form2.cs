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

        // Main constructor, includes the user's query
        public browserForm(string query)
        {
            InitializeComponent();

            // assign event handlers
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser__DocumentCompleted);

            // send the web browser to the user's search
            webBrowser.Url = new Uri(query);
            this.Text = query;
        }

        // Upon a complete load of the HTML
        private void WebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            WebBrowser webBrowser = (WebBrowser)sender;
            this.Text = webBrowser.Url.ToString(); // Update the form's title

            // Get every HTML element
            HtmlElementCollection htmlElementCollection = webBrowser.Document.Body.GetElementsByTagName("*");

            Random rnd = new Random();

            // iterate thru every element
            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                // 1 in 15 chance to remove the HTML element
                int failNum = rnd.Next(0, 15);

                if (failNum == 0)
                {
                    htmlElement.InnerHtml = "";
                }
                
            }
        }
    }
}
