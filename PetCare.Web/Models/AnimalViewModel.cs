using Microsoft.AspNetCore.Mvc.Rendering;
using PetCare.Models;
using System.Collections.Generic;

namespace PetCare.Web.Models
{
    public class AnimalViewModel
    {
        public Animal Animal { get; set; }
        public IEnumerable<SelectListItem> Proprietaires { get; set; }
        public IEnumerable<SelectListItem> TypesAnimaux { get; set; }
    }
}