using EFTest02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System;
using System.Reflection.Metadata;
using EfTest02.Models;
using System.Security.Cryptography.Xml;

namespace EFTest02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using var db = new TodoAppContext();

            db.SaveChanges();
            return View(db.Groups.ToList());
        }
        public IActionResult AddGroup()
        {
            //HttpContext.Session.Clear();
            return View("AddGroup");
        }
        [HttpPost]
        public IActionResult AddGroup(Group group)
        {
            using var db = new TodoAppContext();
            db.Groups.Add(
                new Group()
                {
                    Title = group.Title.ToString(),
                    UserId = 1
                }
            ) ;
            db.SaveChanges();
            return Content("Eklendi");
        }

        public IActionResult AddUser()
        {
            using var db = new TodoAppContext();
            db.Users.Add(
                new User()
                {
                    Name="Ahmet",
                    LastName = "ZEYTUN",
                    Email = "zeytunahmet154@gmail.com",
                    GroupId = 1,
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    DueDate = DateTime.Now,
                    IsActive = true,
                    Password = "123456Aa.",
                    CarId = 1
                }
            );
            db.SaveChanges();
            return Content("Eklendi");
        }

        public IActionResult AddCars()
        {
            using var db = new TodoAppContext();
            db.Cars.Add(
                new Car()
                {
                    Name = "Jaguar",
                    Slug = "Jaguar_aracID",
                    TodoId = 1,
                    IsActive = false,
                    Detail = "Cıncık Gibi",
                    Image = "yok.png",
                    UserId = 1,
                    WhatCityCarIn = "Hatay",
                    Thumb = "Simdilikyok.png",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                }
            );
            db.SaveChanges();
            return Content("Eklendi");
        }

        public IActionResult AddTodos()
        {
            using var db = new TodoAppContext();
            db.Todos.Add(
                new TodoModel()
                {
                    Title = "Arabanın bakımmı yapılacak",
                    CarId = 1,
                    Content = "@modelCars.Id numaralı aracın bakımı @Todomodel.dueDate tarihine kadar yapılmalıdır",
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    DueDate = DateTime.Now,
                    Completed = false
                }
            );
            db.SaveChanges();
            return Content("Eklendi");
        }
        public IActionResult AddSubtask()
        {
            using var db = new TodoAppContext();
            db.Substask.Add(
                new Subtask()
                {
                    Title = "yapılacak",
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    Completed = false,
                    TodoId = 1
                }
            ); db.Substask.Add(
                new Subtask()
                {
                    Title = "başka bu",
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    Completed = false,
                    TodoId = 1
                }
            );
            db.SaveChanges();
            return Content("Eklendi");
        }


        public IActionResult Privacy()
        {
            //using var db = new TodoAppContext();
            //context.Configuration.LazyLoadingEnabled = false;
            //var Kisiler = context.Person.Include("PersonPhone").Take((10)).ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}