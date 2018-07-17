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
    public interface IPostTagService
    {
        PostTag Add(PostTag postTag);

        void Update(PostTag postTag);

        void Delete(int id);

        IEnumerable<PostTag> GetAll();

        PostTag GetByID(int id);

        void SaveChanges();
    }
    public class PostTagService : IPostTagService
    {
        IPostTagRepository _postTagRepository;
        IUnitOfWork _unitOfWork;

        public PostTagService(IPostTagRepository postTagRepository, IUnitOfWork unitOfWork)
        {
            this._postTagRepository = postTagRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostTag Add(PostTag postTag)
        {
            return _postTagRepository.Add(postTag);
        }

        public void Delete(int id)
        {
            _postTagRepository.Delete(id);
        }

        public IEnumerable<PostTag> GetAll()
        {
            return _postTagRepository.GetAll();
        }

        public PostTag GetByID(int id)
        {
            return _postTagRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostTag postTag)
        {
            _postTagRepository.Update(postTag);
        }
    }
}
