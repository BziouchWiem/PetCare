using Microsoft.AspNetCore.Mvc;
using PetCare.DAL;
using Microsoft.EntityFrameworkCore;
using PetCare.Models;

namespace PetCare.Web.Controllers
{
    public class ProprietaireController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProprietaireController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proprietaire
        public IActionResult Index()
        {
            var proprietaires = _context.Proprietaires.ToList();
            return View(proprietaires);
        }

        // GET: Proprietaire/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proprietaire/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proprietaire);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Propriétaire ajouté avec succès !";
                return RedirectToAction(nameof(Index));
            }
            // Débogage : Afficher les erreurs de validation
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            TempData["ErrorMessage"] = "Erreur lors de l'ajout : " + string.Join(", ", errors);
            return View(proprietaire);
        }

        // GET: Proprietaire/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = _context.Proprietaires.Find(id);
            if (proprietaire == null)
            {
                return NotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaire/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Proprietaire proprietaire)
        {
            if (id != proprietaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proprietaire);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Propriétaire modifié avec succès !";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Proprietaires.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proprietaire);
        }

        // GET: Proprietaire/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaire = _context.Proprietaires.Find(id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return View(proprietaire);
        }

        // POST: Proprietaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var proprietaire = _context.Proprietaires.Find(id);
            if (proprietaire != null)
            {
                var animauxAssocie = _context.Animaux.Any(a => a.ProprietaireId == id);
                if (animauxAssocie)
                {
                    TempData["ErrorMessage"] = "Ce propriétaire ne peut pas être supprimé car il a des animaux associés.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Proprietaires.Remove(proprietaire);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}