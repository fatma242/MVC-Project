using E_commerceWebSite.Entities;
using E_commerceWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceWebSite.Controllers
{
    public class ProductController : Controller
    {
        WebSiteContext webSiteContext = new WebSiteContext();
        public IActionResult Index()
        {
            return View(webSiteContext.Products.ToList());
        }
        public IActionResult products()
        {
            return View(webSiteContext.Products.ToList());
        }
        public IActionResult Details(int id)
        {
            return View(webSiteContext.Products.FirstOrDefault(x => x.Id == id));
        }
        public IActionResult New()
        {
            List<Seller> sellers = webSiteContext.Sellers.ToList();
            ViewData["sellers"] = sellers;
            return View();
        }
        [HttpPost]
        public IActionResult New(Product p)
        {
            List<Seller> sellers = webSiteContext.Sellers.ToList();
            ViewData["sellers"] = sellers;
            if (ModelState.IsValid)
            {
                webSiteContext.Add(p);
                webSiteContext.SaveChanges();
                TempData["Success"] = "Product has been added successfully!";
                return RedirectToAction("Index");
            }
            return View("New", p);
        }
        public IActionResult Edit(int id)
        {
            List<Seller> sellers = webSiteContext.Sellers.ToList();
            ViewData["sellers"] = sellers;
            Product p = webSiteContext.Products.Find(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Save(Product newp, int Id)
        {
            Product oldp = webSiteContext.Products.Find(Id);
            List<Seller> sellers = webSiteContext.Sellers.ToList();
            ViewData["sellers"] = sellers;
            if (ModelState.IsValid)
            {
                oldp.Name = newp.Name;
                oldp.Quantity = newp.Quantity;
                oldp.Price = newp.Price;
                oldp.Image = newp.Image;
                oldp.SellerID = newp.SellerID;
                webSiteContext.SaveChanges();
                TempData["Success"] = "Product has been updated successfully!";
                return RedirectToAction("Index");
            }
            return View("Edit", newp);
        }
        public IActionResult Delete(int id)
        {
            return View(webSiteContext.Products.Find(id));
        }
        [HttpPost]
        public IActionResult Delete(Product p, int id)
        {
            Product pfind = webSiteContext.Products.Find(id);
            webSiteContext.Remove(pfind);
            webSiteContext.SaveChanges();
            TempData["Success"] = "Product has been deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
