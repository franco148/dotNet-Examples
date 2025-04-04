using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
