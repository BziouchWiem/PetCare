using System;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Consultation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La date de consultation est requise")]
        public DateTime DateConsultation { get; set; }

        [Required(ErrorMessage = "Le diagnostic est requis")]
        [StringLength(500, ErrorMessage = "Le diagnostic ne peut pas dépasser 500 caractères")]
        public string Diagnostic { get; set; }

        [Required(ErrorMessage = "L'animal est requis")]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        [Required(ErrorMessage = "Le vétérinaire est requis")]
        public int VeterinaireId { get; set; }
        public Veterinaire Veterinaire { get; set; }
    }
}