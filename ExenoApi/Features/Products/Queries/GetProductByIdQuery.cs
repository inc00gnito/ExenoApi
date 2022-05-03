using System.Threading;
using System.Threading.Tasks;
using ExenoApi.Models;
using ExenoApi.Services;
using MediatR;

namespace ExenoApi.Features.Products.Queries
{
    public class GetProductByIdQuery :  IRequest<Product>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IProductService _productService;

            public GetProductByIdQueryHandler(IProductService productService)
            {
                _productService = productService;
            }
            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                return await _productService.GetProductById(request.Id);
            }
        }
    }
}
