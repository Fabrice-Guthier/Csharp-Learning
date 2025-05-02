using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BlazorWebAppMovies.Components.Starship
{
    public class StarshipFormModel
    {
        [Required(ErrorMessage = "Champ identifiant est requis.")]
        [StringLength(16, ErrorMessage = "Identifiant trop long (maximum 16 caractères)")]
        public string Id { get; set; } = String.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Champ identifiant est requis.")]
        public string Classification { get; set; } = String.Empty;

        [Range(1, 100000, ErrorMessage = "Nombre d'habitations invalide (entre 1 et 100000)")]
        public int MaximumAccommodation { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Approbation requise")]
        public bool IsValidatedDesign { get; set; }

        [Required(ErrorMessage = "Champ identifiant est requis.")]
        public DateTime ProductionDate { get; set; }
    }
}
