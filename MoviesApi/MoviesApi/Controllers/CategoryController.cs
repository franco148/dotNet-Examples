using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApi.Models;
using MoviesApi.Models.Dtos;
using MoviesApi.Repositories;

namespace MoviesApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetCategories() 
        {
            var categoriesList = _categoryRepository.GetCategories();
            var categoriesDtoList = new List<CategoryDto>();

            foreach (var category in categoriesList)
            { 
                categoriesDtoList.Add(_mapper.Map<CategoryDto>(category));
            }

            return Ok(categoriesDtoList);
        }

        [HttpGet("{categoryId}:int", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategory(int categoryId)
        {
            var categoryItem = _categoryRepository.GetCategory(categoryId);
            if (categoryItem == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(categoryItem);

            return Ok(categoryDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid || categoryDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_categoryRepository.ExistCategory(categoryDto.Name))
            {
                ModelState.AddModelError("", "The category already exist");
                return StatusCode(400, ModelState);
            }

            var category = _mapper.Map<Category>(categoryDto);
            
            if (!_categoryRepository.CreateCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong saving the item {category.Name}");
                return StatusCode(400, ModelState);
            }

            return CreatedAtRoute("GetCategory", new { categoryId = category.Id }, category);
        }
    }
}
