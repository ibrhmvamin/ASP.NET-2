using ASP.NET_2.Entities;
using ASP.NET_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ASP.NET_2.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new()
       {
            new() {
                Id = 1,
                Name = "Wheels",
                Description = "For Offroad cars",
                Price = 100,
                Discount = 10
            },
            new() {
                Id = 2,
                Name = "Burger",
                Description = "Perfect Burger",
                Price = 9.99,
                Discount = 1.35
            },
            new() {
                Id = 3,
                Name = "Ice cream",
                Description = "With milk and fruits",
                Price = 5.75,
                Discount = 0.95
            },
            new() {
                Id = 4,
                Name = "Vape",
                Description = "Mango & Watermelon",
                Price = 30,
                Discount = 4.50
            },
            new() {
                Id = 5,
                Name = "Fish",
                Description = "Good fish",
                Price = 20,
                Discount = 2.22
            }
        };
        public IActionResult Index()
        {
            var vm = new ProductViewModel()
            {
                Products = products
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel()
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Product.Id = products.Max((p)=>p.Id) + 1;
                products.Add(vm.Product);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = products.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                NotFound();
            }
            var vm = new ProductAddViewModel
            {
                Product = item
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductAddViewModel vm)
        {
            if (ModelState.IsValid) {
                var updatedp = products.FirstOrDefault(p => p.Id == vm.Product.Id);
                if (updatedp != null)
                {
                    updatedp.Name = vm.Product.Name;
                    updatedp.Description = vm.Product.Description;
                    updatedp.Price = vm.Product.Price;
                    updatedp.Discount = vm.Product.Discount;
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = products.FirstOrDefault((p)=>p.Id==id);
            if (item != null)
            {
                products.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}
