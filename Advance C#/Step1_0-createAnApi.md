# Création de notre premier service sous forme d'API simple
## Information pour ceux qui veulent réaliser l'exercice sur un repo git (conseillé)
- Pensez à mettre un fichier .gitignore à la racine de votre repo git !
- Voici un template .Net que vous pouvez utiliser : [template .gitgnore en .Net](https://github.com/dotnet/dotnet-template-samples/blob/master/.gitignore)
- Copiez / collez l'intégralité du contenu (vous avez un bouton copy raw file, en logo avec deux rectangles qui se superposent en haut à droite du contenu du fichier) dans votre fichier .gitignore que vous avez crée à la racine de votre repo (en local donc)

## Création de la solution et du projet
- Créez un dossier vide, nommé par exemple "FirstMicroservice"
- Ouvrez un terminal de commande dans ce dossier (clique droit, ouvrir le terminal ou alors faites le depuis VSCode)
- Pour créer une solution, utilisez la commande ```dotnet new sln```
    - Ceci va créer un fichier .sln qui sera celui qui nous permettra d'ouvrir notre projet avec Visual Studio
- Créez un dossier "Play.Catalog" : ```md Play.Catalog``` 
- Déplacez vous dans ce dossier : ```cd Play.Catalog```
- Créez un dossier "src" : ```md src``` -> Ce dossier contiendra le projet
- Déplacez vous dans ce dossier : ```cd src```
- Créez un projet d'api web avec la commande ```dotnet new webapi -n Play.Catalog.Service```
    - Cette commande va vous mettre à disposition un projet avec les bases pour avoir une API
    - C'est cette commande qui créer le projet et le fichier .csproj du projet
- Le projet n'est pour l'instant pas connu de la solution, il faut donc l'ajouter :
    - Ouvrez le fichier .sln depuis votre explorateur de fichier, double clique sur le fichier .sln et si ça n'est pas déjà fait, choisissez Visual Studio comme outil pour ouvrir les fichier .sln par défaut
    - Sur la solution, en haut à droite, faites un clique droit, puis "Ajouter" -> "Projet existant" et allez chercher le .csproj qui a été créé précédemment
- Première étape terminée, nous avons créé une API et elle se trouve dans notre solution !
- Si vous démarrez votre projet, vous devriez avoir Swagger qui s'affiche dans votre navigateur avec le endpoint de la météo par défaut.

## Passage d'une minimal API à une API structurée
- Par défaut, aujourd'hui, .Net créé une minimal API, dans notre cas, nous allons faire une API plus complète en utilisant les controlleurs et les DTOs.
- Avec une minimal API, quasiment tout se fait directement dans le Program.cs (vous avez même par défaut un exemple avec un endpoint pour la météo)
- Nous allons remplacer le fichier Program.cs par ce contenu : 
```cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
```
- Ici, on a juste retiré les éléments par défaut pour l'API de météo et nous avons ajouté de quoi utiliser des Controllers avec :
```cs 
builder.Services.AddControllers();
// Et plus bas
app.MapControllers();
```

## Mise en place des DTOs
- Pour rappel, les DTOs sont les Data Transfer Object qui vont nous permettre de proposer un format commun et qui ne changera pas pour notre front (que l'on gèrera biiiiien plus tard)
- Ces objets vont être fait sous forme de record, pour leur simplicité et les autres avantages présentés en cours
- Vous pouvez donc créer un dossier "Dtos" dans votre projet Play.Catalog.Service (clique droit sur le projet, ajouter, nouveau dossier)
- Nous allons gérer un catalogue d'items, voici donc la classe que vous devez créer "ItemDto" dans ce dernier dossier
- Et voici un exemple de Dtos que vous pouvez avoir :
```cs
namespace Play.Catalog.Service.Dtos
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price);
    public record CreateItemDto(string Name, string Description, decimal Price);
    public record UpdateItemDto(string Name, string Description, decimal Price);
}
```
- Le Guid est un Id qui sera auto généré par .Net et qui sera plus sécurisé qu'un identifiant en int auto incrémenté, j'ai dû vous expliquer pourquoi et si je ne l'ai pas fait, demandez-moi !

## Mise en place de notre premier Controller
- Dans ce même projet et de la même façon, créez un dossier "Controllers"
- Puis ajoutez y une classe "ItemsController"
- Cette classe va devoir hériter de ControllerBase et utiliser l'attribut [ApiController] + [Route("items")](donc ajoutez : ControllerBase à la fin de votre ligne de classe ainsi que les attributs) :
```cs
[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    // ... Le code de l'api viendra ici
}
```
- Ceci va permettre de spécifier que les endpoints que l'on va créer seront lié à l'url /items. Par exemple https://localhost:5001/items (**attention**, nous n'avons pas paramétré explicitement le port utilisé, **votre port peut donc être différent** ! En lançant votre projet, l'url et le port s'affiche sur la page qui s'ouvre dans votre navigateur)
- Sinon, vous pouvez configurer vous même le port utiliser dans le fichier launchSettings.json déjà présent dans le dossier Properties (par défaut à la création d'une WebApi)
- Modifiez les ports dans les noeuds "profiles" et "https" et mettez les valeurs que vous voulez, personnellement j'utilise 5000 pour le http et 5001 pour le https
- Maintenant, nous allons créer les différentes routes suivantes : 
    - GET /items
    - GET /items/{id}
    - POST /items
    - PUT /items/{id}
    - DELETE /items/{id}
- Mais d'abord, nous allons créer une liste d'ItemDto que nous allons pouvoir utiliser pour nos tests, celle ci sera static afin de nous éviter de l'instancier plusieurs fois pour chaque appels
- Dans votre classe, ajoutez ceci : 
```cs
private static List<ItemDto> items = new List<ItemDto>
{
    new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5),
    new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison to character", 7),
    new ItemDto(Guid.NewGuid(), "Tiny sword", "Deals a small amount of damage", 10),
};
```

### La route GET /items
- Ajoutez une méthode pour récupérer la liste de tous les items
- Cette méthode va seulement retourner un Enumerable de ItemDto (ce qui veut dire une liste d'items qui est itérable, mais ça n'est pas le sujet ici)
- Voici le code de votre route GET, essayez en même temps de comprendre bien entendu
```cs
[HttpGet]
public IEnumerable<ItemDto> Get()
{
    return items;
}
```
- C'est donc un simple endpoint en GET, sur la route principale qui est /items je le rappelle et qui retourne l'intégralité des items de notre liste

### La route GET /items/{id}
- Ajoutez une méthode pour récupérer un item par son id
- Cette méthode va retourner un ItemDto
- Voici le code votre route :
```cs
[HttpGet("{id}")]
public ItemDto GetById(Guid id)
{
    var item = items.Where(item => item.Id == id).FirstOrDefault();
    return item;
}
```
- Ici, on utilise LinQ pour récupérer un item en particulier de la liste (si vous ne connaissez pas LinQ, vous auriez pu faire autrement simplement en parcourant la liste avec un foreach et retourner l'item correspondant à l'id passé en paramètre)
- Afin de s'assurer que l'id correspond bien à un item existant dans notre liste, on peut vérifier que l'identifiant passé en paramètre est bien existant. Ceci nécessite deux choses, la vérification et changer le type de retour en ActionResult<ItemDto> afin de pouvoir retourner un NotFound() qui retournera directement un status code 404 propre.
- Voici le nouveau code :
```cs
[HttpGet("{id}")]
public ActionResult<ItemDto> GetById(Guid id)
{
    var item = items.Where(item => item.Id == id).FirstOrDefault();

    if (item == null)
    {
        return NotFound();
    }

    return item;
}
```

### La route POST /items
- De même, on va ajouter une nouvelle route pour ajouter un item dans la liste
- Voici le code :
```cs
[HttpPost]
public ActionResult<ItemDto> Create(CreateItemDto createItemDto)
{
    var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price);

    items.Add(item);

    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
}
```
- Bon, je me suis permis une petite fantaisie non obligatoire sur le return, qui permets d'utiliser notre route GetById en retour de cette méthode via le CreatedAtAction. Ceci permet de retourner l'appel de la méthode GetById. Le premier paramètre est le nameof(GetById) pour notre méthode appelée, le second paramètre est l'identifiant passé à cette méthode (celui qui a été généré par notre Guid.NewGuid()) et le dernier, le retour voulu de cette méthode, donc l'item en lui même.
- Mais on aurai pu rien retourner, ou retourner un id seulement ou même retourner directement un ItemDto de notre objet.

### La route PUT /items/{id}
- On va également créer une route pour modifier un item existant, tout en vérifiant également que cet item existe bien dans la liste, de la même façon qu'on l'a fait pour le GetById
- Voici le code :
```cs
[HttpPut("{id}")]
public IActionResult Update(Guid id, UpdateItemDto updateItemDto)
{
    var existingItem = items.Where(item => item.Id == id).FirstOrDefault();

    if (existingItem == null)
    {
        return NotFound();
    }

    var updatedItem = existingItem with
    {
        Name = updateItemDto.Name,
        Description = updateItemDto.Description,
        Price = updateItemDto.Price
    };

    var index = items.IndexOf(existingItem);
    items[index] = updatedItem;

    return NoContent();
}
```
- Trois choses à comprendre :
    - Ici on utilise IActionResult comme retour, car dans ce cas on ne souhaite pas de retour particulier, juste un NotFound() donc status code 404 ou un NoContent() donc status code 201 qui signifie juste que tout s'est bien passé sans retour particulier.
    - L'utilisation de with, elle est elle aussi optionnelle, mais ça nous évite de devoir redonner l'id de l'item et seulement modifier les valeurs qui sont modifiables (ça évite de potentielles erreurs concernant l'id)
    - items.IndexOf(existingItem) va nous retourner l'index de l'item que l'on souhaite modifier. Et on va donc directement le remplacer par updatedItem dans notre liste d'items à l'index de existingItem.

### La route DELETE /items/{id}
- Rien de nouveau ici normalement, on va réutiliser le principe de vérification d'existance de l'item et le retour du NotFound, mais pour montrer un autre exemple, nous allons retourner un ActionResult<Guid> permettant de retourner l'id de l'item supprimé (juste pour montrer une autre possibilité de retour du endpoint, mais on aurait pu très bien faire comme pour le PUT et ne rien retourner avec un IActionResult et un NoContent())
- Voici le code :
```cs
[HttpDelete("{id}")]
public ActionResult<Guid> Delete(Guid id)
{
    var existingItem = items.Where(item => item.Id == id).FirstOrDefault();

    if (existingItem == null)
    {
        return NotFound();
    }

    items.Remove(existingItem);

    return existingItem.Id;
}
```

## Ajout de vérification des données d'entrée
- Maintenant que les endpoints sont codés dans notre controller, on voudrait quand même ajouter quelques vérifications, rappelez-vous, j'ai déjà dû vous dire que lorsque l'on fait une API (ou autre chose), on ne fait JAMAIS confiance aux données qui nous sont envoyées, donc on les vérifie systématiquement. (**Règle d'or de la sécurité N°1** : Ne jamais faire confiance au front)
- Il existe plusieurs attributs que l'on peut ajouter à nos données dans les DTOs afin de permettre de valider les entrées utilisateur simplement
- On va donc ajouter des attributs [Required] ou [Range(0,100)] pour nos itemsDtos
- Voici le code à mettre dans votre fichier contenant les Dtos pour rendre les éléments provenants de l'appel du endpoint plus sécurisés : 
```cs
    public record ItemDto(Guid Id, string Name, string Description, decimal Price);
    public record CreateItemDto([Required] string Name, [Required] string Description, [Range(0,100)] decimal Price);
    public record UpdateItemDto([Required] string Name, [Required] string Description, [Range(0, 100)] decimal Price);
```
- Pour connaître d'autres attributs utilisables, voici une [liste des attributs](https://learn.microsoft.com/fr-fr/dotnet/api/system.componentmodel.dataannotations?view=net-7.0). Mais ça n'est pas le sujet, vous pourrez regarder ça tranquillement plus tard.

## On a fini la première partie ! Maintenant testez vos routes avec Swagger
- Vous pouvez tester les différentes routes avec Swagger en cliquant sur la route puis "Try it out"
- Je vous laisse tester les différentes routes, c'est pas bien compliqué, mais si vous avez un souci, demandez moi :
    - GET /items
    - GET /items/{id}
    - POST /items
    - PUT /items/{id}
    - DELETE /items/{id}
- Vérifier également en essayant de mettre des identifiants qui n'existent pas ou en essayant de faire un POST ou un PUT sans mettre de name ou de description, ou alors en mettant un prix négatif ou supérieur à 100.
