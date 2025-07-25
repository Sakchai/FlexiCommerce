using MvcWeb.Dtos;
using MvcWeb.Models;

namespace MvcWeb.Mapping
{
    public static class CategoryMapping
    {
        public static Category ToEntity(this CategoryDto categoryDto)
        {
            return new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                ImageUrl = categoryDto.ImageUrl,
                MetaTitle = categoryDto.MetaTitle,
                MetaDescription = categoryDto.MetaDescription,
                Products = categoryDto.Products
            };
        }
        
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto(
                category.Id, 
                category.Name, 
                category.Description ?? string.Empty, 
                category.ImageUrl ?? string.Empty, 
                category.MetaTitle ?? string.Empty, 
                category.MetaDescription ?? string.Empty, 
                category.Products
            );
        }
    }
}
