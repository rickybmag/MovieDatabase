using Dapper;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        public MovieDAL MovieDB = new MovieDAL();

        public IActionResult List()
        {
            List<Movie> movies = MovieDB.GetMovies();
            return View(movies);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Movie m)
        {            
            if (ModelState.IsValid)
            {
                using (var connect = new MySqlConnection(Secret.Connection))
                {
                    string sql = $"insert into movies values({0},'{m.Title}','{m.Genre}',{m.Year},{m.Runtime})";

                    connect.Open();

                    connect.Query<Movie>(sql);

                    connect.Close();
                }
                return RedirectToAction("List");

            }
            else
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            Movie m = MovieDB.GetMovie(id);
            if (m != null)
            {
                return View(m);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            Movie m = MovieDB.GetMovie(id);
            if (m != null)
            {
                return View(m);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

       public IActionResult Edit(int id)
        {
            Movie m = MovieDB.GetMovie(id);
            if (m != null)
            {
                return View(m);
            }
            else
            {
                return RedirectToAction("IDError", id);
            }
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            return View(m);
        }


    }
}
