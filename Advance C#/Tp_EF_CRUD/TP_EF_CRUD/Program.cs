// See https://aka.ms/new-console-template for more information
using TP_EF_CRUD.Database;
using TP_EF_CRUD.Repositories;
using TP_EF_CRUD.Models;
using System.IO;

namespace TP_EF_CRUD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                AnimalRepository animalRepository = new AnimalRepository();
                ClientRepository clientRepository = new ClientRepository();
                ReservationRepository reservationRepository = new ReservationRepository();

                Animal animal1 = animalRepository.Create("un animal qui s'appel Rayan");
                //Models.Animal animal2 = animalRepository.Create("un animal qui s'appel Lardon");
                Client client1 = clientRepository.Create("un client qui s'appel Regis");
                //Models.Client client2 = clientRepository.Create("un client qui s'appel Golmon");
                reservationRepository.Create(animal1, client1);


                List<Reservation> listReservation = reservationRepository.GetAll().ToList();

                Models.Reservation reservationDeBase = listReservation[0];

                //Console.WriteLine(reservationDeBase.Animal);



            }
        }
    }


    //internal static void Test()
    //{
    //    // Initialisation des repositories pour les animaux, les clients et les réservations
    //    AnimalRepository animalRepository = new AnimalRepository();
    //    ClientRepository clientRepository = new ClientRepository();
    //    ReservationRepository reservationRepository = new ReservationRepository();

    //    // Demande à l'utilisateur de saisir un nom d'animal
    //    Console.WriteLine("Saisir un nom d'animal :");
    //    var userInputName = Console.ReadLine();

    //    // Demande à l'utilisateur de saisir une espèce
    //    Console.WriteLine("Saisir une espèce :");
    //    var userInputSpecies = Console.ReadLine();

    //    // Demande à l'utilisateur de saisir un nom de client
    //    Console.WriteLine("Saisir un nom de client :");
    //    var userInputClientName = Console.ReadLine();

    //    // Création d'un nouvel animal et d'un nouveau client, puis création d'une réservation
    //    animalRepository.Create(userInputName, userInputSpecies);
    //    clientRepository.Create(userInputClientName);

    //    // Récupération et affichage de la liste des animaux et des clients
    //    List<Animal> animalList = animalRepository.GetAll().ToList();
    //    List<Client> clientList = clientRepository.GetAll().ToList();

    //    animalList.ForEach(animal => Console.WriteLine($"Nom : {animal.Name} - {animal.Species}"));
    //    clientList.ForEach(client => Console.WriteLine(client.Name));

    //    // Demande à l'utilisateur de saisir un identifiant d'animal à supprimer
    //    Console.WriteLine("Saisir un identifiant d'animal à supprimer :");
    //    var userAnimalInputDelete = Console.ReadLine();
    //    var DeleteAnimal = animalRepository.DeleteById(int.Parse(userAnimalInputDelete));
    //    animalRepository.DeleteById(animalRepository.GetByName(DeleteAnimal).AnimalId);
    //    Console.WriteLine($"{DeleteAnimal} a bien été supprimé");

    //    // Demande à l'utilisateur de saisir un identifiant de client à supprimer
    //    Console.WriteLine("Saisir un identifiant de client à supprimer :");
    //    var userClientInputDelete = Console.ReadLine();
    //    var DeleteClient = animalRepository.DeleteById(int.Parse(userClientInputDelete));

    //    // Demande à l'utilisateur de saisir un nom de client à mettre à jour
    //    Console.WriteLine("Saisir un nom de client à mettre à jour :");
    //    var userClientInputUpdate = Console.ReadLine();
    //    var UpdateClient = clientRepository.UpdateById(int.Parse(userClientInputUpdate), "Mélanie");
    //    clientRepository.UpdateById(clientRepository.GetByName(UpdateClient).ClientId, UpdateClient);
    //    Console.WriteLine($"{UpdateClient} a bien été mis à jour");
    //}
}