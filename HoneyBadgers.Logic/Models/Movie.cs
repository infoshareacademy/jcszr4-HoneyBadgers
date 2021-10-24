﻿using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.Logic
{
    public enum MovieStatus
    {
        NoStatus,
        Watched,
        WantToWatch
        
    }
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public List<string> Actors { get; set; }
        public string Plot { get; set; }
        public List<string> Genre { get; set; }
        public string Country { get; set; }
        public MovieStatus Status { get; set; }
        public double? Rating { get; set; }
        public List<Rating> Ratings { get; set; }

        public Movie(MovieDto movieDto)
        {
            Title = movieDto.Title;
            Year = movieDto.Year;
            Director = movieDto.Director;
            Writer = movieDto.Writer;
            Actors = movieDto.Actors.Split(",").Select(p => p.Trim()).ToList();
            Plot = movieDto.Plot;
            Genre = movieDto.Genre.Split(",").Select(p => p.Trim()).ToList();
            Country = movieDto.Country;
            Status = MovieStatus.NoStatus;
            Rating = null;
            Ratings = movieDto.Ratings;
        }
    }
}
