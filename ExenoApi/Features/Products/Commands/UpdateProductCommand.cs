using System;
using System.Threading;
using System.Threading.Tasks;
using ExenoApi.Models;
using ExenoApi.Services;
using MediatR;

namespace ExenoApi.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IProductService _productService;

            public UpdateProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }
            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _productService.GetProductById(request.Id);
                if (product == null)
                    return default;

                product.CreateDate = request.CreateDate;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Name = request.Name;
                return await _productService.UpdateProduct(product);
            }
        }
    }
}
