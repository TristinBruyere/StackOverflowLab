using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackOverflowLab.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace StackOverflowLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger/*, MySqlConnection injectdb*/)
        {
            _logger = logger;
            //DB = injectdb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult login(string username)
        {
            DAL.CurrentUser = username;
            return Redirect("/");
        }

        public IActionResult logout()
        {
            DAL.CurrentUser = null;
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
