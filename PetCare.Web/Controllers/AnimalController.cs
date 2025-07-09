using Microsoft.AspNetCore.Mvc;
using PetCare.DAL;
using Microsoft.EntityFrameworkCore;
using PetCare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetCare.Web.Models;

namespace PetCare.Web.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animal
        public IActionResult Index()
        {
            var animaux = _context.Animaux
                .Include(a => a.Proprietaire)
                .Include(a => a.TypeAnimal)
                .ToList();
            return View(animaux);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            var vm = new AnimalViewModel
            {
                Animal = new Animal(),
                Proprietaires = new SelectList(_context.Proprietaires, "Id", "Nom"),
                TypesAnimaux = new SelectList(_context.TypesAnimaux, "Id", "Libelle")
            };
            return View(vm);
        }

        // POST: Animal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AnimalViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Animaux.Add(vm.Animal);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Animal ajouté avec succès !";
                return RedirectToAction(nameof(Index));
            }

            // Recharge les listes si erreurs
            vm.Proprietaires = new SelectList(_context.Proprietaires, "Id", "Nom");
            vm.TypesAnimaux = new SelectList(_context.TypesAnimaux, "Id", "Libelle");
            return View(vm);
        }

        // GET: Animal/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var animal = _context.Animaux.Find(id);
            if (animal == null)
                return NotFound();

            var vm = new AnimalViewModel
            {
                Animal = animal,
                Proprietaires = new SelectList(_context.Proprietaires, "Id", "Nom", animal.ProprietaireId),
                TypesAnimaux = new SelectList(_context.TypesAnimaux, "Id", "Libelle", animal.TypeAnimalId)
            };

            return View(vm);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AnimalViewModel vm)
        {
            if (id != vm.Animal.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vm.Animal);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Animal modifié avec succès !";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Animaux.Any(e => e.Id == vm.Animal.Id))
                        return NotFound();
                    throw;
                }
            }

            // Recharge les listes si erreur
            vm.Proprietaires = new SelectList(_context.Proprietaires, "Id", "Nom", vm.Animal.ProprietaireId);
            vm.TypesAnimaux = new SelectList(_context.TypesAnimaux, "Id", "Libelle", vm.Animal.TypeAnimalId);
            return View(vm);
        }


        // GET: Animal/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = _context.Animaux
                .Include(a => a.Proprietaire)
                .Include(a => a.TypeAnimal)
                .FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var animal = _context.Animaux.Find(id);
            if (animal != null)
            {
                // Vérifier si des consultations sont associées
                var consultationsAssociees = _context.Consultations.Any(c => c.AnimalId == id);
                if (consultationsAssociees)
                {
                    TempData["ErrorMessage"] = "Cet animal ne peut pas être supprimé car il a des consultations associées.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Animaux.Remove(animal);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}