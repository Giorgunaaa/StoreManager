using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;

namespace StoreManager.Services;

public sealed class CategoryCommandService : ICategoryCommandService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryCommandService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public int Insert(Category entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _unitOfWork.CategoryRepository.Insert(entity);
        _unitOfWork.SaveChanges();

        return entity.Id;
    }

    public void Update(Category entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        _unitOfWork.CategoryRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(Category entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        entity.IsDeleted = true;
        _unitOfWork.CategoryRepository.Update(entity);
        _unitOfWork.SaveChanges();
    }
}
