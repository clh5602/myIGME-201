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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            searchButton.Click += new EventHandler(SearchButton__Click);
            exitButton.Click += new EventHandler(ExitButton__Click);
        }

        private void SearchButton__Click(object sender, EventArgs e)
        {
            Form myForm = new browserForm(searchBox.Text);
            myForm.Show();
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
