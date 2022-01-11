﻿using System.Collections.Generic;

namespace HoneyBadgers.Entity.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
