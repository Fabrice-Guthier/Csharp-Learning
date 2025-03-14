# Transformer son repository en repo generique
- Cette partie est totalement optionnelle pour la compréhension des microservices, mais elle est utile dans le cas où l'on veut respecter le DRY principle
- Le but de cette partie est donc de rendre notre repository générique afin qu'il n'y ai pas à répéter le code nécessaire pour créer un repository
- On va : 
    - Rendre le repository générique (et faire les modifications en conséquences dans l'utilisation par le Controller)
    - Mettre en place des extensions pour simplifier la partie de déclaration de service et des settings dans le Program.cs
    - Créer un package Nuget que l'on pourra réutiliser dans tous nos services. Pour info, on ne fait pas un service Common, mais un package Common car les microservices doivent être indépendant les uns des autres, utiliser un package Nuget permettra d'avoir les implémentations de nos éléments commun dans un package importé par nos services (donc plus simple pour la gestion du versionning etc... Sachant que la partie Common est une partie qui ne devrait pas être amenée à changer régulièrement)

## Rendre notre entité générique
- Notre entité Item actuellement utilisée n'est pas générique, on va donc en extraire une interface et uniqument forcer l'utilisation d'une propriété Id de type Guid :
```cs
public interface IEntity
{
    Guid Id { get; set; }
}
```
- Notre class Item doit implémenter cette interface (mais en soit, rien à changer dedans car on a déjà une propriété Guid Id): 
```cs
public class Item : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
```
- Vous le constatez, mais on n'a pas encore vraiment mis en place de généricité ici, mais l'interface est importante pour la suite

## Rendre notre item repository générique
- On va devoir changer plusieurs choses dans notre classe actuelle IItemsRepository, déjà son nom (fichier et classe), remplacez le par IRepository.
- Cette classe va maintenant devoir être générique, on lui applique donc l'opérateur de généricité : <T>, comme ceci :
```cs
public interface IRepository<T> where T : IEntity
```
- On a donc dit qu'on aura un repo pour le type générique T, ou T doit implémenter IEntity (l'interface créée dans la partie précédente)
- On doit également changer légèrement l'implémentation des méthodes de cette classe pour utiliser le type générique, on va en soit juste remplacer Item par T :
```cs
public interface IRepository<T> where T : IEntity
{
    Task CreateAsync(T entity);
    Task DeleteOneById(Guid id);
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
}
```

## Rendre notre database générique
- On va appliquer le même principe pour notre implémentation de IRepository (anciennement IItemsRepository), on va renommer le fichier en MongoRepository et le rendre générique :
```cs
public class MongoRepository<T> : IRepository<T> where T : IEntity
```
- On va retirer la propriété en dur dans cette classe de collectionName et la passer en paramètre du constructeur
- & egalement modifier les types Item en T, comme ceci : 
```cs
public class MongoRepository<T> : IRepository<T> where T : IEntity
{
    private readonly IMongoCollection<T> _dbCollection;
    private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public MongoRepository(IMongoDatabase mongoDatabase, string collectionName)
    {
        _dbCollection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        FilterDefinition<T> filter = _filterBuilder.Eq(entity => entity.Id, id);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        FilterDefinition<T> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);

        await _dbCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteOneById(Guid id)
    {
        FilterDefinition<T> filter = _filterBuilder.Eq(entity => entity.Id, id);

        await _dbCollection.DeleteOneAsync(filter);
    }
}
```

## Modifier l'utilisation dans notre Controller 
- Maintenant que nous avons tout rendu générique, nous devons modifier notre utilisation dans notre Controller, pour celà, il suffit de remplacer par les nouveaux noms (IItemsRepository => IRepository<Item>)
- Vous n'avez qu'a remplacer la propriété et le paramètre du constructeur :
```cs
private readonly IRepository<Item> _itemsRepository;

public ItemsController(IRepository<Item> itemsRepository)
{
    _itemsRepository = itemsRepository;
}
```
- La partie généricité est terminée, mais pour aller jusqu'au bout des choses, on va aussi rendre la mise en place des services et settings de notre Program.cs plus générique

## Rendre notre Program.cs plus générique
- On va réutiliser le principe d'extensions pour rendre le Program.cs et la déclaration des services et des injections de dépendances plus générique.
- Dans votre dossier Extensions, ajoutez une classe ServiceExtensions.cs
- On va récupérer le code de Program.cs et le mettre dans deux méthodes qui seront appelée pour chacun de nos services
- Voici les méthodes à créer : 
```cs
 public static class ServiceExtension
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.String));

        services.AddSingleton(serviceProvider =>
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
            var mongoDbSettings = configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
            var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
            return mongoClient.GetDatabase(serviceSettings.Name);
        });

        return services;
    }

    public static IServiceCollection AddMongoRespository<T>(this IServiceCollection services, string collectionName) 
        where T : IEntity
    {

        services.AddSingleton<IRepository<T>>(serviceProvider =>
        {
            var database = serviceProvider.GetService<IMongoDatabase>();
            return new MongoRepository<T>(database, collectionName);
        });

        return services;
    }
}
```
- Je ne rentre pas trop dans le détail ici, c'est presque exactement la même chose que ce que l'on avait avant, sauf qu'on le met dans une extension pour s'en simplifier l'appel.

## Appeler les extensions dans notre Program.cs
- Maintenant, il nous faut simplifier notre Program.cs pour appeler ces extensions et ça se fait très facilement. Je mets le contenu complet du Program.cs, mais avec les commentaires, vous pourrez voir ce qui a changé :
```cs
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Extensions;
using Play.Catalog.Service.Settings;

var builder = WebApplication.CreateBuilder(args);
var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

// On utilise les extensions que l'on a créer pour simplifier notre appel
builder.Services
    .AddMongo()
    .AddMongoRespository<Item>("items");
// Fin de la modification, rien d'autre n'a changé !

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
```
- Le fait de pouvoir appeler deux méthodes à la suite en .Net c'est l'utilisation du principe Fluent, à notre niveau, c'est juste une syntaxe d'utilisation de nos méthodes d'extensions que l'on chaîne.
- Voilà tout est générique maintenant ! Il ne nous reste plus qu'à mettre ça dans un projet séparé pour pouvoir l'appeler dans nos différents services.

## Créer un projet Common
- Créer un nouveau dossier à la racine (donc au même niveau que Play.Catalog) nommé "Play.Common"
- Créer un sous dossier "src"
- Exécutez la commande suivante dans ce dossier src : 
```sh
dotnet new classlib -n Play.Common
```
- Cette fois, on créer une librarie de classes (classlib) et pas une webapi.
- Nous allons avoir besoin de 4 packages Nuget à ajouter à ce projet (clique droit, gérer les packages Nuget et aller dans l'onglet "Parcourir") :
    - MongoDB.Driver
    - Microsoft.Extensions.Configuration
    - Microsoft.Extensions.Configuration.Binder
    - Microsoft.Extensions.DependencyInjection
- Déplacer les éléments (provenant de Play.Catalog.Service) que l'on va rendre commun dans ce projet
- Commencez par créer les dossiers (dans le projet Play.Common) les dossiers suivants :
    - Entities
    - Extensions
    - Repositories
    - Settings
- **Pour chaque fichier que l'on va déplacer, il faudra changer le namespace en Play.Common.FolderName**
- Déplacez les fichiers suivants :
    - IEntity dans Entities
    - ServiceExtension dans Extensions
    - IRepository & MongoRepository dans Repositories
    - MongoDBSettings & ServiceSettings dans Settings
- Pour chaque fichier, je le rappel, pensez à changer le namespace et faites les imports dont vous aurez besoin (il y en a pas mal à faire, mais il suffit de faire CTRL+; sur tous les éléments souligné en rouge et vous devriez trouver les imports provenant de ce nouveau projet dans Play.Common)
- On va en profiter pour ajouter une implémentation de recherche via des filtres dans notre repository :
```cs
public interface IRepository<T> where T : IEntity
{
    Task CreateAsync(T entity);
    Task DeleteOneById(Guid id);
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    Task<T> GetByIdAsync(Guid id);
    Task<T> GetAsync(Expression<Func<T, bool>> filter);
    Task UpdateAsync(T entity);
}
```
- On a donc ajouté une méthode GetAllSync avec un filtre et une méthode GetAsync avec un filtre que nous allons devoir implémenter dans notre MongoRepository :
```cs
public class MongoRepository<T> : IRepository<T> where T : IEntity
{
    private readonly IMongoCollection<T> _dbCollection;
    private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public MongoRepository(IMongoDatabase mongoDatabase, string collectionName)
    {
        _dbCollection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbCollection.Find(filter).ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        FilterDefinition<T> filter = _filterBuilder.Eq(entity => entity.Id, id);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        FilterDefinition<T> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);

        await _dbCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteOneById(Guid id)
    {
        FilterDefinition<T> filter = _filterBuilder.Eq(entity => entity.Id, id);

        await _dbCollection.DeleteOneAsync(filter);
    }
}
```

## En faire un package nuget
- Pour ce faire, une simple commande suffit (à exécuter dans le dossier src/Play.Common), la voici : 
```sh
dotnet pack -o ../../../packages/
```
- Ceci va créer un fichier .nupkg dans le dossier packages (qui se créer automatiquement via la commande) a la racine de notre solution. 

## Utiliser le package nuget
- De retour sur notre projet Play.Catalog, nous allons utiliser le nuget package que nous venons de créer, pour ce faire, il nous faut ajouter une source de package nuget (actuellement, on n'a que celle qui provient d'internet)
- Clique droit sur votre projet Play.Catalog, puis gérer les packages Nuget
- En faut à droite, vous devriez avoir un écrou pour paramétrer vos packages Nuget, cliquez dessus
- Ceci ouvre une pop-up contenant vos sources de package nuget
- Cliquez sur le "+" vert en haut à droite de cette pop-up
- Dans nom mettez par exemple "LocalPackages"
- Dans source, cliquez sur les "..." et allez sélectionner le dossier "packages" qui a été créé das l'étape précédente
- Fermez cette pop-up
- En haut à droite toujours, vous pouvez choisir la nouvelle source précédemment créer pour récuperer vos packages nuget
- Choisissez "LocalPackages"
- Recherchez Play.Common et installez la dépendance
- Maintenant, nous devons supprimer les fichiers qui sont présents dans Play.Catalog.Service :
    - IEntity
    - Le dossier Repositories complet
    - Le dossier Settings complet
    - L'extension ServiceExtensions
- Ceci va nous forcer à changer les imports pour ces éléments et donc utiliser ceux de Play.Common
- Faites les changements nécessaires dans les différents fichiers (tous quasiment, c'est souligné en rouge et vous pouvez faire CTRL+; pour corriger les imports provenant de Play.Common)

## Testez que tout fonctionne encore correctement
- En démarrant votre projet Play.Catalog, vous risquez d'avoir un message concernant le Debug dégradé, osef, vous pouvez mettre "Continuer le debug (ne plus demander)"
- Testez votre CRUD complet, comme d'habitude, vous pouvez utiliser Swagger ou Postman, comme vous préférez (personnellement, j'ai une préférence pour Postman)