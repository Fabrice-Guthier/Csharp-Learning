using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CDA
{
    public class GestionnaireSauvegarde : AbstractGestionnaireSauvegarde
    {
        public GestionnaireSauvegarde()
        {
            InitialisationChemin();

            ChargementTableauDesScores();
        }

        public override void InitialisationChemin()
        {
            string nomDeFichier = "meilleursScores.json";
            chemin = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + nomDeFichier;
        }

        public override void ChargementTableauDesScores()
        {
            if (File.Exists(chemin))
            {
                string jsonStringDeserialize = File.ReadAllText(chemin);
                TableauDesScores = JsonSerializer.Deserialize<TableauDesScores>(jsonStringDeserialize);
            }
            else
            {
                TableauDesScores = new TableauDesScores();
            }

            GestionnaireAffichage.AffichageTableauDesScores(TableauDesScores);
        }

        public override void SauvegardeTableauDesScores()
        {
            string jsonString = JsonSerializer.Serialize(TableauDesScores);
            File.WriteAllText(chemin, jsonString);
        }
    }
}
