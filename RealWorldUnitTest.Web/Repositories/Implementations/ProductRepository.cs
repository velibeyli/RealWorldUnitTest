using RealWorldUnitTest.Web.Models;
using RealWorldUnitTest.Web.Repositories.Interfaces;

namespace RealWorldUnitTest.Web.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(UnitTestDbContext context) : base(context)
        {
        }
    }
}
