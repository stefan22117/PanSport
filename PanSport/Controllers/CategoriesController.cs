using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Controllers
{
    public class CategoriesController : Controller
    {
        PanSportDbContext context { get; set; }
        public CategoriesController(PanSportDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await context.Categories.ToListAsync();
            return View(categories);
        }
    }
}
