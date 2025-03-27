using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [Display(Name = "Date de sortie")]
    // L’attribut Display spécifie les éléments à afficher pour le nom d’un champ (dans le cas présent, « Release Date » au lieu de « ReleaseDate »)
    [DataType(DataType.Date)]
    // L’attribut DataType spécifie le type des données (Date). Les informations d’heures stockées dans le champ ne s’affichent donc pas.
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    // L’annotation de données [Column(TypeName = "decimal(18, 2)")] est nécessaire pour qu’Entity Framework Core puisse correctement mapper Price en devise dans la base de données.
    public decimal Price { get; set; }
}