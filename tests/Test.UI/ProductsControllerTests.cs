using Application.Common.Models;
using Application.CQS;
using Application.CQS.ProductR.Commands.AddProductToShopList;
using Application.CQS.ProductR.Commands.BuyAllProducts;
using Application.CQS.ProductR.Commands.BuyProduct;
using Application.CQS.ProductR.Commands.RemoveProduct;
using Application.CQS.ProductR.Commands.UpdateProduct;
using Application.CQS.ProductR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Controllers;

namespace Test.UI
{
    public class ProductsControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        public ProductsControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }
        [Fact]
        public async void GetAllProductsInShopList_TrueConditions_ReturnsOk()
        {
            //Arrange
            string id;
            PaginatedList<GetAllProductsInShopListQueryResponse> responseList;
            GetAllProductsInShopListQueryRequest request;
            ArrangeGetAll(out id, out responseList, out request);

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult okResponse = await productsController.GetAllProductsInShopListAsync(id, request);
            var result = okResponse as OkObjectResult;
            var resultList = okResponse as ObjectResult;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(responseList, resultList.Value);
        }


        [Fact]
        public async void GetAllProductsInShopList_FalseShopListId_ReturnBadRequest()
        {
            //Arrange
            string id;
            string notMatchedId = Guid.NewGuid().ToString();
            PaginatedList<GetAllProductsInShopListQueryResponse> responseList;
            GetAllProductsInShopListQueryRequest request;
            ArrangeGetAll(out id, out responseList, out request);

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult okResponse = await productsController.GetAllProductsInShopListAsync(notMatchedId, request);
            var result = okResponse as BadRequestResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
            //Assert.Equal(responseList, resultList.Value);
        }

        [Fact]
        public async void AddProductToShopList_TrueConditions_ReturnsCreated()
        {
            //Arrange
            string shopListId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<AddProductToShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True model");
            AddProductToShopListCommandRequest request = new()
            {
                Amount = 5,
                Name = "Banana",
                ShopListId = shopListId,
                Price = 1,
                Unit = "Kilogramme"
            };
            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult createdResponse = await productsController.AddAsync(shopListId, request);
            var result = createdResponse as StatusCodeResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
        }
        [Fact]
        public async void AddProductToShopList_FalseShopListId_ReturnsBadRequest()
        {
            //Arrange
            string shopListId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<AddProductToShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True model");
            AddProductToShopListCommandRequest request = new()
            {
                Amount = 5,
                Name = "Banana",
                ShopListId = Guid.NewGuid().ToString(),
                Price = 1,
                Unit = "Kilogramme"
            };
            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult createdResponse = await productsController.AddAsync(shopListId, request);
            var result = createdResponse as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public async void AddProductToShopList_FalseModel_ReturnsErrors()
        {
            //Arrange
            string shopListId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<AddProductToShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = false,Error="Model not correct" })
                .Verifiable("True model");
            AddProductToShopListCommandRequest request = new()
            {
                Amount = 5,
                Name = "",
                ShopListId = shopListId,
                Price = 1,
                Unit = ""
            };
            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult createdResponse = await productsController.AddAsync(shopListId, request);
            var errors = createdResponse as ObjectResult;

            //Assert
            Assert.NotNull(errors);
        }
        [Fact]
        public async void UpdateProduct_TrueConditions_ReturnsOk()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<UpdateProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true });
            UpdateProductCommandRequest request = new()
            {
                Id = id,
                Name = "Apple",
                Price = 1,
                Unit = "Kilogramme"
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult updatedResponse = await productsController.UpdateAsync(id, request);
            var result = updatedResponse as StatusCodeResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async void UpdateProduct_FalseId_ReturnsBadRequest()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<UpdateProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true });
            UpdateProductCommandRequest request = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Apple",
                Price = 1,
                Unit = "Kilogramme"
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult updatedResponse = await productsController.UpdateAsync(id, request);
            var result = updatedResponse as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void UpdateProduct_FalseModel_ReturnsErrors()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<UpdateProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = false,Error="Model is false" });
            UpdateProductCommandRequest request = new()
            {
                Id = id,
                Name = "Apple",
                Price = 1,
                Unit = "Kilogramme"
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult updatedResponse = await productsController.UpdateAsync(id, request);
            var error = updatedResponse as ObjectResult;

            //Assert
            Assert.NotNull(error.Value);
        }

        [Fact]
        public async void RemoveProduct_TrueConditions_ReturnsOk()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<SoftRemoveProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true });
            SoftRemoveProductCommandRequest request = new()
            {
               Id=id
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult removedResponse = await productsController.SoftRemoveAsync(id, request);
            var result = removedResponse as StatusCodeResult;

            //Assert
            Assert.Equal(200,result.StatusCode);
        }
        [Fact]
        public async void RemoveProduct_FalseId_ReturnsBadRequest()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<SoftRemoveProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true });
            SoftRemoveProductCommandRequest request = new()
            {
                Id = Guid.NewGuid().ToString()
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult removedResponse = await productsController.SoftRemoveAsync(id, request);
            var result = removedResponse as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public async void RemoveProduct_FalseModel_ReturnsError()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<SoftRemoveProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = false,Error="Model is not correct" });
            SoftRemoveProductCommandRequest request = new()
            {
                Id = id
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult removedResponse = await productsController.SoftRemoveAsync(id, request);
            var result = removedResponse as ObjectResult;

            //Assert
            Assert.NotNull(result.Value);
        }
        [Fact]
        public async void BuyProduct_TrueConditions_ReturnsOk()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<BuyProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true});
            BuyProductCommandRequest request = new()
            {
                Id = id
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult boughtResponse = await productsController.BuyProductAsync(id, request);
            var result = boughtResponse as StatusCodeResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async void BuyProduct_FalseId_ReturnsBadRequest()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<BuyProductCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true });
            BuyProductCommandRequest request = new()
            {
                Id = Guid.NewGuid().ToString()
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult boughtResponse = await productsController.BuyProductAsync(id, request);
            var result = boughtResponse as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public async void BuyAllProducts_TrueConditions_ReturnsOk()
        {
            //Arrange
            string shopListId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<BuyAllProductsCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true });
            BuyAllProductsCommandRequest request = new()
            {
                ShopListId = shopListId
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult boughtResponse = await productsController.BuyAllProductsAsync(shopListId, request);
            var result = boughtResponse as StatusCodeResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async void BuyAllProducts_FalseShopListId_ReturnsBadRequest()
        {
            //Arrange
            string shopListId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<BuyAllProductsCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true });
            BuyAllProductsCommandRequest request = new()
            {
                ShopListId = Guid.NewGuid().ToString()
            };

            //Act
            var productsController = new ProductsController(_mediator.Object);
            IActionResult boughtResponse = await productsController.BuyAllProductsAsync(shopListId, request);
            var result = boughtResponse as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        private void ArrangeGetAll(out string id, out PaginatedList<GetAllProductsInShopListQueryResponse> responseList, out GetAllProductsInShopListQueryRequest request)
        {
            var list = new List<GetAllProductsInShopListQueryResponse> {
                new GetAllProductsInShopListQueryResponse {Name="Laptop",Price=100,Unit="Adet" },
                new GetAllProductsInShopListQueryResponse {Name="Laptop",Price=200,Unit="Adet" },
            };
            id = Guid.NewGuid().ToString();
            int count = list.Count;
            int pageSize = 10;
            int pageNumber = 1;
            responseList = new PaginatedList<GetAllProductsInShopListQueryResponse>(list, count, pageNumber, pageSize);
            _mediator.Setup(m => m.Send(It.IsAny<GetAllProductsInShopListQueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseList)
                .Verifiable("PaginatedList returned");

            request = new()
            {
                PageNumber = 1,
                PageSize = 10,
                ShopListId = id
            };
        }
    }
}
