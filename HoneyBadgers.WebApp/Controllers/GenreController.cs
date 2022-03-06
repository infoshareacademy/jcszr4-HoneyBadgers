using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyBadgers.WebApp.Controllers
{
    public class GenreController : Controller
    {
        // GET: GenraController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: GenraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenraController/Edit/5
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

        // GET: GenraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
