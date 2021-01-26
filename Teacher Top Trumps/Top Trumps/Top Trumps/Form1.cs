using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using Functions;
using Microsoft.VisualBasic;

namespace Top_Trumps {
    public partial class Form1 : Form   
    {
        //Declare Players
        public Player Player1 = new Player();
        public Player Player2 = new Player();
        public int turns = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Declares Card Deck
            List<Card> Card_Deck = new List<Card>();
            //Open Card Data File
            var Card_Data = new StreamReader("TopTrumpData.txt");
            string line;
            string img_location;
            //Creates a card for each line in document

            while((line = Card_Data.ReadLine()) != null)
            {
                var properties = line.Split(",");
                try
                {
                  img_location = properties[5];
                }
                catch
                { 
                    img_location = "default.png";
                }
                Card_Deck.Add(new Card(properties[0], properties[1], properties[2], properties[3], properties[4], img_location));
               
            }

            //Define Random
            var rnd = new Random();
            try
            {
                //Total Number of loops left = k
                int k = Card_Deck.Count();
                //Total number of cards dealt
                int i = 0;
                while (k >= 0)
                {
                   //Select Random Card
                    Card tmp_var = Card_Deck[rnd.Next(0, Card_Deck.Count())];
                    //Remove selected random card so it can't be picked twice
                    Card_Deck.Remove(tmp_var);
                    //Update amount of loops
                    k = k - 1;
                    //Switch case to Deal cards into player hands
                    switch (i)
                    {
                        //Put in Player1 Hand
                        case < 5:
                            Player1.hand.Add(tmp_var);
                            i = i + 1;
                            break;
                        //Put in Player2 Hand
                        case < 10:
                            Player2.hand.Add(tmp_var);
                            i = i + 1;
                            break;
                      
                    }
                    
                }
            }
            catch
            {
                //Catch all errors
                var error = "ERROR!!";
            }
            string[] values = functions.LoadInformation(Player1);
            pictureBox1.Load(values[5]);
            label2.Text =  values[0];
            label3.Text =  values[1];
            label4.Text =  values[2];
            label5.Text =  values[3];
            label6.Text =  values[4];
            label8.Text = "Player 1 Cards: " + Player1.hand.Count() + " Player 2 Cards: " + Player2.hand.Count();
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            turns = turns + 1;
            string chosen_catergory = comboBox1.Text;
            try
            {
                bool Compare = Functions.functions.CompareCards(comboBox1.Text, Player1, Player2);
               
            }
            catch
            {
                
                MessageBox.Show("Error: Incorect Catergory");   
             }
            //Switch case for each catergory,compare change,player,repaeat until 0 cards left
            //Move functions to seperate file

            string[] values;
            if (turns%2 != 0)
            {
                label1.Text = "Player 1s' Turn";
                values = functions.LoadInformation(Player1);
                Player1.Score = turns - Player2.Score;
            }
            else
            {
                label1.Text = "Player 2s' Turn";
                values = functions.LoadInformation(Player2);
                Player2.Score = turns - Player1.Score;
            }
            pictureBox1.Load(values[5]);
            label2.Text = values[0];
            label3.Text =  values[1];
            label4.Text =  values[2];
            label5.Text =  values[3];
            label6.Text = values[4];
            label8.Text = "Player 1 Cards: " + Player1.hand.Count() + " Player 2 Cards: " + Player2.hand.Count();
            functions.CheckWin(Player1, Player2);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
