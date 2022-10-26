using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiketsTerminal.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TiketsTerminal.BusinessLogic.Abstraction;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TiketsTerminal.API.Controllers.Tests
{
    [TestClass()]
    public class RoomsControllerTests
    {
        public Mock<IRoomService>  mockRepository = new Mock<IRoomService>();
        public Mock<IMapper> mockMapper = new Mock<IMapper>();

        //[TestMethod()]
        //public async void GetTest()
        //{
        //    // Arrange
        //  //  var mockRepository = new Mock<IRoomService>();
        // //   var controller = new RoomsController(mockRepository.Object, mockMapper.Object);

        //    // Act
        // //   var actionResult = await controller.Delete(10);

        //    // Assert
        // //   Assert.IsInstanceOfType(actionResult, typeof(bool));
        //  //  Assert.IsTrue(!actionResult);
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void AddTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UpdateTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var controller = new RoomsController(mockRepository.Object, mockMapper.Object);

            // Act
            var actionResult = controller.Delete(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(bool));
            Assert.IsTrue(!actionResult);
        }
    }
}