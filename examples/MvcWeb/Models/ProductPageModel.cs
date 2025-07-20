using MvcWeb.Dtos;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace MvcWeb.Models
{
    [PageType(Title = "Product Page")]
    [ContentTypeRoute(Title = "Product", Route ="Product")]
    public class ProductPageModel : Page<ProductPageModel>
    {
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
