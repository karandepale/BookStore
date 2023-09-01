using ProductManagement.Context;
using ProductManagement.Entity;
using ProductManagement.Interfaces;
using ProductManagement.Model;
using System.ComponentModel.Design;

namespace ProductManagement.Services
{
    public class CommandService : ICommandService
    {
        private readonly ProductContext productContext;
        

        //CONSTRUCTOR:-
        public CommandService(ProductContext productContext)
        {
            this.productContext = productContext;
        }


        // ADD PRODUCTS:-
        public int AddProducts(CommandModel model)
        {
            try
            {
                ProductEntity productEntity = new ProductEntity();

                productEntity.ProductName = model.ProductName;
                productEntity.Qty = model.Qty;
                productEntity.Price = model.Price;
                productEntity.AddedBy = model.AddedBy;
                productEntity.AddedOn = model.AddedOn;

                productContext.Products.Add(productEntity);
                int result = productContext.SaveChanges();
                return result; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // UPDATE PRODUCT:-
        public int UpdateProduct(int productId, CommandModel model)
        {
            try
            {
               ProductEntity  productToUpdate = productContext.Products.FirstOrDefault(o => o.ProductID == productId);

                if (productToUpdate == null)
                {
                    return 0;
                }

       
                productToUpdate.ProductName = model.ProductName;
                productToUpdate.Qty = model.Qty;
                productToUpdate.Price = model.Price;
                productToUpdate.AddedBy = model.AddedBy;
                productToUpdate.AddedOn = DateTime.UtcNow; 

                int result = productContext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //DELETE PRODUCT:-
        public int DeleteProduct(int productId)
        {
            try
            {
                ProductEntity productToDelete = productContext.Products.FirstOrDefault(p => p.ProductID == productId);

                if (productToDelete == null)
                {
                    return 0;
                }

                productContext.Products.Remove(productToDelete);
                int result = productContext.SaveChanges();
                return result; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
