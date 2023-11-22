using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Features.MyOrders;
using Web.ViewModels;

namespace Web.Features.CategoryProducts
{
    public class GetCategoryProductsHandler : IRequestHandler<GetCategoryProducts, CatalogViewModel>
    {
        private readonly CatalogContext _context;

        public GetCategoryProductsHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task<CatalogViewModel> Handle(GetCategoryProducts request,
            CancellationToken cancellationToken)
        {
            var products = await _context.Products.Where(p => p.TagsToList().Contains(request.Category.ToUpper())
                && !p.IsDeleted).ToListAsync() ?? new List<Product>();


            return new CatalogViewModel()
            {
                Products = products,
                NumberOfPages = products.Count / 10
            };
        }
    }
}
