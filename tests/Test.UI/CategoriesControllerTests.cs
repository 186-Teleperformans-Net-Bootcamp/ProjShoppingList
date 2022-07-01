using Application.Common.Interfaces;
using Application.CQS;
using Application.CQS.CategoryR.Commands.AddCategory;
using Application.CQS.CategoryR.Commands.UpdateCategory;
using Application.CQS.CategoryR.Queries.GetAllCategories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UI.Controllers;

namespace Test.UI
{
    public class CategoriesControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        //private readonly CategoriesController _categoriesController;
        public CategoriesControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async void AddCategory_CorrectModel_ReturnsOk()
        {
            //Arrange
            _mediator.Setup(m => m.Send(It.IsAny<AddCategoryCommandRequest>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new CommandResponse() { IsSuccess = true })
               .Verifiable("Model is true.");
            AddCategoryCommandRequest request = new AddCategoryCommandRequest() { Name = "Yeni", Description = "Açıklama" };

            //Act
            var categoriesController = new CategoriesController(_mediator.Object);
            IActionResult createdResponse = await categoriesController.AddAsync(request);
            var result = createdResponse as StatusCodeResult;


            //Assert
            Assert.Equal(201, result.StatusCode);
        }
        [Fact]
        public async void GetAllCategories_ReturnsOk()
        {
            //Arrange
            var list = new List<GetAllCategoriesQueryResponse>() {
                new GetAllCategoriesQueryResponse { Name = "Meyve" },
                    new GetAllCategoriesQueryResponse { Name = "Elektronik" }
            };
            _mediator.Setup(m => m.Send(It.IsAny<GetAllCategoriesQueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(list)
                .Verifiable("List returned");
            GetAllCategoriesQueryRequest request = new GetAllCategoriesQueryRequest();

            //Act
            var categoriesController = new CategoriesController(_mediator.Object);
            IActionResult okResponse = await categoriesController.GetAllCategoriesAsync(request);
            var result = okResponse as OkObjectResult;
            var resultObject = okResponse as ObjectResult;
            var resultList = resultObject.Value;


            //Assert
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<List<GetAllCategoriesQueryResponse>>(resultList);
            Assert.Equal(list, resultList);
        }
        [Fact]
        public async void UpdateCategory_CorrectModel_ReturnsOk()
        {
            //Arrange
            _mediator.Setup(m => m.Send(It.IsAny<UpdateCategoryCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CommandResponse { IsSuccess = true })
                .Verifiable("Model is true");
            var id = Guid.NewGuid().ToString();
            UpdateCategoryCommandRequest request = new UpdateCategoryCommandRequest { Id = id, Description = "Updated description", Name = "Updated Name" };

            //Act 
            var categoriesController = new CategoriesController(_mediator.Object);
            IActionResult updatedResponse = await categoriesController.UpdateAsync(id, request);
            var result = updatedResponse as StatusCodeResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
        }
    }
}
