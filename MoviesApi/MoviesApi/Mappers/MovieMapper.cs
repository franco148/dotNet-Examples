using AutoMapper;
using MoviesApi.Models;
using MoviesApi.Models.Dtos;

namespace MoviesApi.Mappers
{
    public class MovieMapper : Profile
    {
        public MovieMapper() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
