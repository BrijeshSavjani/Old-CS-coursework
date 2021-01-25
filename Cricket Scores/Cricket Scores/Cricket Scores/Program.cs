using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Cricket_Scores
{

    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("How many players?");
            int players = int.Parse(Console.ReadLine());
            int[] Scores = new int[players];
            string[] Player_Names = new string[players];
            string sc;
            for (int player = 0; player < players; player++){
                Console.WriteLine("Please enter the player name");
                string input = Console.ReadLine();
               if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    Player_Names[player] = input;
                    Console.WriteLine(Player_Names[player]);
                }
                else
                {
                    Console.Write(" <--- INVALID NAME!");
                    player = player - 1;
                }
            }
            for (int player = 0; player < players; player++)
            {
                Console.WriteLine("Please enter the player score");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, @"^[0-9]+$"))
                {
                    int inputs = int.Parse(input);
                    Scores[player] = inputs;
                }
                else
                {
                    Console.Write(" <--- INVALID SCORE!");
                    player = player - 1;
                }
            }
            for (int player = 0; player < players; player++)
            {
                if (Scores[player] == 0)
                {
                    sc = "duck";
                }
                else
                {
                    sc = Scores[player].ToString(); 
                }
                Console.WriteLine("Name " + Player_Names[player] + " Score " + sc);
            }
        }
    }
}
