using System;
using System.ComponentModel;
using Ships;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Xml.Schema;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.CompilerServices;

namespace BattleShips1
{

   class Program
    {
        static char[,] BoardP1 = new char[9,9];
        static char[,] BoardP2 = new char[9, 9];
        public static List<string> CreatedShips = new List<string>();
        static ship[] shiparray = new ship[3];
        public static List<string> CreatedShipsP2 = new List<string>();
        static ship[] shiparrayP2 = new ship[3];

        //rename
        public static string ShipValidation(string shiptype,int p)
        {
            bool created = false;
            foreach (string item in CreatedShips)
            {
                if (shiptype == item)
                {
                    created = true;
                    break;
                }
            }
            if (created == false)
            {
                switch (shiptype)
                {
                    case "AIRCRAFT CARRIER":
                        if (p == 1)
                        {
                            shiparray[0] = new ship { height = 4, width = 2 };
                            CreatedShips.Add(shiptype.ToUpper());
                        }
                        else
                        {
                            shiparrayP2[0] = new ship { height = 4, width = 2 };
                            CreatedShipsP2.Add(shiptype.ToUpper());
                        }
                        return "AC";
                    case "BATTLESHIP":
                        if (p == 1)
                        {
                            shiparray[1] = new ship { height = 3, width = 4 };
                            CreatedShips.Add(shiptype.ToUpper());
                        }
                        else
                        {
                            shiparrayP2[1] = new ship { height = 3, width = 4 };
                            CreatedShipsP2.Add(shiptype.ToUpper());
                        }
                        return "BSHIP";
                    case "LARGE SHIP":
                        if (p == 1)
                        {
                            shiparray[2] = new ship { height = 5, width = 3 };
                            CreatedShips.Add(shiptype.ToUpper());
                        }
                        else
                        {
                            shiparrayP2[2] = new ship { height = 5, width = 3 };
                            CreatedShipsP2.Add(shiptype.ToUpper());
                        }
                        return "LGSHIP";
                    default:
                        return "false";

                }
            }
            else
            {
                return "false";
            }
        }
        public static string UserCoordinateValidation(string coordinates)
        {
            string[] valid_letters = new string[9] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
            int[] valid_numbers = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string vll = "";
            string vln = "";
            int letter_translated = 0;

            foreach (string letter in valid_letters)
            {
                letter_translated = letter_translated + 1;
                if (letter == coordinates[0].ToString())
                {
                    vll = "valid";
                    break;
                }
            }
            foreach (int number in valid_numbers)
            {
                if (number == int.Parse(coordinates[1].ToString()))
                {
                    vln = "valid";
                    break;
                }
            }
            if (vll == "valid" & vln == "valid")
            {

                return ("Valid," + letter_translated.ToString());
            }
            else
            {
                return ("Invalid");
            }
        }
        public static bool PlaceShip(ship ship, char[,] Board)
        {
            try
            {


                if (ship.vertical == false)
                {
                    for (int y = 0; y < ship.height; y++)
                    {
                        for (int x = 0; x < ship.width; x++)
                        {
                            int x_val = x + ship.starting_coordinate[1];
                            int y_val = y + ship.starting_coordinate[0] - 1;
                            if (Board[x_val, y_val] == 'e')
                            {
                                Board[x_val, y_val] = 'j';
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    for (int y = ship.starting_coordinate[0]; y < ship.starting_coordinate[0] + ship.width; y++)
                    {
                        for (int x = ship.starting_coordinate[1]; x < ship.starting_coordinate[1] + ship.height; x++)
                        {
                            if (Board[x-1, y-1] == 'e')
                            {
                                Board[x-1 , y-1] = 'j';
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
            }
        public static void ShotsFired(string coordinates, char[,] Board)
        {
            string valid = UserCoordinateValidation(coordinates);  
            if (valid.Split(',')[0] =="Valid")
            {
                int i = int.Parse(valid.Split(',')[1]);
                Board[int.Parse(coordinates[1].ToString())-1,i-1] = 'h';
            }
            }
        public static void EmptyBoard(Char[,] Board)
        {
            for (int Y = 0; Y < Board.GetLength(0); Y++)
            {
                for (int X = 0; X < Board.GetLength(0); X++)
                {
                    Board[Y, X] = 'e';
                }
            }
        }
        public static void OutputBoard(Char[,] Board)
        {
            for (int Y = 0; Y < Board.GetLength(0); Y++)
            {
                Console.WriteLine("");
                for (int X = 0; X < Board.GetLength(0); X++)
                {
                    Console.Write(Board[Y, X] + " ");
                }
            }
        }
        public static bool WinCondition (char[,] OpponentBoard)
        {
            foreach (char space in OpponentBoard)
            {
                if (space == 'j')
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
                    {
                        Console.WriteLine("                                     # #  ( )");
                        Console.WriteLine("                                   ___#_#___|__");
                        Console.WriteLine("                               _  |____________|  _");
                        Console.WriteLine("                        _=====| | |            | | |==== _");
                        Console.WriteLine("                  =====| |.---------------------------. | |====");
                        Console.WriteLine("    <--------------------'   .  .  .  .  .  .  .  .   '--------------/");
                        Console.WriteLine("      \\                                                             /");
                        Console.WriteLine("       \\___________________________________________________________/");
                        Console.WriteLine("██████╗░░█████╗░████████╗████████╗██╗░░░░░███████╗░██████╗██╗░░██╗██╗██████╗░░██████╗");
                        Console.WriteLine("██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║░░░░░██╔════╝██╔════╝██║░░██║██║██╔══██╗██╔════╝");
                        Console.WriteLine("██████╦╝███████║░░░██║░░░░░░██║░░░██║░░░░░█████╗░░╚█████╗░███████║██║██████╔╝╚█████╗░");
                        Console.WriteLine("██╔══██╗██╔══██║░░░██║░░░░░░██║░░░██║░░░░░██╔══╝░░░╚═══██╗██╔══██║██║██╔═══╝░░╚═══██╗");
                        Console.WriteLine("██████╦╝██║░░██║░░░██║░░░░░░██║░░░███████╗███████╗██████╔╝██║░░██║██║██║░░░░░██████╔╝");
                        Console.WriteLine("╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░░░░╚═╝░░░╚══════╝╚══════╝╚═════╝░╚═╝░░╚═╝╚═╝╚═╝░░░░░╚═════╝░");





            try

            {
                EmptyBoard(BoardP1);
                EmptyBoard(BoardP2);
                for (int p = 1; p <= 2; p++)
                {
                    for (int i = 1; i <= 3; i++)
                    {


                        Console.WriteLine("For Ship #" + i.ToString() + " Please enter your Ship Type or type Armoury for your availibe options");
                        Console.Read();
                        string shiptype = Console.ReadLine();
                        string createship = ShipValidation(shiptype.ToUpper(),p);
                        if (shiptype.ToUpper() == "ARMOURY")
                        {
                            Console.WriteLine("You have to place 1 Aircraft Carrier, 1 battleship and 1 Large Ship");
                            i = i - 1;
                        }
                        else if (createship == "false")
                        {
                            Console.WriteLine("You have either already created this ship or have entered an invalid ship name!");
                            i = i - 1;
                        }


                        Console.WriteLine("Please enter valid ship starting coordinates");
                        string coordinate_input = Console.ReadLine();
                        string coordinates = UserCoordinateValidation(coordinate_input.ToUpper());



                        if (coordinates.Split(',')[0] == "Valid")
                        {
                            bool Created = false;

                            Console.WriteLine("Please Enter your Ship Orientation (Vertical or Horrizontal): ");
                            string orientation = Console.ReadLine();
                            if (orientation.ToUpper() == "VERTICAL")
                            {
                               
                                switch (createship)
                                {
                                    case "AC":
                                        if (p == 1)
                                        {
                                            shiparray[0].vertical = true;
                                            shiparray[0].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparray[0].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparray[0], BoardP1);
                                        }
                                        else
                                        {
                                            shiparrayP2[0].vertical = true;
                                            shiparrayP2[0].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparrayP2[0].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparrayP2[0], BoardP2);
                                        }
                                        break;

                                    case "BSHIP":
                                        if (p == 1)
                                        {
                                            shiparray[1].vertical = true;
                                            shiparray[1].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparray[1].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparray[0], BoardP1);
                                        }
                                        else
                                        {
                                            shiparrayP2[1].vertical = true;
                                            shiparrayP2[1].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparrayP2[1].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparrayP2[0], BoardP2);
                                        }
                                      
                                        break;
                                    case "LGSHIP":
                                        if (p == 1)
                                        {
                                            shiparray[2].vertical = true;
                                            shiparray[2].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparray[2].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparray[2], BoardP1);
                                        }
                                        else
                                        {
                                            shiparrayP2[2].vertical = true;
                                            shiparrayP2[2].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparrayP2[2].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparrayP2[2], BoardP2);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (createship)
                                {
                                    case "AC":
                                        if (p == 1)
                                        {
                                            shiparray[0].vertical = false;
                                            shiparray[0].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparray[0].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparray[0], BoardP1);
                                        }
                                        else
                                        {
                                            shiparrayP2[0].vertical = false;
                                            shiparrayP2[0].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparrayP2[0].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparrayP2[0], BoardP2);
                                        }
                                        break;

                                    case "BSHIP":
                                        if (p == 1)
                                        {
                                            shiparray[1].vertical = false;
                                            shiparray[1].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparray[1].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparray[0], BoardP1);
                                        }
                                        else
                                        {
                                            shiparrayP2[1].vertical = false;
                                            shiparrayP2[1].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparrayP2[1].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparrayP2[0], BoardP2);
                                        }

                                        break;
                                    case "LGSHIP":
                                        if (p == 1)
                                        {
                                            shiparray[2].vertical = false;
                                            shiparray[2].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparray[2].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparray[2], BoardP1);
                                        }
                                        else
                                        {
                                            shiparrayP2[2].vertical = false;
                                            shiparrayP2[2].starting_coordinate[0] = int.Parse(coordinates.Split(',')[1].ToString()); ;
                                            shiparrayP2[2].starting_coordinate[1] = int.Parse(coordinate_input[1].ToString());
                                            Created = PlaceShip(shiparrayP2[2], BoardP2);
                                        }
                                        break;
                                }
                            }


                            if (Created == true)
                            {
                                if (p == 1)
                                {
                                    OutputBoard(BoardP1);
                                }
                                else
                                {
                                    OutputBoard(BoardP2);
                                }
                                Console.WriteLine("Press any key to continue");
                                Console.Read();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Ships overlap"!);
                                i = -1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Coordinate");
                            i = i - 1;
                        }


                    }
                    Console.WriteLine("Write target coordinates");
                    string target = Console.ReadLine();
                    if (p == 1)
                    {
                        ShotsFired(target, BoardP2);
                        bool won = WinCondition(BoardP2);
                        if (won == true)
                        {
                            Console.WriteLine("Player 1 wins");
                            break;
                        }
                    }
                    else
                    {
                        ShotsFired(target, BoardP1);
                        bool won = WinCondition(BoardP1);
                        if (won == true)
                        {
                            Console.WriteLine("Player 2 wins");
                            break;
                        }
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Check Your Inputs.");


            }
                    }
      }
        }
