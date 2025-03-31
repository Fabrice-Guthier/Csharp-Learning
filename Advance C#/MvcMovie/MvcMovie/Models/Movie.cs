using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]

    public string? Title { get; set; }

    [Display(Name = "Date de sortie")]
    // L’attribut Display spécifie les éléments à afficher pour le nom d’un champ (dans le cas présent, « Release Date » au lieu de « ReleaseDate »)
    [DataType(DataType.Date)]
    // L’attribut DataType spécifie le type des données (Date). Les informations d’heures stockées dans le champ ne s’affichent donc pas.
    public DateTime ReleaseDate { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    // L’attribut DataType spécifie le type des données (Currency). Cela permet à Entity Framework Core de configurer le champ en tant que colonne de devise dans la base de données.
    [Column(TypeName = "decimal(18, 2)")]
    // L’annotation de données [Column(TypeName = "decimal(18, 2)")] est nécessaire pour qu’Entity Framework Core puisse correctement mapper Price en devise dans la base de données.
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    // L’attribut RegularExpression applique une expression régulière à la propriété. Dans ce cas, le nom de genre doit commencer par une majuscule et être suivi de lettres minuscules ou d’espaces.
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string? Rating { get; set; }

}