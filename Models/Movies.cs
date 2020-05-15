using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMovies.Models
{
    public class MMovies
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Director { get; set; }

        public int? Year { get; set; }

    }
}