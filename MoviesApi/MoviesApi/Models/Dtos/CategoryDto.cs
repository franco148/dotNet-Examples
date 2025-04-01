using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(100, ErrorMessage = "Max lenght for Name should be 100")]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
