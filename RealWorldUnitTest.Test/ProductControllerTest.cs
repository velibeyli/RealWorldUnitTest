using Moq;
using RealWorldUnitTest.Web.Controllers;
using RealWorldUnitTest.Web.Models;
using RealWorldUnitTest.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
