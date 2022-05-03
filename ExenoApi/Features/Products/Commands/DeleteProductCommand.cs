using System.Threading;
using System.Threading.Tasks;
using ExenoApi.Services;
using MediatR;

namespace ExenoApi.Features.Products.Commands
{
    public class DeleteProductCommand: IRequest<int>
    {

        public int Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IProductService _productService;

            public DeleteProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }
            public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _productService.GetProductById(request.Id);
                if (product == null)
                    return default;
                return await _productService.DeleteProduct(product);
            }
        }
    }
}
