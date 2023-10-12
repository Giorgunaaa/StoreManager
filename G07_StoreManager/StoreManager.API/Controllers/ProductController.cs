﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;

namespace StoreManager.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductQueryService _productQueryService;
    private readonly IProductCommandService _productCommandService;
    private readonly IMapper _mapper;

    public ProductController(IProductQueryService productQueryService, IProductCommandService productCommandService, IMapper mapper)
    {
        _productQueryService = productQueryService;
        _productCommandService = productCommandService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{id}")]
    public ProductModel Get(int id) => _mapper.Map<ProductModel>(_productQueryService.Get(id));

    [HttpGet]
    [Route("search/{text}")]
    public IEnumerable<ProductModel> Search(string text) => _productQueryService
    .Search(text)
    .Select(x => _mapper.Map<ProductModel>(x));

    [HttpPost]
    public int Insert(ProductModel model) => _productCommandService.Insert(_mapper.Map<Customer>(model));

    [HttpPut]
    [Route("{id}")]
    public void Update(int id, ProductModel model)
    {
        var product = _mapper.Map<Customer>(model);
        product.Id = id;
        _productCommandService.Update(product);
    }

    [HttpDelete]
    [Route("{id}")]
    public void Delete(int id) => _productCommandService.Delete(id);
}