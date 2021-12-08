using Dapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using MySqlConnector;
using System.Collections.Generic;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        public MovieDB movieAction = new MovieDB();


        public IActionResult List()
        {
            List<Movie> movies = movieAction.GetMovies();
            return View(movies);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Movie m)
        {
            Movie movie = m;
            if (ModelState.IsValid)
            {
                using (var connect = new MySqlConnection(Secret.Connection))
                {
                    string sql = $"insert into movies values({0},'{movie.ID},{movie.Title}','{movie.Genre}',{movie.Year},{movie.Runtime})";

                    connect.Open();

                    connect.Query(sql);

                    connect.Close();

                    return RedirectToAction("Result", m);
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Result(Movie m)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List", "Movie");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }


    }
}
