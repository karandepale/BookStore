using ProductManagement.Model;

namespace ProductManagement.Interfaces
{
    public interface IQueryService
    {
        public List<QueryModel> GetAllProducts();
        public QueryModel GetProductById(int productId);
    }
}
