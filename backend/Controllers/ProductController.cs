using LanchoneteAPI.DataContext;
using LanchoneteAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("/produtos")]
        public IActionResult PostProduct([FromServices] ApiDataContext context,
                                         [FromBody] Product product
                                        )
        {
            context.Products.Add(product);
            context.SaveChanges();

            return Ok(product);
        }
    }
}
