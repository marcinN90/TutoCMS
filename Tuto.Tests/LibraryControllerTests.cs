using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuto.Data.Models;
using Tuto.UI.Controllers;
using TutoDataRepo;
using Xunit;
using static System.Net.WebRequestMethods;

namespace Tuto.Tests
{
    public class LibraryControllerTests
    {
        [Fact]
        public async Task ShowEntry_Should_Return_NotFound_When_Id_INull ()
        {
            // ARRANGE
            var mockRepo = new Mock<ITudoDataRepository>();
            var controller = new LibraryController(mockRepo.Object);

            var result = await controller.ShowEntry(null);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task ShowEntry_Should_Return_NotFound_When_Id_Not_Exists()
        {
            int id = 1;
            var mockRepo = new Mock<ITudoDataRepository>();
            mockRepo.Setup(x => x.GetEntryById(id)).Returns(Task.FromResult(EntryNotFoundReturnNull()));
            var controller = new LibraryController(mockRepo.Object);

            var result = await controller.ShowEntry(id);
            Assert.IsType<NotFoundResult>(result);
        }

        public Entry EntryNotFoundReturnNull()
        {
            return null;
        }
    }
}
