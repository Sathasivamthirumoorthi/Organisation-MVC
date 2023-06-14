using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Organization.Models;
using System.Diagnostics;

namespace Organization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly OrganisationContext _context;


        public HomeController(ILogger<HomeController> logger, OrganisationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployeeCountsByProduct()
        {
            var products = _context.Product.Include(p => p.Employees).ToList();

            List<int> employeeCount = new List<int>();

            var employeeCountsByProduct = products.Select(p => new
            {
                ProductName = p.ProductName,
                EmployeeCount = p.Employees.Count
            }).ToList();

            foreach(var product in employeeCountsByProduct)
            {
                employeeCount.Add(product.EmployeeCount);
            }

            return Json(employeeCount);
        }

        public IActionResult Index()
        {
            var products = _context.Product.ToList();

            var Employees = _context.Product.Include(p => p.Employees).ToList();

            List<int> employeeCount = new List<int>();

            int[] RevenueValues = new int[products.Count()];

            string[] Productnames = new string[products.Count()];

            var employeeCountsByProduct = Employees.Select(p => new
            {
                ProductName = p.ProductName,
                EmployeeCount = p.Employees.Count
            }).ToList();

            foreach (var product in employeeCountsByProduct)
            {
                employeeCount.Add(product.EmployeeCount);
            }
            

            for (int i = 0; i < products.Count(); i++)
            {
                RevenueValues[i] = products[i].ProductRevenue;
            }

            for (int i = 0; i < products.Count(); i++)
            {
                Productnames[i] = products[i].ProductName;
            }

            var viewModel = new DashboardViewModel
            {
                TotalCustomers = _context.Customer.Count(),
                TotalEmployees = _context.Employee.Count(),
                TotalDepartments = _context.Department.Count(),
                TotalProducts = _context.Product.Count(),
                TotalRevenues = RevenueValues,
                Products = Productnames,
                TotalProductEmployeeCount = employeeCount.ToArray(),

                
            };

            return View(viewModel);

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