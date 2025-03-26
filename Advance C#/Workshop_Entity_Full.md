# Workshop - Entity simple - Console App
## Setup
- Créez un projet Console, nommez le comme vous voulez
- Ajoutez les dépendances suivantes avec NuGet : 
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Tools
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.SqlServer
- Ouvrez le terminal (Ctrl+ù) puis installez les outils dotnet-ef (possible que ça marche plus, mais du coup c'est ptetre pas nécessaire): 
    - dotnet tool install --global dotnet-ef
- Regénérer le projet pour vérifier que tout va bien

## Création de la base de données 
- Créer un dossier Database (ou Infrastructure, ou comme vous voulez nommer votre dossier contenant vos éléments de base de données (moi, ça sera Database ici))
- Créer une classe DatabaseContext.cs
- Cette classe doit hériter de DBContext
- Créer un dossier Models avec les trois modèles suivants
- Créer une structure de base de données sous forme de modèles :
    - Animal
    - Client
    - Reservation
- Pensez que votre modèle Reservation va contenir des éléments en virtual 
```
    public virtual Animal Animal { get; set; }
    public virtual Client Client { get; set; }
```
- Pour chaque future table et donc pour chaque modèle ci-dessus, vous allez avoir besoin d'un DBSet (remarquez que le DbSet est lié au modèle par mutateur et que Animals est au pluriel). Le DBSet permettra de créer la table selon le modèle, par exemple : 
'''
    public DbSet<Animal> Animals { get; set; }
'''  
- Permettra de créer une table Animals
- Si c'était pas clair... à vous de créer les autres DbSet nécessaires (vous pouvez même déjà chercher dans la doc pour la relation entre animals - reservations - clients)

## Configuration de la base de données
- Vous pouvez évidemment utiliser le SGBD que vous voulez ! Il y aura quelques adaptations à faire, mais vous trouverez les infos dans la doc.
- Ajoutez la configuration de votre base de données (remplacez par vos données pour Server & Database, laissez Trusted & Encrypt tel que) : 
'''
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=DBName;Trusted_Connection=True;Encrypt=False");
    }
'''
- Clique droit sur **le projet**, puis "Ouvrir dans un terminal"
- Lancez les commandes suivantes dans l'invite de commande de Visual Studio afin de créer la migration puis appliquer la migration
    - dotnet ef migrations add InitialCreate (Une commande Add-Migration existe aussi avec Core tools normalement à utiliser depuis le Package Manager)
    - dotnet ef database update ==> (Une commande Update-Database existe aussi avec Core tools normalement à utiliser depuis le Package Manager)
- La migration et l'update étant fait, vous devriez avoir une nouvelle base dans SQL Server

## CRUD
- Depuis le program.cs (pour l'instant), vous allez pouvoir faire du CRUD depuis le code directement, pour celà, quelques petites choses sont à savoir : 
    - Vous aurez besoin d'ouvrir la connexion à la BDD pour l'utiliser avec le code suivant :
    '''
        using (var db = new DatabaseContext())
        {
        // Code pour CRUD sur la BDD, avec db accessible
        }
    ''' 
    - Pour sauvegarder les changements (CUD), vous devez appliquer les changements effectués dans le code avec 
    '''
        db.SaveChanges();
    '''
    - Vous pouvez faire du LinQ pour récupérer des données par exemple.
    - A vous de vous amuser à créer des données, les modifier, les supprimer et en lire depuis le Program.cs (possible de faire ça sous forme de tests unitaires si vous le souhaitez)

## Peupler la base avec des données initiales
- Pour initialiser la base de données avec des données de départ, vous pouvez le réaliser grâce à la méthode OnModelCreating, voici un exemple simple qui ajoute un client : 
'''
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
            new Client { ClientId = 1, Name = "Cédric" }
        );
    }
'''

## Créer des models et un Repository
- Créer un dossier Models et un dossier Repositories et faites en sortes de réaliser des CRUD sur les différents éléments via des méthodes dans votre repository qui exploite vos models

## Utiliser ses models
- Pour l'instant l'utilisation des models se fait depuis le program.cs, mais vous l'aurez sûrement compris, c'est ici que vous devriez faire intervenir votre API.

## Pour les courageux/euses 
- Réaliser une API (ou controller) permettant d'exploiter vos données

## Architecturer sa solution
- Réfléchissez à une bonne architecture pour votre solutions (pas besoin de faire plusieurs projets mais au moins plusieurs dossiers)

## Pour ceux qui veulent aller encore plus loin
- Réaliser une interface (UI) qui exploite votre API depuis un front dans le langage de votre choix (idéalement ASP pour votre formation, mais tout peut fonctionner)