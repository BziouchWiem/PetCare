using Microsoft.AspNetCore.Mvc;
using PetCare.DAL;
using Microsoft.EntityFrameworkCore;
using PetCare.Models;

namespace PetCare.Web.Controllers
{
    public class VeterinaireController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeterinaireController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veterinaire
        public IActionResult Index()
        {
            var veterinaires = _context.Veterinaires.ToList();
            return View(veterinaires);
        }

        // GET: Veterinaire/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinaire/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Veterinaire veterinaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinaire);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Vétérinaire ajouté avec succès !";
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            TempData["ErrorMessage"] = "Erreur lors de l'ajout : " + string.Join(", ", errors);
            return View(veterinaire);
        }

        // GET: Veterinaire/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaire = _context.Veterinaires.Find(id);
            if (veterinaire == null)
            {
                return NotFound();
            }
            return View(veterinaire);
        }

        // POST: Veterinaire/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Veterinaire veterinaire)
        {
            if (id != veterinaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinaire);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Vétérinaire modifié avec succès !";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Veterinaires.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            TempData["ErrorMessage"] = "Erreur lors de la modification : " + string.Join(", ", errors);
            return View(veterinaire);
        }

        // GET: Veterinaire/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinaire = _context.Veterinaires.Find(id);
            if (veterinaire == null)
            {
                return NotFound();
            }

            return View(veterinaire);
        }

        // POST: Veterinaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var veterinaire = _context.Veterinaires.Find(id);
            if (veterinaire != null)
            {
                var consultationsAssociees = _context.Consultations.Any(c => c.VeterinaireId == id);
                if (consultationsAssociees)
                {
                    TempData["ErrorMessage"] = "Ce vétérinaire ne peut pas être supprimé car il a des consultations associées.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Veterinaires.Remove(veterinaire);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}