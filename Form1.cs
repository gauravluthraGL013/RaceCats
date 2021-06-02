using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceCatsTask
{
    public partial class Form1 : Form
    {
        Punter Bettor1 = Factory.GetAPunter("Joe");
        Punter Bettor2 = Factory.GetAPunter("Bob");
        Punter Bettor3 = Factory.GetAPunter("Al");
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Bettor1.Cash;
            label3.Text = "Max bet is: " + Bettor1.Cash;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Bettor2.Cash;
            label3.Text = "Max bet is: " + Bettor2.Cash;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Bettor2.Cash;
            label3.Text = "Max bet is: " + Bettor3.Cash;
        }

        private void ResetAll()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            label3.Text = "Max bet is:";
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            textBox1.Text = "Joe hasn't placed a bet";
            textBox2.Text = "Bob hasn't placed a bet";
            textBox3.Text = "Al hasn't placed a bet";
            Bettor1 = Factory.GetAPunter("Joe");
            Bettor2 = Factory.GetAPunter("Bob");
            Bettor3 = Factory.GetAPunter("Al");
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            textBox3.ForeColor = Color.Black;
            button1.Enabled = true;
            button3.Enabled = true;
            button3.Text = "Race";
        }

        // Place Bet
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Bettor1.Amount = (int)numericUpDown1.Value;
                Bettor1.Dog = (int)numericUpDown2.Value;
                textBox1.Text = "Joe bets $" + Bettor1.Amount + " on cat number " + Bettor1.Dog;
            }
            if (radioButton2.Checked)
            {
                Bettor2.Amount = (int)numericUpDown1.Value;
                Bettor2.Dog = (int)numericUpDown2.Value;
                textBox2.Text = "Bob bets $" + Bettor2.Amount + " on cat number " + Bettor2.Dog;
            }
            if (radioButton3.Checked)
            {
                Bettor3.Amount = (int)numericUpDown1.Value;
                Bettor3.Dog = (int)numericUpDown2.Value;
                textBox3.Text = "Al bets $" + Bettor3.Amount + " on cat number " + Bettor3.Dog;
            }
        }

        // Reset Button
        private void button2_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        // Race Button
        private void button3_Click(object sender, EventArgs e)
        {
            int WinningCat = Factory.SetTheGuyNumber(); // Setting the random winning cat
            int AmountToBeSplit = 0; // The amount taken from losers and split among winners
            int[] WinnersCount = new int[3]; // The count of winners
            int Winning = 0;
            if (Bettor1.Dog == WinningCat)
            {
                Bettor1.winningDog = true;
                WinnersCount[0] = 1;
                Winning++;
            }
            else // Lost
            {
                Bettor1.Cash -= Bettor1.Amount;
                AmountToBeSplit += Bettor1.Amount;
                textBox1.Text = "Joe Lost and now has $" + Bettor1.Cash;
                if (Bettor1.Cash <= 0)
                {
                    textBox1.Text = "BUSTED"; textBox1.ForeColor = Color.Red;
                    radioButton1.Enabled = false;
                }
            }
            if (Bettor2.Dog == WinningCat)
            {
                Bettor2.winningDog = true;
                WinnersCount[1] = 1;
                Winning++;
            }
            else // Lost
            {
                Bettor2.Cash -= Bettor2.Amount;
                AmountToBeSplit += Bettor2.Amount;
                textBox2.Text = "Bob Lost and now has $" + Bettor2.Cash;
                if (Bettor2.Cash <= 0)
                {
                    textBox2.Text = "BUSTED"; textBox2.ForeColor = Color.Red;
                    radioButton2.Enabled = false;
                }
            }
            if (Bettor3.Dog == WinningCat)
            {
                Bettor3.winningDog = true;
                WinnersCount[2] = 1;
                Winning++;
            }
            else // Lost
            {
                Bettor3.Cash -= Bettor3.Amount;
                AmountToBeSplit += Bettor3.Amount;
                textBox3.Text = "Al Lost and now has $" + Bettor3.Cash;
                if (Bettor3.Cash <= 0)
                {
                    textBox3.Text = "BUSTED"; textBox3.ForeColor = Color.Red;
                    radioButton3.Enabled = false;
                }
            }
            // Split to winners and begin new round - or finish depending on money of each.
            if (Winning == 0) // No winners
            {
                if (Bettor1.Cash <= 0 && Bettor2.Cash <= 0 && Bettor3.Cash <= 0)
                {
                    button3.Text = "Game Over \nSuckers";
                    button3.Enabled = false;
                    button1.Enabled = false;
                }
            }
            else if (Winning == 1) // One winner
            {
                for (int i = 0; i < WinnersCount.Length; i++)
                {
                    if (WinnersCount[i] == 1)
                    {
                        IncreaseToWinner(i, AmountToBeSplit);
                        break;
                    }
                }
            }
            else if (Winning == 2) // Two winners
            {
                for (int i = 0; i < WinnersCount.Length; i++)
                {
                    if (WinnersCount[i] == 1)
                    {
                        IncreaseToWinner(i, AmountToBeSplit/2);
                    }
                }
            }
            else if (Winning == 3) // All are winners
            {
                IncreaseToWinner(0, AmountToBeSplit / 3);
                IncreaseToWinner(1, AmountToBeSplit / 3);
                IncreaseToWinner(2, AmountToBeSplit / 3);
            }
        }

        // Method to add the winning amount to the right Person
        void IncreaseToWinner(int x, int Amount)
        {
            if (x == 0)
            {
                Bettor1.Cash += Amount;
                textBox1.Text = "Joe Win and now has $" + Bettor1.Cash;
            }
            if (x == 1)
            {
                Bettor2.Cash += Amount;
                textBox2.Text = "Bob Win and now has $" + Bettor2.Cash;
            }
            if (x == 2)
            {
                Bettor3.Cash += Amount;
                textBox3.Text = "Al Win and now has $" + Bettor3.Cash;
            }
        }
    }
}
