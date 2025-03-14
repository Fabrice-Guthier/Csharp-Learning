# Ajout du repository pattern en utilisant MongoDB

## Créer notre repository
- Ajoutez un dossier Entities, dans ce dossier, créez une classe Item (qui sera note entité pour un item)
```cs 
public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
```
- Ajoutez le package Nuget MongoDB.Driver en faisant un clique droit sur le projet, puis "Gérer les packages Nuget". Cherchez le package (dans l'onglet "Parcourir"), le package MongoDB.Driver et installez-le.
- Ajouteé un dossier "Repositories", ce dossier va contenir notre / nos classes d'accès aux données et de communication avec la base de données. 
- Ajoutez-y une classe ItemsRepository
- Ajouter les variables pour MongoDB
    - collectionName, qui contiendra le nom de la collection (ensemble de document en MongoDB)
    - dbCollection (IMongoCollection<Item>), qui contiendra l'accès à la collection souhaitée pour nos items
    - filter, qui contiendra les filtres nécessaires à la récupération de données pour notre CRUD
```cs
private const string _collectionName = "items";
private readonly IMongoCollection<Item> _dbCollection;
private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
```
- Ajouter le constructeur qui initialise les propriétés précédentes
```cs
public ItemsRepository()
{
    var mongoClient = new MongoClient("mongodb://localhost:27017");
    var database = mongoClient.GetDatabase("Catalog");
    _dbCollection = database.GetCollection<Item>(_collectionName);
}
``` 
- Ajouter les méthodes de travail avec la base de données (Je ne rentre pas trop dans le détails des explications ici, car c'est de l'utilisation classique de MongoDB avec .Net et ça n'est pas le but du cours. Petite attention particulière cependant sur le fait que l'on passe toutes les méthodes en asynchrone avec les mots clés async / await et la classe Task, je vous l'expliquerai à l'oral)
    - GetAllAsync()
    - GetByIdAsync(Guid id)
    - CreateAsync(Item entity)
    - UpdateAsync(Item entity)
    - DeleteOneById(Guid id)
```cs
public async Task<IReadOnlyCollection<Item>> GetAllAsync()
{
    return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
}

public async Task<Item> GetByIdAsync(Guid id)
{
    FilterDefinition<Item> filter = _filterBuilder.Eq(entity => entity.Id, id);
    return await _dbCollection.Find(filter).FirstOrDefaultAsync();
}

public async Task CreateAsync(Item entity)
{
    ArgumentNullException.ThrowIfNull(entity);

    await _dbCollection.InsertOneAsync(entity);
}

public async Task UpdateAsync(Item entity)
{
    ArgumentNullException.ThrowIfNull(entity);

    FilterDefinition<Item> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);

    await _dbCollection.ReplaceOneAsync(filter, entity);
}

public async Task DeleteOneById(Guid id)
{
    FilterDefinition<Item> filter = _filterBuilder.Eq(entity => entity.Id, id);

    await _dbCollection.DeleteOneAsync(filter);
}
```

## Définir un moyen de traduire un item en itemDto
- Mettre en place une Extension, cette extension va nous donner la possibilité de convertir un Item (Entity) en ItemDto (Dto). Le DTO étant l'objet que l'on va passer en retour de notre API.
- Ici, il suffit de créer un dossier "Extensions", avec une classe "ItemsExtensions" dedans.
- Cette méthode va permettre de pouvoir être directement appelée sur chaque objet de type Item pour le transformer en DTO.
- Notez que la classe est en static et la particularité du this dans le paramètre, c'est là ce qui permet de l'utiliser sur n'importe quel objet de type Item
```cs
public static class ItemsExtension
{
    public static ItemDto AsDto(this Item item)
    {
        return new ItemDto(item.Id, item.Name, item.Description, item.Price);
    }
}
```
## Adapter notre controller
- Maintenant qu'on a changer notre accès au données, il nous faut modifier notre controller afin d'appeler les méthodes de notre Repository
- Notez bien l'ajout de Task sur chacun des retours & l'ajout d'une propriété ItemRepository (que l'on changera en injection de dépendances après pour comprendre le principe). Ainsi que l'utilisation des mots clés async et await à nouveau.
- Modifier les méthodes du Controller de la sorte, prenez le temps de comprendre le code, mais il n'y a rien de bien compliqué, à part peut être l'objet FilterDefinition qui nous permet de filtrer les données que l'on souhaite récupérer :
```cs
private readonly ItemsRepository _itemsRepository = new ItemsRepository();

[HttpGet]
public async Task<IEnumerable<ItemDto>> GetAsync()
{
    return (await _itemsRepository.GetAllAsync()).Select(item => item.AsDto());
}

[HttpGet("{id}")]
public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
{
    var item = await _itemsRepository.GetByIdAsync(id);

    if (item == null)
        return NotFound();

    return item.AsDto();
}

[HttpPost]
public async Task<ActionResult<ItemDto>> CreateAsync(CreateItemDto createItemDto)
{
    var item = new Item 
    {
        Name = createItemDto.Name,
        Description = createItemDto.Description,
        Price = createItemDto.Price
    };

    await _itemsRepository.CreateAsync(item);

    return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
}

[HttpPut("{id}")]
public async Task<IActionResult> UpdateAsync(Guid id, UpdateItemDto updateItemDto)
{
    var existingItem = await _itemsRepository.GetByIdAsync(id);

    if (existingItem == null)
        return NotFound();

    existingItem.Name = updateItemDto.Name;
    existingItem.Description = updateItemDto.Description;
    existingItem.Price = updateItemDto.Price;

    await _itemsRepository.UpdateAsync(existingItem);

    return NoContent();
}

[HttpDelete("{id}")]
public async Task<ActionResult<Guid>> DeleteAsync(Guid id)
{
    var existingItem = await _itemsRepository.GetByIdAsync(id);

    if (existingItem == null)
        return NotFound();

    await _itemsRepository.DeleteOneById(existingItem.Id);

    return existingItem.Id;
}
```
- Attention à bien penser à ajouter une option dans notre Program.cs pour éviter que les AsyncSuffix soient retirés à la compilation, ça c'est un cas particulier car on utilise CreatedAtAction, qui utilise les noms de classes après compilation et .Net a décidé en .Net 3 (je crois), de retirer les suffixe Async à la compilation.
- Donc on va remplacer le builder.Services.AddControllers() simple par ceci :
```cs
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
```

## Mise en place de l'injection de dépendance
- La première étape est d'extraire une interface de notre ItemRepository, pour cela, cliquez droit sur le nom de votre classe et faite "Extraire l'interface", normalement, aucune option a changer, mais vérifiez bien que ça va le créer dans un nouveau fichier.
- Vous devriez avoir quelque chose comme ça :
```cs
public interface IItemsRepository
{
    Task CreateAsync(Item entity);
    Task DeleteOneById(Guid id);
    Task<IReadOnlyCollection<Item>> GetAllAsync();
    Task<Item> GetByIdAsync(Guid id);
    Task UpdateAsync(Item entity);
}
```
- Ensuite, on va changer la façon de gérer notre propriété _itemRepository dans notre controller et utiliser l'injection de dépendance par contructeur :
```cs
//private readonly ItemsRepository _itemsRepository = new ItemsRepository();

private readonly IItemsRepository _itemsRepository;

public ItemsController(IItemsRepository itemsRepository)
{
    _itemsRepository = itemsRepository;
}
```
- De même dans notre constructeur du repository, on va utiliser l'injection de dépendance pour la database, comme ceci :
```cs
//public ItemsRepository()
//{
//    var mongoClient = new MongoClient("mongodb://localhost:27017");
//    var database = mongoClient.GetDatabase("Catalog");
//    _dbCollection = database.GetCollection<Item>(_collectionName);
//}

public ItemsRepository(IMongoDatabase mongoDatabase)
{
    _dbCollection = mongoDatabase.GetCollection<Item>(_collectionName);
}
```
- Maintenant, il nous faut réaliser les paramétrages nécessaires afin de gérer efficacement cette injection de dépendance

## Paramétrage du service pour notre base de données
- Pour démarrer, on va modifier le fichier appsettings.json, afin d'y ajouter nos éléments de configuration. On va rajouter ces deux noeuds dans le fichier (attention, j'ai bien dit ajouter, pas remplacer) : 
```json 
"ServiceSettings": {
  "Name": "Catalog"
},
"MongoDBSettings" :  {
  "Host": "localhost",
  "Port": 27017
},
```
- On va créer un dossier Settings, et y créer une classe par settings que l'on a ajouter, donc une classe "ServiceSettings" et une classe "MongoDBSettings". Faites bien attention à avoir le bon nom de classe qui correspond exactement à votre nom de noeud.
- Chacune des classe va avoir des propriétés pour binder les sous noeuds à ces dernières (notez le init, à la place du set, son but est de permettre d'initialiser la valeur et ne pas pouvoir la changer par la suite. Un set aurait fonctionné ici aussi, mais bon, on veut pas modifier à la volée ces valeurs, elles doivent rester invariables):
```cs
// fichier ServiceSettings.cs
public class ServiceSettings
{
    public string Name { get; init; }
}

// fichier MongoDBSettings.cs
public class MongoDBSettings
{
    public string Host { get; init; }
    public int Port { get; init; }
    public string ConnectionString => $"mongodb://{Host}:{Port}";
}
```
- Pour terminer notre injection de dépendance et nos paramétrage, il va falloir faire des modifications dans le Program.cs, ces dernières sont un peu particulières, je vais vous les expliquer à l'oral, mais voici les infos :
    - On utilise BsonSerializer afin de modifier le format de nos données dans le document (donc dans la base de données), les id on veut qu'ils aient une tête de Guid en chaîne de caractères et pareil pour le decimal, on veut un decimal simple en chaîne de charactère
    - On créer une variable serviceSettings qui va récupérer et binder les éléments de SettingsService que l'on a créé précédemment
    - On utiliser builder.Services.AddSingleton() de deux façons :
        - Une façon avec un serviceProvider, qui va initialiser notre base mongoDB
        - Une façon avec AddSingleton<IItemsRepository, ItemsRepository>(); qui aura pour but de définir à notre création de notre repository, on va utiliser l'injection de dépendance avec un type ItemsRepository "automatiquement". 
- Voici à quoi doit ressembler votre Program.cs maintenant : 
```cs
var builder = WebApplication.CreateBuilder(args);
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.String));

var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSingleton(serviceProvider =>
{
    var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
    var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
    return mongoClient.GetDatabase(serviceSettings.Name);
});

builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();

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

## Utilisation de Docker pour démarrer MongoDB & Installation de l'extension MongoDB dans VSCode
- Bon, on a tout fait, mais on n'a toujours pas MongoDB qui tourne sur notre machine... Donc on va utiliser Docker pour lancer un conteneur MongoDB.
- Lancer la commande (depuis n'importe quel terminal). Celle ci va utiliser une image `mongo` pour démarrer un conteneur Mongo DB. Celui ci sera nommé mongodb, tournera sur le port 27017 en local et sera bindé au port 27017 du conteneur et utilisera un volume (pour la persistance des données même si on redémarre le conteneur) qui sera nommé localmongovolume en local, vous l'aurez compris et /data/db dans le conteneur (c'est ici que par défaut les données sont gérées avec mongo dans le conteneur)
```sh
docker run -d --name mongodb -p 27017:27017 -v localmongovolume:/data/db mongo
```

## Testez votre API avec Swagger
- Commencez par ajouter un item en utilisant la route POST, rien de nouveau ici, je vous laisse jouer avec Swagger pour tester toutes les opérations CRUD que l'on a réalisées !