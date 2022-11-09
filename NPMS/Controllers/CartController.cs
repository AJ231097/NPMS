﻿using Microsoft.AspNetCore.Authorization;
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
            return View();
        }

        public Passes GetPassById(int Id)
        {
            return _context.Passes.SingleOrDefault(p => p.Id == Id);
        }


        [Authorize]
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

        //public async Task<IActionResult> Index()
        //{
        //    var cart = SessionHelper.GetObjectFromJson<List<Passes>>(HttpContext.Session, "cart");
        //    ViewBag.cart = cart;
        //    ViewBag.total = cart.Sum(item => item.PassPrice);
        //    return View("AddedToCart");
        //}

        //private int isExist(int id)
        //{
        //    List<Passes> cart = SessionHelper.GetObjectFromJson<List<Passes>>(HttpContext.Session, "cart");
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        if (cart[i].Id.Equals(id))
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}
        //public IActionResult Buy(int id)
        //{
        //    Passes passes = new Passes();
        //    if (SessionHelper.GetObjectFromJson<List<Passes>>(HttpContext.Session, "cart") == null)
        //    {
        //        List<Passes> cart = new List<Passes>();
        //        cart.Add(new Passes { Id = id });
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

        //    }
        //    else
        //    {
        //        List<Passes> cart = SessionHelper.GetObjectFromJson<List<Passes>>(HttpContext.Session, "cart");
        //        int index = isExist(id);
        //        cart.Add(new Passes { Id = id });
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //    }
        //    return RedirectToAction("Index");

        //}

        //public IActionResult Remove(int id)
        //{
        //    List<Passes> cart = SessionHelper.GetObjectFromJson<List<Passes>>(HttpContext.Session, "cart");
        //    int index = isExist(id);
        //    cart.RemoveAt(index);
        //    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //    return RedirectToAction("Index");

        //}
    }
}
