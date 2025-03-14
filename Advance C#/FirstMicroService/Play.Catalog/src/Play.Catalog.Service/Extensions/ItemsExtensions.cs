using Play.Catalog.Service.DTOs;
using Play.Catalog.Service.Entities;
using System.Runtime.CompilerServices;

namespace Play.Catalog.Service.Extensions
{
    public static class ItemsExtensions
    {
        public static ItemDto AsDto(this Item item) // Définition d'une méthode d'extension statique pour la classe Item. Cette méthode permet de convertir un objet Item en un objet ItemDto.
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price); 
            // Crée et retourne une nouvelle instance de ItemDto en utilisant les propriétés de l'objet Item d'origine.
            // item.Id: L'ID de l'item d'origine est passé au constructeur de ItemDto.
            // item.Name: Le nom de l'item d'origine est passé au constructeur de ItemDto.
            // item.Description: La description de l'item d'origine est passée au constructeur de ItemDto.
            // item.Price: Le prix de l'item d'origine est passé au constructeur de ItemDto.
        }
    }
}
