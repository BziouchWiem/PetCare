using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Models
{
    public class TypeAnimal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libellé est requis.")]
        public string Libelle { get; set; }

        public ICollection<Animal> Animaux { get; set; }
    }

}
