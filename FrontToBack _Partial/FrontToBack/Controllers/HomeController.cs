using FrontToBack.DataAccessLayer;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var sliderImage = _dbContext.SliderImages.ToList();
            var slider = _dbContext.Sliders.SingleOrDefault();
            var category = _dbContext.Categories.ToList();
            var product = _dbContext.Products.Include(x=>x.Category).Take(4).ToList();
            var aboutsection = _dbContext.AboutSections.SingleOrDefault();
            var aboutsectionimage = _dbContext.AboutSectionImages.SingleOrDefault();
            var aboutsectionlist = _dbContext.AboutSectionLists.ToList();
            var expertsection = _dbContext.ExpertSections.SingleOrDefault();
            var expertsectionlist = _dbContext.ExpertSectionLists.ToList();
            var blog = _dbContext.Blogs.SingleOrDefault();
            var bloglist = _dbContext.BlogLists.ToList();
            var slidersay = _dbContext.SliderSays.ToList();
            var subscribe = _dbContext.Subscribes.SingleOrDefault();
            var instagram = _dbContext.Instagrams.ToList();

            return View(new HomeViewModel { 
                SliderImage=sliderImage,
                Slider=slider,
                Categories=category,
                Products=product,
                AboutSections=aboutsection,
                AboutSectionImages=aboutsectionimage,
                AboutSectionLists=aboutsectionlist,
                ExpertSections =expertsection,
                ExpertSectionLists=expertsectionlist,
                Blogs=blog,
                BlogLists=bloglist,
                SliderSays=slidersay,
                Subscribes=subscribe,
                Instagrams=instagram
            });
        }
    }
}
