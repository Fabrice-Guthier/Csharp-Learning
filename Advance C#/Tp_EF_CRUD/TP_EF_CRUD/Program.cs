// See https://aka.ms/new-console-template for more information
using TP_EF_CRUD.Database;
using TP_EF_CRUD.Repositories;
using TP_EF_CRUD.Models;
using System.IO;


AnimalRepository animalRepository = new AnimalRepository();
ClientRepository clientRepository = new ClientRepository();
ReservationRepository reservationRepository = new ReservationRepository();

//Console.WriteLine("Saisir un nom d'animal :");
//var userInputName = Console.ReadLine();

//Console.WriteLine("Saisir une espèce :");
//var userInputSpecies = Console.ReadLine();

//Console.WriteLine("Saisir un nom de client :");
//var userInputClientName = Console.ReadLine();

//animalRepository.Create(userInputName, userInputSpecies);
//clientRepository.Create(userInputClientName);
//reservationRepository.Create(userInputName, userInputClientName);

List<Animal> animalList = animalRepository.GetAll().ToList();
List<Client> clientList = clientRepository.GetAll().ToList();

animalList.ForEach(animal => Console.WriteLine($"Nom : {animal.Name} - {animal.Species}"));
clientList.ForEach(client => Console.WriteLine(client.Name));

//var DeleteAnimal = animalRepository.DeleteById(2);
//animalRepository.DeleteById(animalRepository.GetByName(DeleteAnimal).AnimalId);
//Console.WriteLine($"{DeleteAnimal} a bien été supprimé");

//var UpdateClient = clientRepository.UpdateById(3, "Mélanie");
//clientRepository.UpdateById(clientRepository.GetByName(UpdateClient).ClientId, UpdateClient);
//Console.WriteLine($"{UpdateClient} a bien été mis à jour");
