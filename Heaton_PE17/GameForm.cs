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
    public partial class GameForm : Form
    {
        int nRandom;
        int nGuesses = 0;

        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(int lowNum, int highNum)
        {
            InitializeComponent();
            Random rand = new Random();
            nRandom = rand.Next(lowNum, highNum+1);
            this.gameTimer.Start();
            this.gameTimer.Tick += new EventHandler(this.GameTimer__Tick);
            this.guessButton.Click += new EventHandler(this.GuessButton__Click);
            this.guessTextBox.KeyPress += new KeyPressEventHandler(this.TextBoxes__KeyPress);
        }

        public void GameTimer__Tick(object sender, EventArgs e)
        {

            if (timeProgressBar.Value <= 0)
            {
                gameTimer.Stop();

                DialogResult res = MessageBox.Show($"Time is up! The correct answer was {nRandom}.");

                if (res == DialogResult.OK)
                {
                    this.Close();
                }
                
                return; 
            }

            timeProgressBar.Value--;
        }
        private void TextBoxes__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void GuessButton__Click(object sender, EventArgs e)
        {
            
            int guess;
            if (!Int32.TryParse(guessTextBox.Text, out guess)) 
            { 
                guessTextBox.Text = ""; 
                outputLabel.Text = "The guess is invalid."; 
                return; 
            }

            nGuesses++;

            if (guess == nRandom)
            {

                gameTimer.Stop();

                DialogResult res = MessageBox.Show($"Woohoo, you got it in {nGuesses} guess(es)!");
                
                if (res == DialogResult.OK)
                {
                    this.Close();
                }
                return;
            }

            guessTextBox.Text = "";

            if (guess < nRandom)
            {
                outputLabel.Text = $"{guess} was too low.";
                return;
            }

            if (guess > nRandom)
            {
                outputLabel.Text = $"{guess} was too high.";
                return;
            }
        }


    }
}
