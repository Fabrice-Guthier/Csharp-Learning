using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Game> GamesOwned { get; set; }
        public List<Game> WishList { get; set; }

        public User(string userName, string password)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            GamesOwned = new List<Game>();
            WishList = new List<Game>();
        }
    }
}
