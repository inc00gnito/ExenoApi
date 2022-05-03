using System;
using ExenoApi.Controllers;
using ExenoApi.Features.Products.Queries;
using MediatR;
using Xunit;

namespace ApiTests
{
    public class ProductControllerTest
    {
        private readonly IMediator _mediator;
        private readonly ProductsController _controller;

        public ProductControllerTest(IMediator mediator, ProductsController controller)
        {
            _mediator = mediator;
            _controller = controller;
        }
        [Fact]
        public void GetById_KnownIdPassed_ReturnsRecord()
        {
            var foundResult = _mediator.Send(new GetProductByIdQuery() {Id = 1});

        }
    }
}
