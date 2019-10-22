using Forum.Data;
using Forum.Models;
using Forum.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class SectionController : Controller
    {
        ModelContext _context;
        UserManager<User> _userManager;
        public SectionController(ModelContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sections.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Section section)
        {
            _context.Sections.Add(section);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string name)
        {
            if (name != null)
            {
                Section section = await _context.Sections.FirstOrDefaultAsync(p => p.Name == name);
                if (section != null)
                    return View(section);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Section phone)
        {
            _context.Sections.Update(phone);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string name)
        {
            if (name != null)
            {
                Section section = await _context.Sections.FirstOrDefaultAsync(p => p.Name == name);
                if (section != null)
                    return View(section);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string name)
        {
            if (name != null)
            {
                Section section = await _context.Sections.FirstOrDefaultAsync(p => p.Name == name);
                if (section != null)
                {
                    _context.Sections.Remove(section);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
