using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;
using Microsoft.AspNetCore.Identity;
using Forum.Data;
using Forum.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        ModelContext _context;
        UserManager<User> _userManager;
        public HomeController(ModelContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                Sections = _context.Sections
                    .Include(c => c.Topics)
                    .ToList(),
                Topics = _context.Topics.ToList(),
                Messages = _context.Messages.ToList()
            };
            return View(indexViewModel);
        }

        public IActionResult Section(string Name)
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                Sections = _context.Sections
                    .Where(b => b.Name == Name)
                    .Include(c => c.Topics)
                    .ToList()
            };
            return View(indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
