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
        //public MovieDB movieAction = new MovieDB();


        public IActionResult List()
        {
            List<Movie> movies = new List<Movie>();
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from movies";

                connect.Open();

                movies = connect.Query<Movie>(sql).ToList();

                connect.Close();
            }
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

        //public IActionResult Result(Movie m)
        //{

        //    return View(m);
        //}


    }
}
