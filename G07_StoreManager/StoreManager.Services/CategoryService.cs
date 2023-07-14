using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Repositories;
using StoreManager.Facade.Interfaces.Services;
using System.Linq.Expressions;

namespace StoreManager.Services
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

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

        public Category Get(params object[] id) => _unitOfWork.CategoryRepository.Set().Single(x => x.Id == Convert.ToInt32(id) && !x.IsDeleted);

        public IEnumerable<Category> Set(Expression<Func<Category, bool>> predicate) => _unitOfWork.CategoryRepository.Set(predicate);

        public IEnumerable<Category> Set() => _unitOfWork.CategoryRepository.Set();
    }
}
