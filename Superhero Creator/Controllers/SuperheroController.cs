﻿using System;
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
            return View();
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
        public ActionResult Edit([Bind("Id,Name,AltEgo,PrimAbility,SecAbility,CatchPhrase")] Superhero superhero)
        {
            return View();
        }
        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            var superHero = _context.Superheroes.Find(id);
            return View(superHero);
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var superHero = _context.Superheroes.Find(id);
                _context.Superheroes.Remove(superHero);
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
