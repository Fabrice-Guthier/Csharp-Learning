using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Play.Catalog.Service.DTOs;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Extensions;
using Play.Catalog.Service.Repositories;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemControllers : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository; 
        // Déclaration d'un champ privé en lecture seule pour le dépôt d'éléments (ItemsRepository). Il est instancié directement, ce qui signifie qu'il est créé une seule fois lors de la création de la classe.
        public ItemControllers(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository; 
            // Affecte le dépôt d'éléments fourni au champ privé _itemsRepository.
        }

        [HttpGet] 
        // Attribut indiquant que cette méthode répond aux requêtes HTTP GET.
        public async Task<IEnumerable<ItemDto>> GetAsync() 
            // Méthode asynchrone pour récupérer tous les éléments.
        {
            return (await _itemsRepository.GetAllAsync()).Select(item => item.AsDto()); 
            // Appelle la méthode GetAllAsync du dépôt pour récupérer tous les éléments, puis les transforme en ItemDto à l'aide de la méthode AsDto et les retourne sous forme de collection.
        }

        [HttpGet("{id}")] 
        // Attribut indiquant que cette méthode répond aux requêtes HTTP GET avec un paramètre 'id' dans l'URL.
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id) 
            // Méthode asynchrone pour récupérer un élément par son ID.
        {
            var item = await _itemsRepository.GetByIdAsync(id); 
            // Appelle la méthode GetByIdAsync du dépôt pour récupérer l'élément par son ID.

            if (item == null) 
                // Vérifie si l'élément trouvé est null (n'existe pas).
                return NotFound(); 
            // Retourne une réponse HTTP 404 (Not Found) si l'élément n'existe pas.

            return item.AsDto();
            // Retourne l'élément transformé en ItemDto.
        }

        [HttpPost] // Attribut indiquant que cette méthode répond aux requêtes HTTP POST.
        public async Task<ActionResult<ItemDto>> CreateAsync(CreateItemDto createItemDto) 
            // Méthode asynchrone pour créer un nouvel élément.
        {
            var item = new Item 
            // Crée un nouvel objet Item à partir des données fournies dans le CreateItemDto.
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price
            };

            await _itemsRepository.CreateAsync(item); 
            // Appelle la méthode CreateAsync du dépôt pour persister le nouvel élément.

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item); 
            // Retourne une réponse HTTP 201 (Created) avec l'URL du nouvel élément créé (en utilisant GetByIdAsync) et l'élément lui-même.
        }

        [HttpPut("{id}")] 
        // Attribut indiquant que cette méthode répond aux requêtes HTTP PUT avec un paramètre 'id' dans l'URL.
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateItemDto updateItemDto) 
            // Méthode asynchrone pour mettre à jour un élément existant.
        {
            var existingItem = await _itemsRepository.GetByIdAsync(id); 
            // Récupère l'élément existant par son ID.

            if (existingItem == null) 
                // Vérifie si l'élément existant est null (n'existe pas).
                return NotFound(); 
            // Retourne une réponse HTTP 404 (Not Found) si l'élément n'existe pas.

            existingItem.Name = updateItemDto.Name; 
            // Met à jour les propriétés de l'élément existant avec les données du UpdateItemDto.
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await _itemsRepository.UpdateAsync(existingItem); 
            // Appelle la méthode UpdateAsync du dépôt pour persister les modifications.

            return NoContent(); 
            // Retourne une réponse HTTP 204 (No Content) indiquant que la mise à jour a réussi.
        }

        [HttpDelete("{id}")] 
        // Attribut indiquant que cette méthode répond aux requêtes HTTP DELETE avec un paramètre 'id' dans l'URL.
        public async Task<ActionResult<Guid>> DeleteAsync(Guid id) 
            // Méthode asynchrone pour supprimer un élément par son ID.
        {
            var existingItem = await _itemsRepository.GetByIdAsync(id); 
            // Récupère l'élément existant par son ID.

            if (existingItem == null) 
                // Vérifie si l'élément existant est null (n'existe pas).
                return NotFound(); 
            // Retourne une réponse HTTP 404 (Not Found) si l'élément n'existe pas.

            await _itemsRepository.DeleteOneById(existingItem.Id); 
            // Appelle la méthode DeleteOneById du dépôt pour supprimer l'élément.

            return existingItem.Id; 
            // Retourne l'ID de l'élément supprimé.
        }
    }
}
