using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Identity.Repo;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Controllers
{
    [Authorize] // hele controlleren er blockeret
    public class AnimalsController : Controller
    {
        private IAnimalRepo animalRepo;

        public AnimalsController(IAnimalRepo animalRepo)
        {
            this.animalRepo = animalRepo;
        }

        // GET: Animals
        [Authorize]
        //[AllowAnonymous] //override på enkelt methode
        public async Task<IActionResult> Index()
        {
            return View(animalRepo.Get());
        }

        // GET: Animals/Details/5
        //[Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animals = animalRepo.Get(id);
            if (animals == null)
            {
                return NotFound();
            }

            return View(animals);
        }

        // GET: Animals/Create
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Animal")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                animalRepo.Save(animals);
                return RedirectToAction(nameof(Index));
            }
            return View(animals);
        }

        // GET: Animals/Edit/5
        //[Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animals = animalRepo.Get(id);
            if (animals == null)
            {
                return NotFound();
            }
            return View(animals);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Animal")] Animals animals)
        {
            if (id != animals.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                animalRepo.Save(animals);
                return RedirectToAction(nameof(Index));
            }
            return View(animals);
        }

        // GET: Animals/Delete/5
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            return View(animalRepo.Get(id));
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            animalRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

   
    }
}
