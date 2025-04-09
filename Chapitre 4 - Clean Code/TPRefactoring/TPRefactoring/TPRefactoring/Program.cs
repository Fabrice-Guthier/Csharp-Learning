using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            //pour les besoins du TP, on indique ici le nombre de composants qui seront disponibles dans les réserves
            //dans la réalité, d'autres machines acheminent les composants dans ces réserves et déclenchent le lancement de ce Main
            int initVis = 400;
            int initPetitesPlaques = 100;
            int initGrandesPlaques = 100;

            //on initialise les réserves, les bacs, les robots et les tapis roulants
            List<Reserve> reserves = new List<Reserve>();
            reserves.Add(new Reserve(new Composant("vis", new List<int>{12}), initVis));
            reserves.Add(new Reserve(new Composant("petitePlaque", new List<int>{10, 10}), initPetitesPlaques));
            reserves.Add(new Reserve(new Composant("grandePlaque", new List<int>{10, 30}), initGrandesPlaques));

            TapisRoulant tapis1 = new TapisRoulant();
            TapisRoulant tapis2 = new TapisRoulant();

            List<Produit> produitsRealisables = new List<Produit>();
            produitsRealisables.Add(new Produit("pyramide", new Dictionary<string, int> { { "vis", 12 } , { "petitePlaque", 4 } }));
            produitsRealisables.Add(new Produit("cube", new Dictionary<string, int> { { "vis", 24 } , { "petitePlaque", 6 } }));
            produitsRealisables.Add(new Produit("pavé", new Dictionary<string, int> { { "vis", 24 } , { "petitePlaque", 2 }, { "grandePlaque", 4 } }));

            List<Bac> bacs = new List<Bac>();
            bacs.Add(new Bac(new Produit("pyramide", new Dictionary<string, int> { { "vis", 12 }, { "petitePlaque", 4 } })));
            bacs.Add(new Bac(new Produit("cube", new Dictionary<string, int> { { "vis", 24 }, { "petitePlaque", 6 } })));
            bacs.Add(new Bac(new Produit("pavé", new Dictionary<string, int> { { "vis", 24 }, { "petitePlaque", 2 }, { "grandePlaque", 4 } })));

            RobotAssembleur robotAssembleur = new RobotAssembleur(reserves, produitsRealisables, tapis1);
            RobotEtiqueteur robotEtiqueteur = new RobotEtiqueteur(tapis1, tapis2);
            RobotTrieur robotTrieur = new RobotTrieur(bacs, tapis2);

            //Les robots exécutent leur processus tant qu'ils le peuvent
            while(robotAssembleur.PeutExecuterProcessus() || robotEtiqueteur.PeutExecuterProcessus() || robotTrieur.PeutExecuterProcessus())
            {
                if (robotAssembleur.PeutExecuterProcessus())
                    robotAssembleur.ExecuterProcessus();

                if (robotEtiqueteur.PeutExecuterProcessus())
                    robotEtiqueteur.ExecuterProcessus();

                if (robotTrieur.PeutExecuterProcessus())
                    robotTrieur.ExecuterProcessus();
            }

            //une fois terminé, on affiche les bacs pour les besoins du TP
            robotTrieur.AfficherBacs();

            //pour les besoins du TP, cette ligne empêche la console de se fermer immédiatement
            Console.ReadLine();
        }
    }
}
