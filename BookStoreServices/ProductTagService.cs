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
    public interface IProductTagService
    {
        ProductTag Add(ProductTag productTag);

        void Update(ProductTag productTag);

        void Delete(int id);

        IEnumerable<ProductTag> GetAll();

        ProductTag GetByID(int id);

        void SaveChanges();
    }
    public class ProductTagService : IProductTagService
    {
        IProductTagRepository _productTagRepository;
        IUnitOfWork _unitOfWork;

        public ProductTagService(IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            this._productTagRepository = productTagRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductTag Add(ProductTag productTag)
        {
            return _productTagRepository.Add(productTag);
        }

        public void Delete(int id)
        {
            _productTagRepository.Delete(id);
        }

        public IEnumerable<ProductTag> GetAll()
        {
            return _productTagRepository.GetAll();
        }

        public ProductTag GetByID(int id)
        {
            return _productTagRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductTag productTag)
        {
            _productTagRepository.Update(productTag);
        }
    }
}
