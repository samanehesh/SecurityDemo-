﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecurityDemo.Data;
using SecurityDemo.Models;
using SecurityDemo.Repositories;
using System.Diagnostics;

namespace SecurityDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;



        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, UserManager<IdentityUser> userManager,ApplicationDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _context = context;
        }

        [Authorize]
        public IActionResult InjectionDemo(string message = "")
        {
            SqlDbRepository sqlDbRepository = new SqlDbRepository(_configuration,_context);
            List<string> cities = sqlDbRepository.GetCities(out string returnMessage);

            ViewData["Message"] = $"{message}{returnMessage}";

            return View(cities);
        }

        [Authorize]
        public IActionResult BuildingsInCity(string cityId = "")
        {
            if (string.IsNullOrEmpty(cityId))
            {
                return RedirectToAction("InjectionDemo", new { message = "Please select a city." });
            }

            SqlDbRepository sqlDbRepository = new SqlDbRepository(_configuration,_context);

            string cityName = sqlDbRepository.GetCityName(cityId);
            List<string> cityBuildings = new List<string> { cityName };
            List<string> buildings = sqlDbRepository.GetBuildingsInCity(cityId);

            if (buildings.Count() > 0)
            {
                cityBuildings.AddRange(buildings);
            }
            else
            {
                return RedirectToAction("InjectionDemo",
                                    new { message = $"No buildings in {cityName}." });
            }

            return View(cityBuildings);
        }

        public async Task<IActionResult> AdminArea()
        {
            var roles = new List<string>();
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    roles = (List<string>)await _userManager.GetRolesAsync(user);
                }
            }

            if (roles.Contains("Admin"))
            {
                SqlDbRepository sqlDbRepository = new SqlDbRepository(_configuration, _context);
                List<string> registeredUsers = sqlDbRepository.GetRegisteredUsers();

                return View(registeredUsers);
            }
            return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
        }


        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Products()
        {
            SqlDbRepository sqlDbRepository = new SqlDbRepository(_configuration,_context);
            List<ProductVM> products = sqlDbRepository.GetProducts();

            return View(products);
        }

        [Authorize]
        public ActionResult DisplayProduct(string prodID)
        {
            SqlDbRepository sqlDbRepository = new SqlDbRepository(_configuration, _context);
            ProductVM product = sqlDbRepository.GetProduct(prodID);

            return View(product);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}