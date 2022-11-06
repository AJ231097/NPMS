using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NPMS.Helpers;
using NPMS.Models;

namespace NPMS.Controllers
{
    public class CartController : Controller
    {
        private readonly NPMSContext _context;

        public CartController(NPMSContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Passes.ToListAsync());
        }
        public IActionResult AddedToCart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.PassPrice);
            //ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }

        public Passes GetPassById(int Id)
        {
            return _context.Passes.SingleOrDefault(p => p.Id == Id);
        }



        [HttpPost("{Id}")]
        public async Task<IActionResult> AddOrder(int Id)
        {
            var pass = GetPassById(Id);
            if (SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "cart") == null)
            {
                List<OrderDetails> cart = new List<OrderDetails>();
                cart.Add(new OrderDetails
                {
                    Id = Id,
                    PassName = pass.PassName,
                    PassPrice = pass.PassPrice
                });

                await _context.SaveChangesAsync();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);



            }

            else
            {
                List<OrderDetails> cart = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "cart");
                cart.Add(new OrderDetails
                {
                    Id = Id,
                    PassName = pass.PassName,
                    PassPrice = pass.PassPrice

                });

                await _context.SaveChangesAsync();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("AddedToCart");
        }




        [HttpPost]
        public IActionResult Remove(int Id)
        {
            List<OrderDetails> cart = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "cart");
            int index = isExist(Id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("FinalCart");
        }


        private int isExist(int Id)
        {
            List<OrderDetails> cart = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(Id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
