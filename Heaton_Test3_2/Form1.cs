using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;
using TextBox = System.Windows.Forms.TextBox;

namespace Heaton_Test3_2
{
    public partial class Form1 : Form
    {
        // This 2D array stores the info for each president.
        // Index 0 is the end of the Wikipedia URL
        // Index 1 is the end of the image's URL
        // Index 2 is its political party
        // Index 3 is its number president, used for correct answers
        // Each radio button and text box is assigned a Tag property, and that Tag points to an entry in this array.
        static string[,] presidents = new string[,]
        {
            {"Benjamin_Harrison", "BenjaminHarrison.jpeg", "Republican", "23"},
            {"William_McKinley", "WilliamMcKinley.jpeg", "Republican", "25"},
            {"Franklin_D_Roosevelt", "FranklinDRoosevelt.jpeg", "Democrat", "32"},
            {"Ronald_Reagan", "RonaldReagan.jpeg", "Republican", "40"},
            {"William_J_Clinton", "WilliamJClinton.jpeg", "Democrat", "42"},
            {"Dwight_D_Eisenhower", "DwightDEisenhower.jpeg", "Republican", "34"},
            {"James_Buchanan", "JamesBuchanan.jpeg", "Democrat", "15"},
            {"Martin_VanBuren", "MartinVanBuren.jpeg", "Democrat", "8"},
            {"Franklin_Pierce", "FranklinPierce.jpeg", "Democrat", "14"},
            {"George_Washington", "GeorgeWashington.jpeg", "Federalist", "1"},
            {"George_W_Bush", "GeorgeWBush.jpeg", "Republican", "43"},
            {"John_Adams", "JohnAdams.jpeg", "Federalist", "2"},
            {"Barack_Obama", "BarackObama.png", "Democrat", "44"},
            {"Theodore_Roosevelt", "TheodoreRoosevelt.jpeg", "Republican", "26"},
            {"John_F_Kennedy", "JohnFKennedy.jpeg", "Democrat", "35"},
            {"Thomas_Jefferson", "ThomasJefferson.jpeg", "Democratic-Republican", "3"}
        };
        bool gameStarted = false;

        public Form1()
        {
            InitializeComponent();

            // Give the exit button its click event
            exitButton.Click += new EventHandler(ExitButton__Click);

            // Looping through the president radio buttons and text boxes
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    // Give the president radio buttons their event handler
                    RadioButton radioButton = (RadioButton)c;
                    radioButton.CheckedChanged += new EventHandler(PresidentRadioButton__CheckedChanged);
                }

                if (c.GetType() == typeof(TextBox))
                {
                    // Give the text boxes their event handlers
                    c.MouseHover += new EventHandler(TextBox_MouseHover);
                    c.KeyPress += new KeyPressEventHandler(TextBox_KeyPressed);
                    c.Validating += new CancelEventHandler(TextBox__Validating);
                }
            }

            // Give each filter radio button its event handler
            foreach (Control c in this.groupBoxFilter.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    RadioButton radioButton = (RadioButton)c;
                    radioButton.CheckedChanged += new EventHandler(FilterRadioButton__CheckedChanged);
                }
            }

            pictureBox.MouseEnter += new EventHandler(PictureBox_MouseEnter);
            pictureBox.MouseLeave += new EventHandler(PictureBox_MouseLeave);

            timer.Tick += new EventHandler(Timer__Tick);

            webBrowser.Navigated += new WebBrowserNavigatedEventHandler(WebBrowser__Navigated);
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser__DocumentCompleted);

        }

        // Exit button click event, closes the application
        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Occurs when a president radio button is selected
        private void PresidentRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton =  (RadioButton)sender;
            if (radioButton.Checked)
            {
                // Get the radioButton's Tag property and convert it to an int
                int myIndex = Int32.Parse(radioButton.Tag.ToString());

                // The Tag refers to an index in the presidents array. That array stores the data of each president
                string newUrl = "https://en.m.wikipedia.org/wiki/" + presidents[myIndex, 0];
                string imgUrl = "https://people.rit.edu/dxsigm/" + presidents[myIndex, 1];

                // Assign the pictureBox the correct image, and assign the webBrowser the correct URL
                this.pictureBox.ImageLocation = imgUrl;
                this.webBrowser.Url = new Uri(newUrl);
            }
           
        }

        // For the filter radio buttons
        private void FilterRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            // Convert selected button to RadioButton
            RadioButton radioButton = (RadioButton)sender;

            // If this radio button became checked
            if (radioButton.Checked)
            {
                // Get the filtering party
                string currentParty = radioButton.Text;
                // This is used to select the first valid radio button after being filtered
                RadioButton lastValid = radioButton;

                // Loop through each president radio button
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(RadioButton))
                    {
                        // Store the president radio button, its index in the president array, and the president's party
                        RadioButton presidentRad = (RadioButton)c;
                        int myIndex = Int32.Parse(presidentRad.Tag.ToString());
                        string presidentParty = presidents[myIndex, 2];

                        // If the president qualifies from the filter
                        if (currentParty == "All" || presidentParty == currentParty)
                        {
                            // Show it, and set it to be checked. The last radio button filtered will be checked
                            presidentRad.Visible = true;
                            lastValid = presidentRad;
                        }
                        else
                        {
                            // If not correct party, hide it
                            presidentRad.Visible = false;
                        }
                    }
                }
                // Check the last valid president radio button (the loop goes through the controls backwards, so I had to have the last one be checked)
                lastValid.Checked = true;
            }

        }

        private void Timer__Tick(object sender, EventArgs e)
        {
            bool passTest = true;
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    // Convert the text box to a text box
                    TextBox textBox = (TextBox)c;
                    string correctValue = presidents[Int32.Parse(textBox.Tag.ToString()), 3];

                    if (Int32.Parse(textBox.Text) != Int32.Parse(correctValue))
                    {
                        passTest = false;
                        break;
                    }
                }
            }

            if (passTest)
            {
                timer.Stop();
                webBrowser.Url = new Uri("https://www.youtube.com/embed/18212B4yfLg?autoplay=1");
                exitButton.Enabled = true;
                return;
            }

            if (toolStripProgressBar.Value == 0)
            {
                timer.Stop();
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        // Convert the text box to a text box
                        TextBox textBox = (TextBox)c;
                        textBox.Text = "0";
                    }
                }
                toolStripProgressBar.Value = 240;
                gameStarted = false;
                return;
            }

            toolStripProgressBar.Value--;
        }

        // Shows the tool tip at the beginning of the application
        private void TextBox_MouseHover(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            toolTip.SetToolTip(textBox, "Which # President?");
        }

        private void TextBox_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
            if (!gameStarted)
            {
                gameStarted = true;
                timer.Start();
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            Size newSize = new Size(315, 370);
            //picBox.MaximumSize = new Size(197, 264);
            picBox.MaximumSize = newSize;
            picBox.Size = newSize;
        }
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            Size newSize = new Size(197, 264);
            //picBox.Size = newSize;
            picBox.MaximumSize = newSize;
        }

        private void WebBrowser__Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Change the web group box's title to the correct URL
            groupBoxWeb.Text = webBrowser.Url.ToString();
        }

        private void TextBox__Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string correctValue = presidents[Int32.Parse(textBox.Tag.ToString()), 3];

            if (Int32.Parse(textBox.Text) != Int32.Parse(correctValue))
            {
                this.errorProvider.SetError(textBox, "Incorrect Value");
                e.Cancel = true;
            } 
            else
            {
                this.errorProvider.SetError(textBox, null);
                e.Cancel = false;
            }            

            
        }

        private void WebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection = webBrowser.Document.Body.GetElementsByTagName("a");

            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.SetAttribute("title", "Professor Schuh for President!");
            }
        }


    }
}