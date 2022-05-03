using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExenoApi.Controllers;
using ExenoApi.Features.Products.Commands;
using ExenoApi.Features.Products.Queries;
using ExenoApi.Models;
using ExenoApi.Services;
using MediatR;
using Moq;
using Xunit;

namespace Tests.Mocks
{
    public class ProductsControllerTest
    {
        private Mock<IProductService> mockProductService;

        List<Product>_mockList = new List<Product>
        {
            new Product
            {
                Id = 1, Name = "TestOne", Description = "Test One description", Price = 12.99,
                CreateDate = DateTime.Today
            },
            new Product
            {
                Id = 2, Name = "TesTwo", Description = "Test Two description", Price = 53.50,
                CreateDate = DateTime.Today
            },
            new Product
            {
                Id = 3, Name = "TestThree", Description = "Test Three description", Price = 10,
                CreateDate = DateTime.Today
            }
        };

        public ProductsControllerTest()
        {
            mockProductService = new Mock<IProductService>();

            mockProductService.Setup(x => x.GetProductList()).Returns(Task.FromResult(_mockList));
            mockProductService.Setup(x => x.GetProductById(It.Is<int>(s => _mockList.Select(p => p.Id).Contains(s))))
                .Returns(Task.FromResult(_mockList.First()));
            mockProductService.Setup(x => x.GetProductById(It.Is<int>(s => !_mockList.Select(p => p.Id).Contains(s)))).Returns(Task.FromResult<Product>(null));
        }


        [Fact]
        public async Task GetAll_ReturnsAll()
        {
            var products = new GetAllProductsQuery.GetAllProductsQueryHandler(mockProductService.Object);
            var result = await products.Handle(new GetAllProductsQuery(), new CancellationToken());
            Assert.NotNull(result);
            Assert.Equal(_mockList.Count(),result.Count());
        }

        [Fact]
        public async Task GetOne_ReturnsOne()
        {
            var products = new GetProductByIdQuery.GetProductByIdQueryHandler(mockProductService.Object);
            var result = await products.Handle(new GetProductByIdQuery {Id = 1}, new CancellationToken());
            Assert.NotNull(result);
            
        }
        [Fact]
        public async Task GetOne_ReturnsNull()
        {
            var products = new GetProductByIdQuery.GetProductByIdQueryHandler(mockProductService.Object);
            var result = await products.Handle(new GetProductByIdQuery { Id = 99999999 }, new CancellationToken());
            Assert.Null(result);

        }
    }
}
