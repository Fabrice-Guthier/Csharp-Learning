// See https://aka.ms/new-console-template for more information
using SampleExercice;

// Quelques cas d'utilisation de Order
// TEST 1
// Une commande sans item pour l'instant
Order order = new Order();
var hasItems = order.HasItems(); // hasItems vaut false
Console.WriteLine($"hasItem value : {hasItems}");

// TEST 2
// Avec une commande sans item, le total vaut 0
var getTotal = order.GetTotal();
Console.WriteLine($"getTotal value : {getTotal}");

// TEST 3
// Throw une Exception si on appelle ApplyDiscount sur une commande sans item
// Le try catch ici n'est là que pour que le programme ne se stop pas, dans vos tests vous en avez pas besoin
try
{
    order.ApplyDiscount(50); // On applique une réduction de 50% cette méthode ne retourne rien et ici elle lève une exception
}
catch(Exception ex)
{
    Console.WriteLine("Immpossible d'appliquer une remise sur une commande sans item");
}

// TEST 4
// On essaye d'ajouter un item avec une quantité inférieur ou égale à zéro OU un prix inférieur à zéro
try
{
    order.AddItem("CaMarchePooo !", -10, 5);
}
catch(ArgumentException ex)
{
    Console.WriteLine("Impossible d'ajouter un item avec une quantité ou un prix inférieur à zéro");
}

// TEST 5
// On ajoute des items dans la liste de commande (c'est la méthode qui s'occupe de créer le OrderItem)
order.AddItem("PokeBall", 10, 100);
hasItems = order.HasItems(); // Maintenant hasItems vaut true
Console.WriteLine($"hasItems value : {hasItems}");
Console.WriteLine($"number of items : {order.Items.Count}");
order.AddItem("Skill", 500, 4000); // Ca coute cher le skill et on en veut un MAX !
hasItems = order.HasItems(); // hasItems vaut toujours true
Console.WriteLine($"hasItems value : {hasItems}");
Console.WriteLine($"number of items : {order.Items.Count}");

// TEST 6
// On essaye d'appliquer une remise inférieur à 0 (ou supérieur à 100) maintenant qu'il y a des items
try
{
    order.ApplyDiscount(-8000);
}
catch(ArgumentException ex)
{
    Console.WriteLine("Impossible d'appliquer une remise non comprise entre 0 et 100 inclus");
}

// TEST 7
// On applique une vraie remise de 50%
order.ApplyDiscount(50); // Discount vaut bien 50
Console.WriteLine($"Discount value : {order.Discount}");

// TEST 8
// On vérifie que le total est maintenant calculable 
getTotal = order.GetTotal();
Console.WriteLine($"getTotal value : {getTotal}");