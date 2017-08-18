using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Book.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Book.Controllers
{
    public class AuctionsController : Controller
    {
        private AuctionContext _context;
        
            public AuctionsController(AuctionContext context)
            {
                _context = context;
            }
        [HttpGet]
        [Route("Auctions")]
        public IActionResult Index()
        {
            return View("Index");
            // if (HttpContext.Session.GetInt32("UserId") != null)
            // {
            //   ViewBag.AllAuctions = _context.Auctions
            //     .Include(auction => auction.User)
            //     .OrderByDescending(auction => auction.CreatedAt)
            //     .ToList();
            //   int? logId = HttpContext.Session.GetInt32("UserId");
            //   ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
            //   return View();
            // }
            // else
            // {
            //   return RedirectToAction("Index", "Register");
            // }
        }
        [HttpPost]
        [Route("PostAuction")]
        public IActionResult PostAuction(Auction auction)
        {
            Console.WriteLine( "Auction ID is :");
          if (HttpContext.Session.GetInt32("UserId") != null)
          {
            Auction NewAuction = new Auction{
            //   AmountBid = (double)AmountBid,
              Context = auction.Context,
              AuctionName = auction.AuctionName,
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
              UserId = (int)HttpContext.Session.GetInt32("UserId")
            };
            _context.Auctions.Add(NewAuction);
            _context.SaveChanges();
            ViewBag.AllAuctions = _context.Auctions
              .Include(post => post.User)
              .OrderByDescending(post => post.CreatedAt)
              .ToList();
            int? logId = HttpContext.Session.GetInt32("UserId");
            ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == logId);
            ModelState.Clear();
            return RedirectToAction("Index");
          }
          else
          {
            return RedirectToAction("Index", "Register");
          }
        }
    }
}

