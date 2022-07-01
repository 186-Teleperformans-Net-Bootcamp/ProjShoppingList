using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UI
{
    public class ProductsControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        public ProductsControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }
    }
}
