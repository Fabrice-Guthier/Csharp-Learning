dotnet aspnet-codegenerator controller -name LoginController -m Login -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

<au cas où la création des vues ne fonctionne pas, cette commande fait la même chose, il faut juste changer le DbContext et le controller pour correspondre au projet
