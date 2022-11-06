using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPMS.Helpers;
using NPMS.Models;

namespace NPMS.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly NPMSContext context;
        public CheckoutController(UserManager<IdentityUser> userManager, NPMSContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Success()
        {
            return View();
        }
        public async Task<string> GetCurrentUserId()
        {
            IdentityUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public async Task<IActionResult> Checkout()
        {

            if (SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "cart") == null)
            {
                return RedirectToAction("Cart", "Index");
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "cart");
                Cart finalcart = new Cart();
                finalcart.OrderId = Guid.NewGuid();
                finalcart.TotalAmount = cart.Sum(item => item.PassPrice);
                finalcart.UserId = await GetCurrentUserId();
                context.Carts.Add(finalcart);
                await context.SaveChangesAsync();

            }
            return RedirectToAction("Success");

        }
    }
}
