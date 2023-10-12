﻿using StoreManager.DTO;
using System.Collections.Generic;

namespace StoreManager.Facade.Interfaces.Services;

public interface ICustomerQueryService : IQueryService<Customer>
{
    IEnumerable<Customer> Search(string text);
}
