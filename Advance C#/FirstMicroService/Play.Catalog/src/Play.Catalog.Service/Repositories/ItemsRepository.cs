using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private const string _collectionName = "items"; 
        // Déclaration d'une constante privée pour le nom de la collection MongoDB ("items").
        private readonly IMongoCollection<Item> _dbCollection; 
        // Déclaration d'un champ privé en lecture seule pour la collection MongoDB d'objets de type Item.
        private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter; 
        // Déclaration d'un champ privé en lecture seule pour le constructeur de filtres MongoDB pour les objets de type Item.

        public ItemsRepository()
            // Constructeur de la classe ItemsRepository.
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017"); 
            // Crée un nouveau client MongoDB en utilisant la chaîne de connexion spécifiée.
            var database = mongoClient.GetDatabase("Catalog");
            // Obtient la base de données "Catalog" à partir du client MongoDB.
            _dbCollection = database.GetCollection<Item>(_collectionName); 
            // Obtient la collection "items" (définie par _collectionName) de la base de données "Catalog" et l'assigne à _dbCollection.
        }

        public ItemsRepository(IMongoDatabase mongoDatabase)
        {
            _dbCollection = mongoDatabase.GetCollection<Item>(_collectionName); 
            // Obtient la collection "items" (définie par _collectionName) de la base de données MongoDB fournie et l'assigne à _dbCollection.
        }

        public async Task<IReadOnlyCollection<Item>> GetAllAsync() 
            // Méthode asynchrone pour récupérer tous les éléments de la collection.
        {
            return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync(); 
            // Utilise le constructeur de filtres pour créer un filtre vide (récupère tous les documents), puis exécute la requête Find et retourne le résultat sous forme de liste asynchrone.
        }

        public async Task<Item> GetByIdAsync(Guid id) 
            // Méthode asynchrone pour récupérer un élément par son ID.
        {
            FilterDefinition<Item> filter = _filterBuilder.Eq(entity => entity.Id, id); 
            // Crée un filtre qui sélectionne les documents où l'ID est égal à l'ID spécifié.
            return await _dbCollection.Find(filter).FirstOrDefaultAsync(); 
            // Exécute la requête Find avec le filtre spécifié et retourne le premier document correspondant ou null si aucun document ne correspond.
        }

        public async Task CreateAsync(Item entity) 
            // Méthode asynchrone pour créer un nouvel élément dans la collection.
        {
            ArgumentNullException.ThrowIfNull(entity); 
            // Vérifie si l'entité est null et lève une exception ArgumentNullException si c'est le cas.
            await _dbCollection.InsertOneAsync(entity); 
            // Insère l'entité dans la collection de manière asynchrone.
        }

        public async Task UpdateAsync(Item entity) 
            // Méthode asynchrone pour mettre à jour un élément existant dans la collection.
        {
            ArgumentNullException.ThrowIfNull(entity);
            // Vérifie si l'entité est null et lève une exception ArgumentNullException si c'est le cas.
            FilterDefinition<Item> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            // Crée un filtre qui sélectionne le document avec l'ID de l'entité à mettre à jour.
            await _dbCollection.ReplaceOneAsync(filter, entity); 
            // Remplace le document correspondant au filtre par l'entité mise à jour de manière asynchrone.
        }

        public async Task DeleteOneById(Guid id) 
            // Méthode asynchrone pour supprimer un élément par son ID.
        {
            FilterDefinition<Item> filter = _filterBuilder.Eq(entity => entity.Id, id); 
            // Crée un filtre qui sélectionne le document avec l'ID spécifié.
            await _dbCollection.DeleteOneAsync(filter); 
            // Supprime le document correspondant au filtre de manière asynchrone.
        }
    }
}
