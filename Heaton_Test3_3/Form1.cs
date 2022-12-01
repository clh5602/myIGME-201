﻿using System;
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

            radioButton1.Click += new EventHandler(RadioButton__Click);
            radioButton2.Click += new EventHandler(RadioButton__Click);
            radioButton3.Click += new EventHandler(RadioButton__Click);

            searchBox.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);

            fyootleLabel.Click += new EventHandler(Fyootle__Click);
        }

        private void SearchButton__Click(object sender, EventArgs e)
        {
            string engine = "";

            if (radioButton1.Checked)
            {
                engine = "https://www.google.com/search?q=";
            }
            if (radioButton2.Checked)
            {
                engine = "https://www.bing.com/search?q=";
            }
            if (radioButton3.Checked)
            {
                engine = "http://www.youtube.com/results?search_query=";
            }
            Form myForm = new browserForm(engine + searchBox.Text);
            myForm.Show();
        }

        private void Fyootle__Click(object sender, EventArgs e)
        {
            Form myForm = new browserForm("https://www.google.com/search?q=futile");
            myForm.Show();
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RadioButton__Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int goodButton = rnd.Next(0, 3);

            switch (goodButton)
            {
                case 0:
                    radioButton1.Checked = true;
                    break;
                case 1:
                    radioButton2.Checked = true;
                    break;
                case 2:
                    radioButton3.Checked = true;
                    break;
            }
        }

        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            Random rnd = new Random();
            int failNum = rnd.Next(0, 5);

            if (failNum == 0)
            {
                e.Handled = true;
            }
        }
    }
}
