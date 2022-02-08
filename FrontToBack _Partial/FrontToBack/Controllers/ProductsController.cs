using FrontToBack.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class ProductsController : Controller    
    {
        private readonly AppDbContext _dbContext;
        private readonly int _productsCount;
        public ProductsController(AppDbContext dbContext)
        {   
            _dbContext = dbContext;
            _productsCount = _dbContext.Products.Count();
        }
        public IActionResult Index()
        {
            ViewBag.ProductsCount = _productsCount;
            var products = _dbContext.Products.Include(x => x.Category).Take(4).ToList();
            return View(products);
        }

        public IActionResult Scroll(int skip)   
        {
            if (skip >= _productsCount)
            {
                return BadRequest();
            }
            var product = _dbContext.Products.Include(x => x.Category).Skip(skip).Take(4).ToList();

            return PartialView("_ProductPartial", product);
        }
    }
}
