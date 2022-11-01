using Microsoft.AspNetCore.Mvc;
using Moq;
using RealWorldUnitTest.Web.Controllers;
using RealWorldUnitTest.Web.Models;
using RealWorldUnitTest.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RealWorldUnitTest.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductsController _controller;
        private List<Product> products;
        public ProductControllerTest()
        {
            _mockRepo = new Mock<IProductRepository>();
            _controller = new ProductsController(_mockRepo.Object);

            products = new List<Product>()
            {
                new Product{ Id = 1,Name = "Pen",Price = 1.4M, Stock = 50, Color = "Green"},
                new Product{ Id = 2,Name = "Notebook",Price = 2.5M, Stock = 100, Color = "Red"},
                new Product{ Id = 3,Name = "Pencil",Price = 0.5M, Stock = 120, Color = "Black"},
                new Product{ Id = 4,Name = "Book",Price = 10, Stock = 30, Color = "Blue"},
            };
        }

        [Fact]
        public async void Index_ActionExecute_ReturnView()
        {
            var products = await _controller.Index();

            Assert.IsType<ViewResult>(products);
        }

        [Fact]
        public async void Index_ActionExecute_ReturnProduct()
        {
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(products);

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var productList = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);

            Assert.Equal<int>(4, productList.Count());

        }


        [Fact]
        public async void Details_IdIsNull_ReturnRedirectToIndexAction()
        {
            var result = await _controller.Details(null);

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index",redirect.ActionName);
        }

        [Fact]
        public async void Details_InvalidId_ReturnNotFound()
        {
            Product product = null;

            _mockRepo.Setup(x => x.GetById(0)).ReturnsAsync(product);

            var result = await _controller.Details(0);

            var redirect = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404,redirect.StatusCode); 

        }

        [Fact]
        public void Create_ActionExecute_ReturnView()
        {
            var result = _controller.Create();

            Assert.IsType<ViewResult>(result);
        }
    }
}
