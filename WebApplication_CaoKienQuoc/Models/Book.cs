using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_CaoKienQuoc.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(50, ErrorMessage = "Author less than 50 characters")]
        public string Author { get; set; }
        public int PublicYear { get; set; }
        public double Price { get; set; }
        public string Cover { get; set; }

    }
}