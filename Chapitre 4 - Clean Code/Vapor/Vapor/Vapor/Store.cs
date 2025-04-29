using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapor
{
    public class Store
    {
        public List<Game> Games { get; set; }
        public List<Game> GamesWaitingForValidation { get; set; }

        static Store? instance = null;
        public static Store Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Store();
                }
                return instance;
            }
        }

        public Store()
        {
            Games = new List<Game>();
        }

        public void DisplayGames(SortingAlgorithm sortingAlgorithm, string search = null)
        {
            // ici on doit appliquer le S du solid, car on a une méthode qui fait trop de choses, il faut la découper en au moins 3 méthodes: OrderByGames, SearchGames et DisplayGames

            List<Game> GamesToDisplay = new List<Game>();

            switch (sortingAlgorithm)
            {
                case SortingAlgorithm.Name:
                    GamesToDisplay = Games.OrderBy(game => game.Name).ToList();
                    break;
                case SortingAlgorithm.Price:
                    GamesToDisplay = Games.OrderBy(game => game.Price).ToList();
                    break;
                case SortingAlgorithm.Discount:
                    GamesToDisplay = Games.OrderBy(game => game.Discount).ToList();
                    break;
                default:
                    break;
            }

            if (search != null)
                GamesToDisplay = Games.Where(game => game.Name.Contains(search)).ToList();

            if(GamesToDisplay != null)
            {
                foreach (Game game in GamesToDisplay)
                {
                    Console.WriteLine(game);
                }
            }
            else
                Console.WriteLine("No games matching");
        }

        public void SubmitGame(ContentCreator contentCreator, Game game)
        {
            // ici pour le O de solid, on doit override la méthode SubmitGame dans les classes GameStudio et Publisher, car ils n'ont pas la même logique de validation
            if (contentCreator is GameStudio)
            {
                GamesWaitingForValidation.Add(game);
            }
            else if (contentCreator is Publisher)
            {
                Publisher? publisher = contentCreator as Publisher;

                if (publisher.VerifiedPublisher) //publishers can publish without admin verification
                    Games.Add(game);
            }
        }

        public void PublishGame(Game game)
        {
            if(GamesWaitingForValidation.Contains(game))
            {
                Games.Add(game);
                GamesWaitingForValidation.RemoveAll(g => g == game); //safety check : use "RemoveAll" just in case there's multiple copy of the game in this list
            }
        }
    }
}
