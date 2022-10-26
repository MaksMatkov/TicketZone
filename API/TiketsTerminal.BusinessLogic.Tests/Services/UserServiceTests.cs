using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiketsTerminal.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TiketsTerminal.API.Controllers;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Services.Tests
{
    [TestClass()]
    public class UserServiceTests
    {

        [TestMethod()]
        public void SaveTest()
        {

            var userService = new Mock<IUserService>();
            userService.Setup(c => c.SaveAsync(null)).Throws(new ArgumentNullException());

            var result = false;
            try
            {
                userService.Object.SaveAsync(null);
            }
            catch
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetTest()
        {

            var userService = new Mock<IUserService>();
            userService.Setup(c => c.GetByKeysAsync(0)).ReturnsAsync(new User());


            var result = userService.Object.SaveAsync(0);


            Assert.IsTrue(result.Id == 0);
        }
    }
}