using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Models
{
    public class MovieDB
    {
        public List<Movie> GetMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();

                return movies;
            }
        }
    }
}
