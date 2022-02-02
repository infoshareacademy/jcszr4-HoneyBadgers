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
        private readonly ReviewService _reviewService;
        public ReviewController(IMovieService movieService, ReviewService reviewService)
        {
            _movieService = movieService;
            _reviewService = reviewService;
        }
        public async Task<IActionResult> Index(string id)
        {
            var model = await _reviewService.GetMovieReviews(id);
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
                    Body = form.Review
                };
                _reviewService.Create(review);
                return RedirectToAction("Index", "Review", new { id = form.MovieId });
            }
            return View();
        }
    }
}
