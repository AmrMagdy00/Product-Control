using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Control.Dto;
using Product_Control.Mappers;
using Product_Control.Models;
using Product_Control.Services;

namespace Product_Control.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {

        private readonly IProductsService _productsService;

        public ProductController(IProductsService ProductsService  )
        {
            _productsService = ProductsService;
        }



        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var ProductDto = await _productsService.FindAsync(id);
            if (ProductDto == null)   
            {
                return NotFound();
            }
            return View("~/Views/Products/Edit.cshtml", ProductDto);
        }

        [HttpPost("ConfirmedEdit")]
        public async Task<IActionResult> ConfirmedEdit(ProductDto Dto)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Products/Edit.cshtml",Dto);
            }

            try
            {
                var Edited = await _productsService.UpdateAsync(Dto);

                if (Edited)
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

            return BadRequest();

        }
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var ProductDto = await _productsService.FindAsync(id);
            if (ProductDto == null)
            {
                return NotFound();
            }

            return View("~/Views/Products/Delete.cshtml", ProductDto);
        }

        [HttpPost("ConfirmDelete")]
        public async Task<IActionResult> ConfirmedDelete(ProductDto Dto)
        {
            var Deleted = await _productsService.Delete(Dto);

            if (!Deleted)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Add()
        {

            return View("~/Views/Products/Add.cshtml");
        }

        [HttpPost("AddConfirmed")]
        public async Task<IActionResult> AddConfirmed(ProductDto Dto)
         {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Products/Add.cshtml", Dto);
            }
            await _productsService.AddAsync(Dto);
            return RedirectToAction("Index", "Home");

        }

    }
}

