using Application.Common.Interfaces;
using Application.Common.Repositories;
using Application.Common.Repositories.CategoryRepo;
using Application.CQS;
using Application.CQS.CategoryR.Commands.AddCategory;
using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.CQS.CategoryRTests.AddCategory
{
    public class AddCategoryCommandHandlerTests
    {

        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ICategoryWriteRepository> _categoryWriteRepositoryMock;
        private readonly Mock<IWriteRepository<Category>> _writeRepositoryMock;
        private static IMapper _mapper;
        public AddCategoryCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _categoryWriteRepositoryMock=new Mock<ICategoryWriteRepository>();
            _writeRepositoryMock=new Mock<IWriteRepository<Category>>();

        }

        [Fact]
        public async void AddCategory_TrueCondition_ReturnsTrue()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new CategoryProfile());
            });
            _mapper = mapperConfig.CreateMapper();
            AddCategoryCommandRequest request = new()
            {
                Description = "Desc",
                Name = "Name"
            };
            var mappedCategory = _mapper.Map<Category>(request);
            var categoryWriteRepositoryMock = new Mock<IWriteRepository<Category>>();
            categoryWriteRepositoryMock.Setup(c => c.AddAsync(mappedCategory)).ReturnsAsync(true).Verifiable("Added");
            _unitOfWorkMock.Setup(s => s.CategoryWriteRepository.AddAsync(mappedCategory)).ReturnsAsync(true).Verifiable("T");
            _categoryWriteRepositoryMock.Setup(s => s.AddAsync(mappedCategory)).ReturnsAsync(true).Verifiable("a");
            _writeRepositoryMock.Setup(s => s.AddAsync(mappedCategory)).ReturnsAsync(true).Verifiable("aa");
            //await _unitOfWork.Setup(u => u.CategoryWriteRepository.AddAsync(mapped))
            CancellationTokenSource cancelTokenSource = new();
            CancellationToken token = cancelTokenSource.Token;

            //Act
            AddCategoryCommandHandler addCategoryCommandHandler = new(_mapper, _unitOfWorkMock.Object);
            var response = await addCategoryCommandHandler.Handle(request, token);
            //Assert
            Assert.Equal(true, response.IsSuccess);
        }
    }
}
