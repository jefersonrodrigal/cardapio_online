using LanchoneteAPI.DataContext;
using LanchoneteAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteAPI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("/pedidos")]
        public IActionResult PostOrder([FromServices] ApiDataContext context,
                                         [FromBody] Order order
                                        )
        {
            var numOrder = context.Orders.FirstOrDefault(x => x.NumberOrder >= 1);
            if (numOrder == null)
            {
                order.NumberOrder = 1;
            }
            else
            {
                var max = context.Orders.Max(x => x.NumberOrder);
                order.NumberOrder = max + 1;
            }

            context.Orders.Add(order);
            context.SaveChanges();

            return Ok(order);
        }
    }
}
