using BookStore.Controllers;
using BookStore.Models.Classes;
using BookStore.Models.DbContext;
using BookStore.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var obj = new Book()
            {
                Name = "123",
                Author = GetHashCode().ToString(),
                Description = GetHashCode().ToString(),
                BookId = GetHashCode(),
                Year = GetHashCode().ToString(),
            };
            var mock = new Mock<IBookRepository>();
            mock.Setup(a => a.DeleteBook(1)).Returns(obj);

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["massage"] = "admin";
            var controller = new AdminController(mock.Object)
            {
                TempData = tempData
            };

            ViewResult result = controller.Delete(1) as ViewResult;

            Assert.IsNull(result);
        }
        [Test]
        public void Test2()
        {
            var obj = new Book()
            {
                Name = "123",
                Author = GetHashCode().ToString(),
                Description = GetHashCode().ToString(),
                BookId = GetHashCode(),
                Year = GetHashCode().ToString(),
            };
            var mock = new Mock<IBookRepository>();
            mock.Setup(a => a.DeleteBook(1)).Returns(obj);

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["massage"] = "admin";
            var controller = new AdminController(mock.Object)
            {
                TempData = tempData
            };

            ViewResult result = controller.Delete(1) as ViewResult;

            Assert.IsNull(result);
        }
    }
}