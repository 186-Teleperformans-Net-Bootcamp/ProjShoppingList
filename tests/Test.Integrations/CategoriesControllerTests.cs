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
        private readonly HttpClient _client;
        public CategoriesControllerTests()
        {
        }
        [Fact]
        public async void Add()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("https://localhost:7004/api/Categories");
            var stringResult=await response.Content.ReadAsStringAsync();
            var list = System.Text.Json.JsonSerializer.Deserialize<List<GetAllCategoriesQueryResponse>>(stringResult);

            Assert.NotEqual(0,list.Count);

        }
       
    }
}
