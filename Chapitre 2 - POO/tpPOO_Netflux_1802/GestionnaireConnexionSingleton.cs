using System.Data.Common; // Pour DbConnection
using System.Data.SqlClient; // Exemple pour SQL Server
using System;

public sealed class GestionnaireConnexionSingleton
{
    private static readonly Lazy<GestionnaireConnexionSingleton> instanceParesseuse =
        new Lazy<GestionnaireConnexionSingleton>(() => new GestionnaireConnexionSingleton());

    public static GestionnaireConnexionSingleton Instance => instanceParesseuse.Value;

    private DbConnection _connexionUnique;
    private readonly string _chaineDeConnexion = "Server=ZE-PC-OF-THE-FA\\MSSQLSERVER01;Database=NetfluxDB;User Id=Super_Admin;Password=ySuper_Password;";
    private readonly object _verrouConnexion = new object(); // Pour la synchronisation

    private GestionnaireConnexionSingleton()
    {
        // Ne pas ouvrir la connexion ici ! L'ouvrir seulement quand nécessaire.
        // Mais même cela pose problème (voir ci-dessous).
        _connexionUnique = new SqlConnection(_chaineDeConnexion);
        Console.WriteLine("Singleton de connexion initialisé (connexion non ouverte).");
    }

    // Méthode pour obtenir la connexion (potentiellement dangereuse)
    public DbConnection ObtenirConnexion()
    {
        // Une gestion simpliste (et problématique) de l'ouverture/vérification
        lock (_verrouConnexion)
        {
            try
            {
                if (_connexionUnique.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Ouverture de la connexion unique...");
                    _connexionUnique.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ouverture/vérification de la connexion: {ex.Message}");
                // Que faire ici ? La connexion est peut-être cassée...
                // Toute l'application est bloquée si la connexion échoue.
                throw; // Propage l'erreur, mais l'état est incertain
            }
            return _connexionUnique;
        }
    }

    // Il faudrait aussi une méthode pour fermer PROPREMENT la connexion
    // à la fin de vie de l'application, ce qui est difficile à garantir.
    public void FermerConnexionApplication()
    {
        lock (_verrouConnexion)
        {
            if (_connexionUnique != null && _connexionUnique.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Fermeture de la connexion unique...");
                _connexionUnique.Close();
                _connexionUnique.Dispose(); // Libérer les ressources
            }
        }
    }
}