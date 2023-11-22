using MediatR;
using Web.ViewModels;

namespace Web.Features.CategoryProducts
{
    public class GetCategoryProducts : IRequest<CatalogViewModel>
    {
        public string Category { get; set; }

        public GetCategoryProducts(string category)
        {
            Category = category;
        }
    }
}
