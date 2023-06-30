﻿using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;

namespace StoreManager.Repositories;

public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(StoreManagerDbContext context) : base(context) { }
}