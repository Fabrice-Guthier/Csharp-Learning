namespace Play.Catalog.Service.Settings
{
    public class MongoDBSettings
    {
        public string Host { get; init; } 
        // Propriété en lecture seule pour l'hôte MongoDB.
        public int Port { get; init; } 
        // Propriété en lecture seule pour le port MongoDB.
        public string ConnectionString => $"mongodb://{Host}:{Port}"; 
        // Propriété en lecture seule pour la chaîne de connexion MongoDB.
    }
}
