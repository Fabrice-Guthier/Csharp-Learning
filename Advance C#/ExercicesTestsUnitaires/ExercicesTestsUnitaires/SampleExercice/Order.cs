using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleExercice
{
    // Pour avoir plus d'info sur comment utiliser cette classe, RDV dans le Program.cs
    public class Order
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public double Discount { get; set; } = 0;

        // Un chemin d'exécution possible
        // TEST 2 : On vérifie que GetTotal renvoie bien 0 sans items
        // TEST 8 : On vérifie que GetTotal renvoie bien une valeur cohérente par rapport aux items et à la remise
        public double GetTotal()
        {
            double total = Items.Sum(item => item.Price * item.Quantity);
            return total - (total * Discount / 100);
        }

        // Deux chemins d'exécution possibles
        // TEST 4 : On vérifie que l'on peut pas ajouter d'item si le prix ou la quantité n'est pas bonne (DataRow)
        // TEST 5 : On ajoute des items et on vérifie que HasItem vaut true et on peut également vérifier la quantité d'items
        public void AddItem(string name, double price, int quantity)
        {
            if (quantity <= 0 || price < 0)
                throw new ArgumentException("Invalid price or quantity");

            Items.Add(new OrderItem { Name = name, Price = price, Quantity = quantity });
        }

        // Trois chemins d'exécution possibles
        // TEST 3 : On vérifie que l'on peut pas appliquer de remise s'il n'y a pas d'items
        // TEST 6 : On vérifie qu'on ne peut pas appliquer une remise qui n'est pas entre 0 et 100 (DataRow)
        // TEST 7 : On vérifie que si on applique une remise entre 0 et 100 la propriété Discount est bien modifiée
        public void ApplyDiscount(double discount)
        {
            if (!HasItems())
                throw new Exception("Cannot apply discount on order without item");

            if (discount < 0 || discount > 100)
                throw new ArgumentException("Discount must be between 0 and 100");

            Discount = discount;
        }

        // Deux chemins d'exécution possibles
        // TEST 1 : On vérifie que si on n'a pas d'items, ça retourne bien false
        public bool HasItems()
        {
            return Items.Count > 0;
        }
    }

    // Cette classe n'est pas à tester, elle n'a que pour but de définir un Item de notre commande.
    public class OrderItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
