using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heaton_PE17
{
    public partial class startForm : Form
    {
        public startForm()
        {
            InitializeComponent();
            this.startButton.Click += new EventHandler(this.StartButton_Click);

            this.highTextBox.KeyPress += new KeyPressEventHandler(this.TextBoxes__KeyPress);
            this.lowTextBox.KeyPress += new KeyPressEventHandler(this.TextBoxes__KeyPress);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            bool bConv;
            int lowNumber = 0;
            int highNumber = 0;

            // convert the strings entered in lowTextBox and highTextBox
            // to lowNumber and highNumber Int32.Parse

            if (!Int32.TryParse(lowTextBox.Text, out lowNumber)) { MessageBox.Show("The low number is invalid."); return; }
            if (!Int32.TryParse(highTextBox.Text, out highNumber)) { MessageBox.Show("The high number is invalid."); return; }

            // if not a valid range
            if (lowNumber > highNumber)
            {
                // show a dialog that the numbers are not valid
                MessageBox.Show("The numbers are invalid.");
            }
            else
            {
                // otherwise we're good
                // create a form object of the second form 
                // passing in the number range
                GameForm gameForm = new GameForm(lowNumber, highNumber);

                // display the form as a modal dialog, 
                // which makes the first form inactive
                gameForm.ShowDialog();
            }
        }
        private void TextBoxes__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
