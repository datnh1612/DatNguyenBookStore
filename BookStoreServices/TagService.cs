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
    public interface ITagService
    {
        Tag Add(Tag tag);

        void Update(Tag tag);

        void Delete(string id);

        IEnumerable<Tag> GetAll();

        Tag GetByID(string id);

        void SaveChanges();
    }
    public class TagService : ITagService
    {
        ITagRepository _tagRepository;
        IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tag Add(Tag tag)
        {
            return _tagRepository.Add(tag);
        }

        public void Delete(string id)
        {
            _tagRepository.Delete(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }

        public Tag GetByID(string id)
        {
            return _tagRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tag tag)
        {
            _tagRepository.Update(tag);
        }
    }
}
