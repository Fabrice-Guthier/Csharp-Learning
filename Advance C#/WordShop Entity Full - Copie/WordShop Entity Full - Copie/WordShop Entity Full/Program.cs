using WordShop_Entity_Full.Database;
using WordShop_Entity_Full.Models;
using WordShop_Entity_Full.Repository;

namespace WordShop_Entity_Full
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseContexte db = new DatabaseContexte())
            {
                AnimalRepository animalRepository = new AnimalRepository(db);
                ClientRepository clientRepository = new ClientRepository(db);
                ReservationRepository reservationRepository = new ReservationRepository(db);

                //Models.Animal animal1 = animalRepository.Create("un animal qui s'appel Rayan");
                //Models.Animal animal2 = animalRepository.Create("un animal qui s'appel Lardon");
                //Models.Client client1 = clientRepository.Create("un client qui s'appel Regis");
                //Models.Client client2 = clientRepository.Create("un client qui s'appel Golmon");
                //reservationRepository.Create("Une reservation quelconque", animal1, client1);


                List<Reservation> listReservation = reservationRepository.GetAll().ToList();

                Models.Reservation reservationDeBase = listReservation[0];

                //Console.WriteLine(reservationDeBase.Animal);



            } 
        }
    }
}
