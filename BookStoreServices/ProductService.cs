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
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        void Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);

        Product GetByID(int id);

        IEnumerable<Product> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<Product> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: select all Product by tag and paging it.
            return _productRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Product GetByID(int id)
        {
            return _productRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
