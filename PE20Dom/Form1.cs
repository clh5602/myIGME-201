using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            // add the delegate method to be called after the webpage loads, set this up before Navigate()
            this.webBrowser1.DocumentCompleted += new
            WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);

            // if you want to use example.html from a local folder (saved in c:\temp for example):
            this.webBrowser1.Navigate("c:\\temp\\example.html");

            // or if you want to use the URL  (only use one of these Navigate() statements)
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/example.html");
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            //Change the.InnerText of the first<h1> to "My UFO Page"
            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("h1")[0];
            htmlElement.InnerHtml = "My UFO Page";

            //Change the.InnerText of the first<h2> to "My UFO Info"
            htmlElementCollection = webBrowser1.Document.Body.GetElementsByTagName("h2");
            htmlElementCollection[0].InnerHtml = "My UFO Info";

            //Change the.InnerText of the 2nd<h2> to "My UFO Pictures"
            htmlElementCollection[1].InnerHtml = "My UFO Pictures";

            //Change the.InnerText of the 3rd<h2> to an empty string -""
            htmlElementCollection[2].InnerHtml = "";

            //Select the<body> element and make 2 style changes:
            htmlElement = webBrowser1.Document.Body;
            //The font-family shall be "sans-serif"
            htmlElement.Style = "font-family: sans-serif";
            //The font color shall be "reddish"(specify a red shade in hexadecimal).
            htmlElement.Style += "color: #F23467";

            //Select the first paragraph and make some changes:
            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("p")[0];
            //The inner HTML will contain the text "Report your UFO sightings here:" and have a working link to http://www.nuforc.org
            htmlElement.InnerHtml = "Report your UFO sightings here: <a href='http://www.nuforc.org'>http://www.nuforc.org</a>";
            //There will be.Style changes:
            //the font color is "green"
            htmlElement.Style = "color: green";
            //the font-weight is "bold"
            htmlElement.Style += "font-weight: bold";
            //the font-size is "2em"
            htmlElement.Style += "font-size: 2em";
            //the text-transform is "uppercase"
            htmlElement.Style += "text-transform: uppercase";
            //the text-shadow is "3px 2px #A44"
            htmlElement.Style += "text-shadow: 3px 2px #A44";


            //Change the.InnerText of the 2nd paragraph to an empty string -""
            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("p")[1];
            htmlElement.InnerHtml = "";

            //Insert an<img> element in the beginning of the 3rd paragraph to show an image of a UFO that is out on the web
            HtmlElement newImage = webBrowser1.Document.CreateElement("img");
            newImage.SetAttribute("src", "https://universemagazine.com/wp-content/uploads/2022/09/104274999_mediaitem84151821.jpg");
            newImage.SetAttribute("alt", "A Real UFO!");
            htmlElement = webBrowser1.Document.Body.GetElementsByTagName("p")[2];
            htmlElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, newImage);

            //Add a footer element to the end of the page which has a copyright(&copy;) notice, the current year and your name.
            HtmlElement footer = webBrowser1.Document.CreateElement("footer");
            footer.InnerHtml = "&copy;2022 C. Heaton";
            htmlElement = webBrowser1.Document.Body;
            htmlElement.AppendChild(footer);



        }
    }
}
