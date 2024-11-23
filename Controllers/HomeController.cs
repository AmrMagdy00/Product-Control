using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Product_Control.Mappers;
using Product_Control.Models;
using Product_Control.Models.ViewModel;
using Product_Control.Services;

namespace Product_Control.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsService _prouctService;

        public HomeController(ProductsService ProuctService)
        {
            _prouctService = ProuctService;
        }

        public async Task<IActionResult> Index(string Category = null, string SortBy = "desc", string Name = null, int page = 1, int pageSize = 6)
        {
            var Query = _prouctService.GetAllQuerable();

            // Filter by Category
            if (!string.IsNullOrEmpty(Category) && Category != "All")
            {
                Query = Query.Where(s => s.Category == Category);
            }

            // Filter by Name
            if (!string.IsNullOrEmpty(Name))
            {
                Query = Query.Where(s => s.Title.Contains(Name)); // Filtering by product name
            }

            // Sort the results
            if (SortBy == "asc")
            {
                Query = Query.OrderBy(s => s.Price); // Sorting by price ascending
            }
            else if (SortBy == "desc")
            {
                Query = Query.OrderByDescending(s => s.Price); // Sorting by price descending
            }
            else if (SortBy == "name")
            {
                Query = Query.OrderBy(s => s.Title); // Sorting by name
            }

            var totalProducts = Query.Count();
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            var products = Query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var ProductsDto = products.Select(s => s.ToDto()).ToList();

            var paginationData = new PaginationViewModel
            {
                Products = ProductsDto,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize 
            };

            return View("HomePage", paginationData);
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
