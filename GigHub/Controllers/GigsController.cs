using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gighub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//  https://getbootstrap.com/docs/3.4/css/#forms for the html code
namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        //[Authorize]
        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var artistId = "123";
                //User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == artistId);
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var gig = new Gig
            {
                Artist = artist,
                Genre = genre,
                DateTime = viewModel.DateTime,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
