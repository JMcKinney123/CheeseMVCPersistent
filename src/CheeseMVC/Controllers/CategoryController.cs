﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.ViewModels;
using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            var category = context.Categories.ToList();

            return View(category);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();

            return View(addCategoryViewModel);

        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {

            if (ModelState.IsValid)

            {

                CheeseCategory newCategory = new CheeseCategory

                {

                    Name = addCategoryViewModel.Name

                };

                context.Categories.Add(newCategory);

                context.SaveChanges();

                return Redirect("/Category");

            }

            return View(addCategoryViewModel);
        }

        

       

    }
}