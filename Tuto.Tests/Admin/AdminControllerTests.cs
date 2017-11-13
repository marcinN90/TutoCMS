using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuto.Data.Models;
using Tuto.UI.Controllers;
using Tuto.UI.Models;
using TutoDataRepo;
using Xunit;

namespace Tuto.Tests.Admin
{
    public class AdminControllerTests
    {
        [Fact]
        public async Task AllItemsFromRepositoryAreProperlyCounted()
        {
            var mockRepo = new Mock<ITudoDataRepository>();
            mockRepo.Setup(x => x.GetAllCategories())
                .Returns(Task.FromResult(new List<Category>
                {
                    new Category {Id = 1, Description = "Exx", ShortSeoDescription = "short", Title = "testcategory" },
                    new Category {Id = 2, Description = "Exx", ShortSeoDescription = "short", Title = "testcategory" },
                    new Category {Id = 3, Description = "Exx", ShortSeoDescription = "short", Title = "testcategory" }
                }));
            mockRepo.Setup(x => x.GetAllEntries())
                .Returns(Task.FromResult(new List<Entry>
                {
                    new Entry {Id = 1, CategoryId = 2, Content = "SampleContent", LastRevisionAt = DateTime.Now, SeoDescription = "Seo", Title = "EntryTitile" },
                    new Entry {Id = 2, CategoryId = 2, Content = "SampleContent", LastRevisionAt = DateTime.Now, SeoDescription = "Seo", Title = "EntryTitile" },
                    new Entry {Id = 3, CategoryId = 2, Content = "SampleContent", LastRevisionAt = DateTime.Now, SeoDescription = "Seo", Title = "EntryTitile" },
                    new Entry {Id = 4, CategoryId = 2, Content = "SampleContent", LastRevisionAt = DateTime.Now, SeoDescription = "Seo", Title = "EntryTitile" }
                }));
            mockRepo.Setup(x => x.GetAllLinks())
                .Returns(Task.FromResult(new List<Link>
                {
                    new Link { Id = 1, LinkTitle = "Link Titile", UrlAddress = "example.com" },
                    new Link { Id = 2, LinkTitle = "Link Titile", UrlAddress = "example.com" },
                    new Link { Id = 3, LinkTitle = "Link Titile", UrlAddress = "example.com" },
                    new Link { Id = 4, LinkTitle = "Link Titile", UrlAddress = "example.com" },
                    new Link { Id = 5, LinkTitle = "Link Titile", UrlAddress = "example.com" }
                }));

            var controller = new AdminController(mockRepo.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AdminViewModel>(viewResult.ViewData.Model);
            Assert.Equal(3, model.NumberOfAllCategories);
            Assert.Equal(4, model.NumberofAllEntries);
            Assert.Equal(5, model.NumberOfAllLinks);
        }
    }
}
