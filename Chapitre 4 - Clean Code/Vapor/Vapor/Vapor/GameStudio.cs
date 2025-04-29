using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public class GameStudio : ContentCreator
    {
        public GameStudio(string name, List<Game> gamesReleased) : base(name)
        {
        }
    }
}
