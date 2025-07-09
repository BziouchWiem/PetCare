using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Proprietaire
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "L’adresse est requise")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le téléphone est requis")]
        public string Telephone { get; set; }

        // ⚠️ Ce champ ne doit pas être validé à la création
        public ICollection<Animal> Animaux { get; set; } = new List<Animal>();
    }
}
