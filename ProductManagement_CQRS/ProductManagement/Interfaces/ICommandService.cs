using ProductManagement.Model;

namespace ProductManagement.Interfaces
{
    public interface ICommandService
    {
        public int AddProducts(CommandModel model);
        public int UpdateProduct(int productId, CommandModel model);
        public int DeleteProduct(int productId);
    }
}
