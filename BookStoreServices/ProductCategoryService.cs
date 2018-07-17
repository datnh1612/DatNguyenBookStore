using BookStoreData.Infrastructure;
using BookStoreData.Repositories;
using BookStoreModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreServices
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        void Update(ProductCategory productCategory);

        void Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow);

        ProductCategory GetByID(int id);

        IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryRepository.Add(productCategory);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: select all ProductCategory by tag and paging it.
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public ProductCategory GetByID(int id)
        {
            return _productCategoryRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
        }
    }
}
