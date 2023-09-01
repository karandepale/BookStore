using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Interfaces;
using ProductManagement.Model;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandService commandService;
        private readonly IQueryService queryService;


        //CONSTRUCTOR:-
        public ProductController(ICommandService commandService , IQueryService queryService)
        {
            this.commandService = commandService;
            this.queryService = queryService;
        }



        // ADDD PRODUCTS:-
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProducts(CommandModel model)
        {
            var result = commandService.AddProducts(model);
            if(result != null)
            {
                return Ok(new { success = true, message = "Products Added Successfully", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "Unable To Add Products", data = result });
            }
        }



        // GET ALL PRODUCTS:-
        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = queryService.GetAllProducts();
            if (products != null)
            {
                return Ok(new { success = true, message = "Products fetched Successfully", data = products });
            }
            else
            {
                return NotFound(new { success = false, message = "Unable To fetch Products", data = products });
            }
        }



        // GET PRODUCT BY ID:-
        [HttpGet]
        [Route("GetProductBy_ID")]
        public IActionResult GetProductByID(int Product_ID)
        {
            var product = queryService.GetProductById(Product_ID);
            if (product != null)
            {
                return Ok(new { success = true, message = "Product fetched Successfully", data = product });
            }
            else
            {
                return NotFound(new { success = false, message = "Unable To fetch Product", data = product });
            }
        }



        // UPDATE A PRODUCT:-
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(int Product_ID, CommandModel model)
        {
            var product = commandService.UpdateProduct(Product_ID, model);
            if (product != null)
            {
                return Ok(new { success = true, message = "Products Updated Successfully", data = product });
            }
            else
            {
                return NotFound(new { success = false, message = "Unable To Update Product", data = product });
            }
        }



        //DELETE A PRODUCT:-
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int Product_ID)
        {
            var product = commandService.DeleteProduct(Product_ID);
            if (product != null)
            {
                return Ok(new { success = true, message = "Products Deleted Successfully", data = product });
            }
            else
            {
                return BadRequest(new { success = false, message = "Unable To Delete Product", data = product });
            }
        }
    }
}
