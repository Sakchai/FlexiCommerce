using MvcWeb.Models;

namespace MvcWeb.Dtos
{
    public record class CategoryDto(
        int Id, 
        string Name, 
        string Description, 
        string ImageUrl, 
        string MetaTitle, 
        string MetaDescription, 
        ICollection<Product> Products
    );
}
