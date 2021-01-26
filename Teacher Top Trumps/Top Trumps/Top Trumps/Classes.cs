using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{

    public class Card
    {
        //Properties
        private string Name;
        private float Rating;
        private bool Glasses;
        private float Coolness;
        private int HWK;
        private string Image;
        //Constructors
        public Card(string name, string rating, string glasses, string cool, string hwk,string image)
        {
            Name = name;
            Rating = float.Parse(rating);
            Glasses = bool.Parse(glasses);
            Coolness = float.Parse(cool);
            HWK = int.Parse(hwk);
            Image = image;
        }
        public string GetProperty(string item)
        {
            switch (item)
            {
                case "Name":
                    return Name;
                case "Rating":
                    return Rating.ToString();
                case "Glasses":
                    return Glasses.ToString();
                case "Cool" or "Coolness":
                    return Coolness.ToString();
                case "HWK":
                    return HWK.ToString();
                case "Homework":
                    return HWK.ToString();
                case "Image":
                    return Image;
            }
            return "error";
        }

    }       public class Player
        {
            public List <Card> hand = new List <Card>();
            public int Score;
            string name;
            public string GetName()
        {
            return name;
        }


        }
    }
