using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMovies.Services;
using AspNetCoreMovies.Models;

namespace AspNetCoreMovies.Controllers
{
    public class MoviesController : Controller
    {
        
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _moviesService.GetMoviesAsync();

          
            var model = new MoviesViewModel()
            {
                Movies = movies
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMovies(Movies newMovies)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _moviesService.AddMoviesAsync(newMovies);
            if (!successful)
            {
                return BadRequest("Could not add item");
            }
            return RedirectToAction("Index");
        }

    }
}