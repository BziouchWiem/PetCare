using Microsoft.AspNetCore.Mvc;
using PetCare.DAL;
using Microsoft.EntityFrameworkCore;
using PetCare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PetCare.Web.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultation
        public IActionResult Index()
        {
            var consultations = _context.Consultations
                .Include(c => c.Animal)
                .Include(c => c.Veterinaire)
                .ToList();
            return View(consultations);
        }

        // GET: Consultation/Create
        public IActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(_context.Animaux, "Id", "Nom");
            ViewBag.VeterinaireId = new SelectList(_context.Veterinaires, "Id", "Nom");
            return View();
        }

        // POST: Consultation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultation);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Consultation ajoutée avec succès !";
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e =>
                e.ErrorMessage switch
                {
                    "The Animal field is required." => "L'animal est requis.",
                    "The Veterinaire field is required." => "Le vétérinaire est requis.",
                    _ => e.ErrorMessage
                });
            TempData["ErrorMessage"] = "Erreur lors de l'ajout : " + string.Join(", ", errors);
            ViewBag.AnimalId = new SelectList(_context.Animaux, "Id", "Nom", consultation.AnimalId);
            ViewBag.VeterinaireId = new SelectList(_context.Veterinaires, "Id", "Nom", consultation.VeterinaireId);
            return View(consultation);
        }

        // GET: Consultation/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = _context.Consultations.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }
            ViewBag.AnimalId = new SelectList(_context.Animaux, "Id", "Nom", consultation.AnimalId);
            ViewBag.VeterinaireId = new SelectList(_context.Veterinaires, "Id", "Nom", consultation.VeterinaireId);
            return View(consultation);
        }

        // POST: Consultation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Consultation consultation)
        {
            if (id != consultation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultation);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Consultation modifiée avec succès !";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Consultations.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e =>
                e.ErrorMessage switch
                {
                    "The Animal field is required." => "L'animal est requis.",
                    "The Veterinaire field is required." => "Le vétérinaire est requis.",
                    _ => e.ErrorMessage
                });
            TempData["ErrorMessage"] = "Erreur lors de la modification : " + string.Join(", ", errors);
            ViewBag.AnimalId = new SelectList(_context.Animaux, "Id", "Nom", consultation.AnimalId);
            ViewBag.VeterinaireId = new SelectList(_context.Veterinaires, "Id", "Nom", consultation.VeterinaireId);
            return View(consultation);
        }

        // GET: Consultation/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = _context.Consultations
                .Include(c => c.Animal)
                .Include(c => c.Veterinaire)
                .FirstOrDefault(c => c.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // POST: Consultation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var consultation = _context.Consultations.Find(id);
            if (consultation != null)
            {
                _context.Consultations.Remove(consultation);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}