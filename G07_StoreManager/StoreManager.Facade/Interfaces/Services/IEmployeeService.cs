﻿using StoreManager.DTO;

namespace StoreManager.Facade.Interfaces.Services;

public interface IEmployeeService : ICommandService<Employee>, IQueryService<Employee>
{

}
