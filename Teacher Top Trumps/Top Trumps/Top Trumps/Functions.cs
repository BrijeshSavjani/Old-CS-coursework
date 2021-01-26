using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using Classes;



namespace Functions
{
    class functions
    {
        public static string[] LoadInformation(Player player)
        {
            String[] values = new string[6];
            values[0] = "Name: " + player.hand[0].GetProperty("Name");
            values[1] = "Rating: " + player.hand[0].GetProperty("Rating");
            values[2] = "Glasses: " + player.hand[0].GetProperty("Glasses");
            values[3] = "Coolness: " + player.hand[0].GetProperty("Cool");
            values[4] = "Homework: " + player.hand[0].GetProperty("HWK");
            values[5]= player.hand[0].GetProperty("Image");
            return values;
        }
        public static string CheckWin(Player Player1,Player Player2)
        {
            if(Player1.hand.Count == 0)
            {
                MessageBox.Show(Player1.GetName() + " WINS!!!!!" + "with a score of: " +Player1.Score);
                return "Player1";
            }
            else if (Player2.hand.Count==0){
                MessageBox.Show(Player2.GetName() + " WINS!!!!!" + "with a score of: " + Player2.Score);
                return "Player2";
            }
            return null;
        }
        private static void MoveToBack(Player player)
        {
            Card tmp = player.hand[0];
            player.hand.Remove(tmp);
            player.hand.Add(tmp);
        }
        private static bool SwapCards(string swap_direction, Player Player1,Player Player2)
        {
            Card tmp;
            switch (swap_direction)
            {
                case "1->2":
                    tmp = Player1.hand[0];
                    Player1.hand.Remove(tmp);
                    Player2.hand.Add(tmp);
                    MoveToBack(Player1);
                    MoveToBack(Player2);
                    return true;
                case "2->1":
                    tmp = Player2.hand[0];
                    Player2.hand.Remove(tmp);
                    Player1.hand.Add(tmp);
                    MoveToBack(Player1);
                    MoveToBack(Player2);
                    return true;

            }
            return false;
        }
        private static float Glasses(Player player)
        {
            if (player.hand[0].GetProperty("Glasses") == "True")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static bool CompareCards(string catergory, Player Player1, Player Player2)
        {
            float a;
            float b;
           if (catergory == "Glasses")
            {
                a = Glasses(Player1);
                b = Glasses(Player2);
            }
            else
            {
                a = float.Parse(Player1.hand[0].GetProperty(catergory));
                b = float.Parse(Player2.hand[0].GetProperty(catergory));
            }
            if(a > b)
            {
                SwapCards("2->1", Player1, Player2);
                MessageBox.Show("Player1");
                return true;
            }
            else if (a < b)
            {
                SwapCards("1->2",Player1,Player2);
                MessageBox.Show("Player2");
                return true;
            }
            else
            {
                MoveToBack(Player1);
                MoveToBack(Player2);
                return false;
            }

        }
    }
}
