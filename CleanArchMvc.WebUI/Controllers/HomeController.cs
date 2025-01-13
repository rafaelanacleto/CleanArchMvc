using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.WebUI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, IProductService productAppService,
            ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _logger = logger;
            _productService = productAppService;
            _categoryService = categoryService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            await TotalDespesas();
            return View(products);
        }

        [HttpGet]
        public async Task<JsonResult> GetInformacoesDespesas()
        {
            // Lógica para processar os dados recebidos
            // Retorna uma resposta (por exemplo, sucesso ou erro)
            var products = await _productService.GetProducts();
            await TotalDespesas();
            return Json(new { products });
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
