using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.DTOs
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price); 
    // Définition d'un enregistrement (record) ItemDto. Les enregistrements sont des types de référence immuables qui fournissent des fonctionnalités intégrées pour la création d'objets, la comparaison, la déconstruction et l'affichage.
    // ItemDto représente un Data Transfer Object (DTO) pour un élément, contenant son ID, nom, description et prix.

    public record CreateItemDto([Required] string Name, [Required] string Description, [Range(0, 100)] decimal Price); 
    // Définition d'un enregistrement CreateItemDto.
    // Cet enregistrement est utilisé pour les données requises lors de la création d'un nouvel élément.
    // [Required]: Attribut qui indique que les propriétés Name et Description sont obligatoires.
    // [Range(0, 100)]: Attribut qui spécifie que la propriété Price doit être comprise entre 0 et 100 (inclus).

    public record UpdateItemDto([Required] string Name, [Required] string Description, [Range(0, 100)] decimal Price); 
    // Définition d'un enregistrement UpdateItemDto.
    // Cet enregistrement est utilisé pour les données requises lors de la mise à jour d'un élément existant.
    // [Required]: Attribut qui indique que les propriétés Name et Description sont obligatoires.
    // [Range(0, 100)]: Attribut qui spécifie que la propriété Price doit être comprise entre 0 et 100 (inclus).
}
