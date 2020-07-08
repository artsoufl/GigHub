using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gighub.Models;
using GigHub.ViewModels;
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

        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}
