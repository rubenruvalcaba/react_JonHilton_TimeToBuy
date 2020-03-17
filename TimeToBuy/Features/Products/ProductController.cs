using Microsoft.AspNetCore.Mvc;

namespace TimeToBuy.Features
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult List()
        {
            ProductListModel model = _productService.GetProductList();
            return Ok(model);
        }
        
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var model = _productService.GetProductDetails(id);
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound($"Product with {id} not found");
            }            
        }
        
    }
}