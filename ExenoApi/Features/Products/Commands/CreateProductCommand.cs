using System;
using System.Threading;
using System.Threading.Tasks;
using ExenoApi.Models;
using ExenoApi.Services;
using MediatR;

namespace ExenoApi.Features.Products.Commands
{
    public class CreateProductCommand :IRequest<Product>
    {
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            private readonly IProductService _productService;

            public CreateProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }
            public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    CreateDate = request.CreateDate,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                };

                return await _productService.CreateProduct(product);
            }
        }
    }
}
