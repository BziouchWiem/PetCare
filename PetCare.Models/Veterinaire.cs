using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Veterinaire
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La spécialité est requise")]
        [StringLength(100, ErrorMessage = "La spécialité ne peut pas dépasser 100 caractères")]
        public string Specialite { get; set; }

        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}