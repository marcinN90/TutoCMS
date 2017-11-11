using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuto.Data.Models;
using Tuto.UI.Controllers;
using Tuto.UI.Models;
using TutoDataRepo;
using Xunit;

namespace Tuto.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task Index_Returns_ViewResult_WithModel_Containing_List_Of_Categories_And_Entries()
        {
            //ARRANGE
            var mockRepo = new Mock<ITudoDataRepository>();
            mockRepo.Setup(x => x.GetAllCategories()).Returns(Task.FromResult(GetCategories()));
            mockRepo.Setup(x => x.GetWebsiteDetails()).Returns(Task.FromResult(WebsiteDetails));
            mockRepo.Setup(x => x.GetHomePageSettings()).Returns(Task.FromResult(HomePageSettings));
            mockRepo.Setup(x => x.GetAllLinks()).Returns(Task.FromResult(Links));

            var controller = new HomeController(mockRepo.Object);

            //ACT
            var result = await controller.Index();

            //var model = result.
            //ASSERT
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomePageViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Categories.Count());
        }

        public List<Category> GetCategories()
        {
            var categories = new List<Category>
             {
             new Category { Id = 1, Title = "Awesome", Description = "This is awesome cateogry for make more awesome courses." },
             new Category { Id = 2, Title = "Very Awesome", Description = "This is second awesome cateogry for make more awesome courses." }
             };

            List<Entry> Entries = new List<Entry>
            {
                new Entry { Id = 1, CategoryId = 1, Title = "Very awesome part 1", Content = "Content"},
                new Entry { Id = 2, CategoryId = 1, Title = "Very awesome part 2", Content = "Content"},
                new Entry { Id = 3, CategoryId = 2, Title = "Very awesome part 5", Content = "Content"},
                new Entry { Id = 4, CategoryId = 2, Title = "Very awesome part 6", Content = "Content"},
            };

            foreach (var category in categories)
            {
                category.Entries = Entries.Where(x => x.CategoryId.Equals(category.Id)).ToList();
            }
            return categories;
        }

        public WebsiteDetails WebsiteDetails = new WebsiteDetails
        {
            Title = "WebsiteTtile",
            OwnerEmail = "example@example.com"
        };

        public HomePageSettings HomePageSettings = new HomePageSettings()
        {
            Title = "HomeTitle",
            SeoDescription = "Awesome SEO Description",
            Descritpion = "Long Description"
        };

        public List<Link> Links = new List<Link>
        {
            new Link { Id = 1, LinkTitle = "Great link to share", UrlAddress = "example.com"},
            new Link { Id = 2, LinkTitle = "Second great link to share", UrlAddress = "example.com2"}
        };
    }
}
