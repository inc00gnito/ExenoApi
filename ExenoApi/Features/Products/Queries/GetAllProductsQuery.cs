using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExenoApi.Models;
using ExenoApi.Services;
using MediatR;

namespace ExenoApi.Features.Products.Queries
{
    public class GetAllProductsQuery :IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IProductService _productService;

            public GetAllProductsQueryHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                return await _productService.GetProductList();
            }
        }
        
    }
}
