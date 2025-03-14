namespace Play.Catalog.Service.Entities
{
    public class Item
    {
        public Guid Id { get; set; } 
        // Propriété publique de type Guid (identifiant unique global) nommée Id.
        // get; set; indique que la propriété a à la fois un getter (pour lire la valeur) et un setter (pour modifier la valeur).
        // Cette propriété représente l'identifiant unique d'un élément.

        public string Name { get; set; } 
        // Propriété publique de type string nommée Name.
        // get; set; indique que la propriété a à la fois un getter et un setter.
        // Cette propriété représente le nom d'un élément.

        public string Description { get; set; } 
        // Propriété publique de type string nommée Description.
        // get; set; indique que la propriété a à la fois un getter et un setter.
        // Cette propriété représente la description d'un élément.

        public decimal Price { get; set; } 
        // Propriété publique de type decimal nommée Price.
        // get; set; indique que la propriété a à la fois un getter et un setter.
        // Cette propriété représente le prix d'un élément.
    }
}
