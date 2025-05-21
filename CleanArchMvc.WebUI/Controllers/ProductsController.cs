using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductService productAppService,
            ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _productService = productAppService;
            _categoryService = categoryService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            ViewBag.totalPrice = 0;
            ViewBag.totalAtivos = 0;
            ViewBag.balanco = 0;
            await TotalDespesas();
            return View(products);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            await TotalDespesas();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(productDto);
                await TotalDespesas();
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) return NotFound();
            var productDto = await _productService.GetById(id);

            if (productDto == null) return NotFound();

            var categories = await _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productDto.CategoryId);

            return View(productDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var productDto = await _productService.GetById(id);

            if (productDto == null) return NotFound();

            return View(productDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Remove(id);
            await TotalDespesas();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            var productDto = await _productService.GetById(id);

            if (productDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(productDto);
        }

       public async Task TotalDespesas()
        {
            var products = await _productService.GetProducts();
          
            foreach (var item in products)
            {
                if (item.CategoryId == 5)
                {
                    ViewBag.totalPrice += item.Price;
                }

                if (item.CategoryId == 4)
                {
                    ViewBag.totalAtivos += item.Price;    
                }
            }
        }


    }
}