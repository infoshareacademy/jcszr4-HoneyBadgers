using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;
using HoneyBadgers.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IReviewService _reviewService;
        public ReviewController(IMovieService movieService, IReviewService reviewService)
        {
            _movieService = movieService;
            _reviewService = reviewService;
        }
        public async Task<IActionResult> Index(string id)
        {
            var model = new ReviewListModel()
            {
                Movie = _movieService.GetById(id),
                Reviews = await _reviewService.GetAllMovieReviews(id)
            };
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await _reviewService.GetDetails(id);
            return View(model);
        }

        public IActionResult Create(string id)
        {
            var movie = _movieService.GetById(id);
            var model = new CreateReviewViewModel
            {
                Movie = movie
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReviewResultModel form)
        {
            if (ModelState.IsValid)
            {
                var review = new Review()
                {
                    MovieId = form.MovieId,
                    Title = form.Title,
                    Body = form.Review.Replace("background-color: rgb(255, 255, 255);", "background-color: #fbfbfb;")
                };
                _reviewService.Create(review);
                return RedirectToAction("Index", "Review", new { id = form.MovieId });
            }
            return View();
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(string id)
        {
            var model = _reviewService.GetById(id);
            return View(model);
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var result = _reviewService.Delete(id);
                return RedirectToAction("Details", "Movie", new { id = result });
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> Update(string id)
        {
            var model = await _reviewService.GetDetails(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateReviewResultModel form)
        {
            if (ModelState.IsValid)
            {
                var review = new Review()
                {
                    Id = form.Id,
                    MovieId = form.MovieId,
                    Title = form.Title,
                    Body = form.Review.Replace("background-color: rgb(255, 255, 255);", "background-color: #fbfbfb;")
                };
                _reviewService.Update(review);
                return RedirectToAction("Index", "Review", new { id = form.MovieId });
            }
            return View();
        }
    }
}
