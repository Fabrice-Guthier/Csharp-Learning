using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Play.Catalog.Service.Repositories;
using Play.Catalog.Service.Settings;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
// Enregistre un sérialiseur personnalisé pour les GUID en tant que chaînes.
BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.String));
// Enregistre un sérialiseur personnalisé pour les décimaux en tant que string.

var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
// Récupère les paramètres de configuration MongoDBSettings à partir du fichier de configuration.

builder.Services.AddSingleton(serviceProvider =>
{
    var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
    // Récupère les paramètres de configuration MongoDBSettings à partir du fichier de configuration.
    var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
    // Crée un nouveau client MongoDB en utilisant la chaîne de connexion spécifiée.
    return mongoClient.GetDatabase(serviceSettings.Name);
    // Retourne la base de données à partir du client MongoDB.
});

builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();
// Enregistre le dépôt d'éléments (ItemsRepository) en tant que service singleton.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false; 
    // Active l'affichage du suffixe asynchrone dans les noms des actions.
});

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
