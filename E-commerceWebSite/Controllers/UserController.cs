using Microsoft.AspNetCore.Mvc;
using E_commerceWebSite.Entities;
using E_commerceWebSite.Models;
using System.Linq;

namespace E_commerceWebSite.Controllers
{
    public class UserController : Controller
    {
        WebSiteContext webSiteContext = new WebSiteContext();
        public IActionResult products(int id, string type)
        {
            ViewData["type"] = type;
            ViewData["id"] = id;
            return View(webSiteContext.Products.ToList());
        }
        public IActionResult ShowProducts(int id, string type)
        {
            ViewData["type"] = type;
            ViewData["id"] = id;
            return View(webSiteContext.Products.ToList());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(User obj)
        {  
            if (obj.Type == "Client")
            {
                Client c = new Client();
                c.Name = obj.Name;
                c.Email = obj.Email;
                c.Password = obj.Password;
                if (ModelState.IsValid)
                {
                    webSiteContext.Users.Add(obj);
                    webSiteContext.Clients.Add(c);
                    webSiteContext.SaveChanges();
                    return RedirectToAction("products", new { id = obj.Id, Type = "Client" });
                }
                return View("Add", obj);
            }
            else
            {
                Seller s = new Seller();
                s.Name = obj.Name;
                s.Email = obj.Email;
                s.Password = obj.Password;
                if (ModelState.IsValid)
                {
                    webSiteContext.Users.Add(obj);
                    webSiteContext.Sellers.Add(s);
                    webSiteContext.SaveChanges();
                    return RedirectToAction("ShowProducts", new { id = obj.Id, Type = "Seller" });
                }
            }
            return View("Add", obj);
        }
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Enter(User obj)
        {
            if (obj.Type == "Client")
            {
                Client? c = webSiteContext.Clients.FirstOrDefault(x => x.Name == obj.Name);
                if (c == null)
                    return View("Enter", obj);
                obj = (User)c;
                if (c.Name.Equals(obj.Name) && c.Password.Equals(obj.Password))
                {
                    return RedirectToAction("products", new { id = obj.Id, Type = "Client" });
                }
                return View("Enter", obj);
            }
            else
            {
                Seller? s = webSiteContext.Sellers.FirstOrDefault(x => x.Name == obj.Name);
                if (s == null)
                    return View("Enter", obj);
                obj = (User)s;
                if (s.Name.Equals(obj.Name) && s.Password.Equals(obj.Password))
                {
                    return RedirectToAction("ShowProducts", new { id = obj.Id, Type = "Seller" });
                }
                return View("Enter", obj);
            }
        }
        public IActionResult Settings(int id)
        {
            Client c = webSiteContext.Clients.Find(id);
            User user = new User();
            if (c == null)
            {
                Seller s = webSiteContext.Sellers.Find(id);
                user = (User)s;
                user.Type = "Seller";
                return View(user);
            }
            user = (User)c;
            user.Type = "Client";
            return View(user);
        }
        [HttpPost]
        public IActionResult Saving(User newu, int id)
        {
            Client c = webSiteContext.Clients.FirstOrDefault(x => x.Id == id);
            if (c == null)
            {
                Seller s = webSiteContext.Sellers.FirstOrDefault(x => x.Id == id);
                newu.Type = "Seller";
                if (newu.Name != null && newu.Email != null && newu.Password != null)
                {
                    s.Name = newu.Name;
                    s.Email = newu.Email;
                    s.Password = newu.Password;
                    webSiteContext.SaveChanges();
                    return RedirectToAction("ShowProducts", new { id = newu.Id, type = newu.Type });
                }
                return View("Settings", newu);
            }
            newu.Type = "Client";
            if (newu.Name != null && newu.Email != null && newu.Password != null)
            {
                c.Name = newu.Name;
                c.Email = newu.Email;
                c.Password = newu.Password;
                webSiteContext.SaveChanges();
                return RedirectToAction("products", new { id = newu.Id, type = newu.Type });
            }
            return View("Settings", newu);
        }
        public IActionResult Details(int id)
        {
            return View(webSiteContext.Products.FirstOrDefault(x => x.Id == id));
        }
        public IActionResult Addproduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addproduct(int id)
        {
            User u = webSiteContext.Users.FirstOrDefault();
            Product p = webSiteContext.Products.FirstOrDefault(x => x.Id == id);
            Product p1 = new Product();
            p1.Id = p.Id;
            p1.Name = p.Name;
            p1.Quantity = 1;
            p1.Price = p.Price;
            p1.Image = p.Image;
            p1.SellerID = p.SellerID;
            //u.cart.Add(p1);
            p.Quantity--;
            if (p.Quantity == 0)
                webSiteContext.Products.Remove(p);
            webSiteContext.Users.Remove(u);
            webSiteContext.SaveChanges(); 
            return RedirectToAction("products");
        }
    } 
}
