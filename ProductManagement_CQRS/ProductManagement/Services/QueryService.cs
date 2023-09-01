using ProductManagement.Context;
using ProductManagement.Entity;
using ProductManagement.Interfaces;
using ProductManagement.Model;

namespace ProductManagement.Services
{
    public class QueryService : IQueryService
    {
        private readonly ProductContext productContext;

        //CONATRUCTOR:-
        public QueryService(ProductContext productContext)
        {
            this.productContext = productContext;
        }


        // GET ALL PRODUCTS:-
        public List<QueryModel> GetAllProducts()
        {
            try
            {
                List<QueryModel> queryModels = new List<QueryModel>();

                // Fetch all products from the database
                List<ProductEntity> productEntities = productContext.Products.ToList();

                foreach (var productEntity in productEntities)
                {
                    QueryModel queryModel = new QueryModel();
                    queryModel.ProductID = productEntity.ProductID;
                    queryModel.ProductName = productEntity.ProductName;
                    queryModel.Qty = productEntity.Qty;
                    queryModel.Price = productEntity.Price;
                    queryModel.AddedBy = productEntity.AddedBy;
                    queryModel.AddedOn = productEntity.AddedOn;

                    queryModels.Add(queryModel);
                }

                return queryModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // GET PRODUCT BY PRODUCT_ID:-
        public QueryModel GetProductById(int productId)
        {
            try
            {
                ProductEntity productEntity = productContext.Products.FirstOrDefault(p => p.ProductID == productId);

                if (productEntity == null)
                {
                    return null;
                }

                QueryModel queryModel = new QueryModel
                {
                    ProductID = productEntity.ProductID,
                    ProductName = productEntity.ProductName,
                    Qty = productEntity.Qty,
                    Price = productEntity.Price,
                    AddedBy = productEntity.AddedBy,
                    AddedOn = productEntity.AddedOn
                };

                return queryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
