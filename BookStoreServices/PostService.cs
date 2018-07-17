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
    public interface IPostService
    {
        Post Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        Post GetByID(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository,IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public Post Add(Post post)
        {
            return _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" } );
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow)
        {
            //TODO: select all post by tag and paging it.
            return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetByID(int id)
        {
            return _postRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
