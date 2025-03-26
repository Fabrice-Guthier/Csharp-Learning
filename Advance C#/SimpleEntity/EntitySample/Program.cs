// See https://aka.ms/new-console-template for more information
using EntitySample;
using EntitySample.Database;
using EntitySample.Model;
using EntitySample.Repositories;
using System.Text.Json;

Console.WriteLine("Hello, World!");

//AnimalDbContext animalDbContext = new AnimalDbContext();

//BreedRepository breedRepository = new BreedRepository();
//breedRepository.Create("Labrador");

DogRepository dogRepository = new DogRepository();
dogRepository.Create("Preyja", "Akita inu");

List<Dog> dogList = dogRepository.GetAll().ToList();
dogList.ForEach(dog => Console.WriteLine($"Nom : {dog.Name} - {dog.Breed.Name}"));

//HttpClient client = new HttpClient();
//var result = await client.GetAsync("https://api.chucknorris.io/jokes/random");
//var response = await result.Content.ReadAsStringAsync();
//JokeChuckDTO dto = JsonSerializer.Deserialize<JokeChuckDTO>(response);
//Console.WriteLine(response);
