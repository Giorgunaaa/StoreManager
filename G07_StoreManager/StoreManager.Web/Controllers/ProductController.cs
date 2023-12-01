using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Web.Models;

namespace StoreManager.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductQueryService _productQueryService;
    private readonly IProductCommandService _productCommandService;
    private readonly IMapper _mapper;

    public ProductController(IProductQueryService productQueryService, IProductCommandService productCommandService)
    {
        _productQueryService = productQueryService;
        _productCommandService = productCommandService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductModel>().ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public IActionResult Index()
    {
        var products = _mapper.Map<IEnumerable<ProductModel>>(_productQueryService.Search(""));

        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _mapper.Map<ProductModel>(_productQueryService.Set(p => p.Id == id).SingleOrDefault());
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(ProductModel model)
    {
        if (ModelState.IsValid)
        {
            _productCommandService.Update(_mapper.Map<Product>(model));

            return RedirectToAction("Details", new { id = model.Id });
        }

        return View(model);
    }
}
