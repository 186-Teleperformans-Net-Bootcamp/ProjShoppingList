using Application.Common.Models;
using Application.CQS;
using Application.CQS.ProductR.Queries;
using Application.CQS.ShopListR.Commands.AddShopList;
using Application.CQS.ShopListR.Commands.CompleteShopList;
using Application.CQS.ShopListR.Commands.RemoveShopList;
using Application.CQS.ShopListR.Commands.UpdateShopList;
using Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination;
using Application.CQS.ShopListR.Queries.GetAllUserShopListsByCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class ShopListsControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        public ShopListsControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }
        [Fact]
        public async void GetAllShopListsByCategoryId_TrueCondition_ReturnsList()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            string categoryId = Guid.NewGuid().ToString();
            var list = new List<GetAllUsersShopListsByCategoryQueryResponse>()
            {
                new(){Title="List1",CategoryName="Category1",Description="Desc1"},
                new(){Title="List2",CategoryName="Category2",Description="Desc2"}
            };

            int count = list.Count;
            int pageSize = 10;
            int pageNumber = 1;
            var paginatedList = new PaginatedList<GetAllUsersShopListsByCategoryQueryResponse>(list, count, pageNumber, pageSize);

            var request = new GetAllUsersShopListsByCategoryQueryRequest()
            {
                CategoryId = categoryId,
                UserId = userId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            _mediator.Setup(m => m.Send(It.IsAny<GetAllUsersShopListsByCategoryQueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paginatedList)
                .Verifiable("PaginatedList returned");

            //Act
            var shopListsController = new ShopListsController(_mediator.Object);
            // For prevent null exception on Response.Headers.Add()
            shopListsController.ControllerContext = new ControllerContext();
            shopListsController.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = await shopListsController.GetAllShopListByCategoryIdAsync(categoryId, userId, request);
            var resultList = response as ObjectResult;

            //Assert
            Assert.Equal(paginatedList, resultList.Value);
        }
        [Fact]
        public async void GetAllShopListsByUserId_TrueCondition_ReturnsList()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            var list = new List<GetAllShopListsQueryResponse>()
            {
                new(){Title="List1",CategoryName="Category1",Description="Desc1"},
                new(){Title="List2",CategoryName="Category2",Description="Desc2"}
            };

            int count = list.Count;
            int pageSize = 10;
            int pageNumber = 1;
            var paginatedList = new PaginatedList<GetAllShopListsQueryResponse>(list, count, pageNumber, pageSize);

            var request = new GetAllShopListsQueryRequest()
            {
                UserId = userId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            _mediator.Setup(m => m.Send(It.IsAny<GetAllShopListsQueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paginatedList)
                .Verifiable("PaginatedList returned");

            //Act
            var shopListsController = new ShopListsController(_mediator.Object);
            // For prevent null exception on Response.Headers.Add()
            shopListsController.ControllerContext = new ControllerContext();
            shopListsController.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = await shopListsController.GetAllShopListByUserIdAsync(userId, request);
            var resultList = response as ObjectResult;

            //Assert
            Assert.Equal(paginatedList, resultList.Value);
        }
        [Fact]
        public async void GetAllProductsByShopListId_TrueCondition_ReturnsList()
        {
            //Arrange
            string shopListId = Guid.NewGuid().ToString();
            var list = new List<GetAllProductsInShopListQueryResponse>()
            {
                new(){Name="Product1",Price=5,Unit="Kilogramme"},
                new(){Name="Product2",Price=5,Unit="Kilogramme"}
            };

            int count = list.Count;
            int pageSize = 10;
            int pageNumber = 1;
            var paginatedList = new PaginatedList<GetAllProductsInShopListQueryResponse>(list, count, pageNumber, pageSize);

            var request = new GetAllProductsInShopListQueryRequest()
            {
                ShopListId= shopListId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            _mediator.Setup(m => m.Send(It.IsAny<GetAllProductsInShopListQueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paginatedList)
                .Verifiable("PaginatedList returned");

            //Act
            var shopListsController = new ShopListsController(_mediator.Object);
            // For prevent null exception on Response.Headers.Add()
            shopListsController.ControllerContext = new ControllerContext();
            shopListsController.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = await shopListsController.GetAllProductsByShopListId(shopListId, request);
            var resultList = response as ObjectResult;

            //Assert
            Assert.Equal(paginatedList, resultList.Value);
        }

        [Fact]
        public async void AddShopList_TrueCondition_ReturnsOk()
        {
            //Arrange
            string categoryId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<AddShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True conditions");
            var request=new AddShopListCommandRequest
            {
                CategoryId = categoryId,
                Description = "Desc1",
                Title = "Title",
                UserId = userId
            };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.AddAsync(request);
            var result=response as StatusCodeResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
        }
        [Fact]
        public async void AddShopList_FalseModel_ReturnsError()
        {
            //Arrange
            string categoryId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<AddShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = false,Error="Model is not valid" })
                .Verifiable("True conditions");
            var request = new AddShopListCommandRequest
            {
                CategoryId = categoryId,
                Description = "",
                Title = "",
                UserId = userId
            };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.AddAsync(request);
            var result = response as ObjectResult;

            //Assert
            Assert.NotEmpty(result.Value.ToString());
        }
        [Fact]
        public async void UpdateShopList_TrueCondition_ReturnsOk()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            string categoryId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<UpdateShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True conditions");
            var request = new UpdateShopListCommandRequest
            {
                CategoryId= categoryId,
                Description = "Desc1",
                Title = "Title",
                Id= id
            };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.UpdateAsync(id,request);
            var result = response as StatusCodeResult;

            //Assert
            Assert.Equal(204, result.StatusCode);
        }
        [Fact]
        public async void UpdateShopList_FalseModel_ReturnsError()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            string categoryId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<UpdateShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true})
                .Verifiable("True conditions");
            var request = new UpdateShopListCommandRequest
            {
                CategoryId = categoryId,
                Description = "Desc1",
                Title = "Title",
                Id = Guid.NewGuid().ToString()
            };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.UpdateAsync(id, request);
            var result = response as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public async void CompleteShopList_TrueCondition_ReturnsOk()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            string categoryId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<CompleteShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True conditions");
            var request = new CompleteShopListCommandRequest
            {
                Id = id
            };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.CompleteAsync(id, request);
            var result = response as StatusCodeResult;

            //Assert
            Assert.Equal(204, result.StatusCode);
        }
        [Fact]
        public async void CompleteShopList_FalseId_ReturnsBadRequest()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            string categoryId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<CompleteShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True conditions");
            var request = new CompleteShopListCommandRequest
            {
                Id = Guid.NewGuid().ToString()
            };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.CompleteAsync(id, request);
            var result = response as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        [Fact]
        public async void RemoveShopList_TrueCondition_ReturnsBadRequest()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            string categoryId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<RemoveShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True conditions");
            var request = new RemoveShopListCommandRequest
            {
                Id = id
            };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.RemoveAsync(id, request);
            var result = response as StatusCodeResult;

            //Assert
            Assert.Equal(204, result.StatusCode);
        }
        [Fact]
        public async void RemoveShopList_FalseId_ReturnsBadRequest()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            string categoryId = Guid.NewGuid().ToString();
            _mediator.Setup(m => m.Send(It.IsAny<RemoveShopListCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("True conditions");
            var request = new RemoveShopListCommandRequest
            {
                Id = Guid.NewGuid().ToString()
        };
            var shopListsController = new ShopListsController(_mediator.Object);

            //Act
            var response = await shopListsController.RemoveAsync(id, request);
            var result = response as StatusCodeResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }
    }
}
