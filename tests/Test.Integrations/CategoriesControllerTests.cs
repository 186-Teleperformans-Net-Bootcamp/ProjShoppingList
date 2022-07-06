using Application.CQS.CategoryR.Commands.AddCategory;
using Application.CQS.CategoryR.Queries.GetAllCategories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Integrations
{
    public class CategoriesControllerTests
    {
       
        [Fact]
        public async void GetAsync()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("/api/Categories");
            var stringResult=await response.Content.ReadAsStringAsync();
            var list = System.Text.Json.JsonSerializer.Deserialize<List<GetAllCategoriesQueryResponse>>(stringResult);

            Assert.NotEqual(0,list.Count);

        }

        [Fact]
        public async void PostAsync_TrueModel()
        {
          
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            StringContent httpContent = new StringContent(@"{ ""name"": ""Trying1"", ""description"": ""Desc1"" }", Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/Categories", httpContent);
            var result = response.StatusCode;

            Assert.Equal(System.Net.HttpStatusCode.Created,result);
        }
        [Fact]
        public async void PostAsync_FalseModel()
        {
       
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            StringContent httpContent = new StringContent(@"{ ""name"": """", ""description"": """" }", Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/Categories", httpContent);
            var result = response.StatusCode;

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result);
        }
    }
}
