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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllPaging(int page, int pageSize, out int totalRow);

        PostCategory GetByID(int id);

        IEnumerable<PostCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: select all PostCategory by tag and paging it.
            return _postCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<PostCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public PostCategory GetByID(int id)
        {
            return _postCategoryRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}
