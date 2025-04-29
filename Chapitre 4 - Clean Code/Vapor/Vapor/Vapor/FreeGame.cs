using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public class FreeGame : Game
    {
        // faire une classe intermédiaire entre Game et FreeGame, genre PricedGame, qui elle va avoir les propriétés Price et Discount, pour éviter les acrobaties de prix et de remise forcés à 0 pour un jeu gratuit

        public override float Price { get => 0; }
        public override int Discount { get => 0; }

        public FreeGame(string name, float price, int yearReleased, GameStudio gameStudio, int discount = 0) : base(name, price, yearReleased, gameStudio, discount)
        {
            price = 0;
            discount = 0;
        }

        public override float GetCurrentPrice()
        {
            return 0;
        }
    }
}
