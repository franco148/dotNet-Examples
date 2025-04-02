using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models.Dtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(100, ErrorMessage = "Max lenght for Name should be 100")]
        public string Name { get; set; }
    }
}
