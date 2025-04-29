# Cheatsheet / Support de cours

# Ressources documentaire

[Blazor pour .NET 9](https://learn.microsoft.com/fr-fr/aspnet/core/blazor/?view=aspnetcore-9.0)

[DbContext: utilisation](https://learn.microsoft.com/fr-fr/ef/ef6/fundamentals/working-with-dbcontext)\
[DbContext c'est quoi ?](https://dotnettutorials.net/lesson/dbcontext-entity-framework-core/)

## Création d'un nouveau projet Blazor (CLI)

```bash
dotnet new blazor -o BlazorDecouverte
```

## Lancement projet avec hotreload lors de changement de code

```bash
dotnet watch
```

## Génération CRUD

### Installation des packages pour du Scaffolding

Vous pouvez mettre ceci dans un script bash et le lancer.

```bash
#!/bin/bash

# dotnet-aspnet-codegenerator => Generateur de code "clé en main"
dotnet tool install --global dotnet-aspnet-codegenerator --allow-roll-forward # --allow-roll-forward pour la compatibilité avec .NET 9
# CLI pour EntityFramework
dotnet tool install --global dotnet-ef

# Package pour génération de code pour le web avec aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

# Packages des fournisseurs de base de données
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# pour utiliser la méthode d'extension AddDatabaseDeveloperPageExceptionFilter dans le fichier Programme, qui capture les exceptions liées à la base de données.
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Packages pour componsant Blazor de table de données "clé en main" + Adapteur à EntityFramework
dotnet add package Microsoft.AspNetCore.Components.QuickGrid
dotnet add package Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
```

Commande pour générer un CRUD (Create Read Update Delete) classique

```bash
# -dbProvider quel type de base de données on utilise (sqlserver, sqlite, cosmos, postgres)
# -dc la classe DbContext à générer, le DbContext sert de pont entre l'entité (classe qui représente les données de la base) et
# -m le nom du modèle
# -outDir le chemin où seront placés les composants Blazor de CRUD
dotnet aspnet-codegenerator blazor CRUD -dbProvider sqlite -dc BlazorWebAppMovies.Data.MoviesDbContext -m Movie -outDir Components/Pages
```

### Migration base de données

Pour créer une migration avec EntityFramework

```bash
# InitialCreate est le nom de la migration
dotnet ef migrations add InitialCreate
```

Si l'on souhaite supprimer la migration créée

```bash
dotnet ef migrations remove
```

Puis pour appliquer les migrations sur la base de données

```bash
dotnet ef database update
```
