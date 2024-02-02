using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            //Добавим создание нового пользователя
            //var newUser = new User()
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Andrey",
            //    LastName = "Petrov",
            //    JoinDate = DateTime.Now
            //};

            //// Добавим в базу
            //await _repo.AddUser(newUser);

            //// Выведем результат
            //Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

            return View();
        }

        //public async Task<IActionResult> Authors()
        //{
        //    var authors = await _repo.GetUsers();

        //    Console.WriteLine("See all blog authors:");
        //    foreach (var author in authors)
        //        //Console.WriteLine($"Author name {author.FirstName}, joined {author.JoinDate}");
        //    Console.WriteLine($"Author with id {author.Id}, named {author.FirstName}, joined {author.JoinDate}");

        //    return View();
        //}


        public async Task<IActionResult> Authors()
        {
            //Console.WriteLine("See all blog authors:");
            //var authors = await _repo.GetUsers();
            //foreach (var author in authors)
            //    //Console.WriteLine($"Author name {author.FirstName}, joined {author.JoinDate}");
            //    Console.WriteLine($"Author with id {author.Id}, named {author.FirstName}, joined {author.JoinDate}");
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return base.View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
