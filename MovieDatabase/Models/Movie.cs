using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Models
{
    public enum Genre
    {
        Horror, Comedy, Drama, Action
    }
    public class Movie
    {
        [Required][Key]
        public int ID { get; set; }
        [MaxLength(30, ErrorMessage ="Please enter 30 characters")]
        public string Title { get; set; }
        public Genre Genre { get; set; }
        [Range(1880,2021, ErrorMessage ="Please enter a year between 1880 and 2021")]
        public int Year { get; set; }
        public int Runtime { get; set; }
    }
}
