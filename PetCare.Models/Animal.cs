using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string Nom { get; set; }

        [Range(0, 100, ErrorMessage = "Âge invalide")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Le propriétaire est requis")]
        public int ProprietaireId { get; set; }
        public Proprietaire Proprietaire { get; set; }

        [Required(ErrorMessage = "Le type d'animal est requis")]
        public int TypeAnimalId { get; set; }
        public TypeAnimal TypeAnimal { get; set; }

        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}