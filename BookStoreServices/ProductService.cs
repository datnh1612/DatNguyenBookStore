using BookStoreCommon;
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

        IEnumerable<Product> GetAll(string keyword);

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);

        Product GetByID(int id);

        IEnumerable<Product> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        ITagRepository _tagRepository;
        IProductTagRepository _productTagRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork,
            IProductTagRepository productTagRepository, ITagRepository tagRepository)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
        }

        public Product Add(Product product)
        {
            var productAdd = _productRepository.Add(product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for(var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstant.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            return productAdd;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword) || x.Content.Contains(keyword));
            }
            return _productRepository.GetAll();
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
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstant.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(x => x.ProductID == product.ID);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
        }
    }
}
