using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero_Creator.Data;
using Superhero_Creator.Models;

namespace Superhero_Creator.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperheroController
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes;
            return View(superheroes);
        }
        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }
        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }
        // POST: SuperheroController/Create
        [HttpPost]
        public ActionResult Create([Bind("Id,Name,AltEgo,PrimAbility,SecAbility,CatchPhrase")] Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }
        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            var superhero = _context.Superheroes.Find(id);
            return View(superhero);
        }
        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
