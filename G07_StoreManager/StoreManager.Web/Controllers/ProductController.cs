using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Web.Models;
using System.Collections.Generic;

namespace StoreManager.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductQueryService _productQueryService;
    private readonly IMapper _mapper;

    public ProductController(IProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;
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
}
