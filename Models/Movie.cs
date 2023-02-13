using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcMovie.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        [ForeignKey("Director")]
        [Required(ErrorMessage = "The Director field is required.")]
        [Display(Name = "Director")]
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
    }
}
