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
        public ActionResult GetCategories() 
        {
            var categoriesList = _categoryRepository.GetCategories();
            var categoriesDtoList = new List<CategoryDto>();

            foreach (var category in categoriesList)
            { 
                categoriesDtoList.Add(_mapper.Map<CategoryDto>(category));
            }

            return Ok(categoriesDtoList);
        }
    }
}
