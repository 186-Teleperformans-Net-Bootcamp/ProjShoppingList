using Application.Common.Interfaces;
using Application.CQS;
using Application.CQS.CategoryR.Commands.AddCategory;
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
               .Verifiable("Notification was not sent.");
            AddCategoryCommandRequest request = new AddCategoryCommandRequest() { Name = "Yeni", Description = "Açıklama" };

            //Act
            var categoriesController = new CategoriesController(_mediator.Object);
            IActionResult createdResponse = await categoriesController.AddAsync(request);
            var result = createdResponse as StatusCodeResult;


            //Assert
            Assert.Equal(201, result.StatusCode);
        }
    }
}
