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
    public interface IPageService
    {
        Page Add(Page page);

        void Update(Page page);

        void Delete(int id);

        IEnumerable<Page> GetAll();

        Page GetByID(int id);

        void SaveChanges();
    }
    public class PageService : IPageService
    {
        IPageRepository _pageRepository;
        IUnitOfWork _unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            this._pageRepository = pageRepository;
            this._unitOfWork = unitOfWork;
        }

        public Page Add(Page page)
        {
            return _pageRepository.Add(page);
        }

        public void Delete(int id)
        {
            _pageRepository.Delete(id);
        }

        public IEnumerable<Page> GetAll()
        {
            return _pageRepository.GetAll();
        }

        public Page GetByID(int id)
        {
            return _pageRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Page page)
        {
            _pageRepository.Update(page);
        }
    }
}
