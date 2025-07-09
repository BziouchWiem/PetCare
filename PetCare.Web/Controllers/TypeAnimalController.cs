using Microsoft.AspNetCore.Mvc;
using PetCare.DAL;
using Microsoft.EntityFrameworkCore;
using PetCare.Models;

namespace PetCare.Web.Controllers
{
    public class TypeAnimalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeAnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeAnimal
        public IActionResult Index()
        {
            var typesAnimaux = _context.TypesAnimaux.ToList();
            return View(typesAnimaux);
        }

        // GET: TypeAnimal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeAnimal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypeAnimal typeAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeAnimal);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(typeAnimal);
        }

        // GET: TypeAnimal/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAnimal = _context.TypesAnimaux.Find(id);
            if (typeAnimal == null)
            {
                return NotFound();
            }
            return View(typeAnimal);
        }

        // POST: TypeAnimal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TypeAnimal typeAnimal)
        {
            if (id != typeAnimal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeAnimal);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TypesAnimaux.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(typeAnimal);
        }

        // GET: TypeAnimal/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAnimal = _context.TypesAnimaux.Find(id);
            if (typeAnimal == null)
            {
                return NotFound();
            }

            return View(typeAnimal);
        }

        // POST: TypeAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var typeAnimal = _context.TypesAnimaux.Find(id);
            if (typeAnimal != null)
            {
                // Vérifier si des animaux sont associés
                var animauxAssocie = _context.Animaux.Any(a => a.TypeAnimalId == id);
                if (animauxAssocie)
                {
                    TempData["ErrorMessage"] = "Ce type d'animal ne peut pas être supprimé car il est utilisé par des animaux.";
                    return RedirectToAction(nameof(Index));
                }

                _context.TypesAnimaux.Remove(typeAnimal);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}