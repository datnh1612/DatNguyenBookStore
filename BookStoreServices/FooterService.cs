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
    public interface IFooterService
    {
        Footer Add(Footer footer);

        void Update(Footer footer);

        void Delete(int id);

        IEnumerable<Footer> GetAll();

        Footer GetByID(int id);

        void SaveChanges();
    }
    public class FooterService : IFooterService
    {
        IFooterRepository _footerRepository;
        IUnitOfWork _unitOfWork;

        public FooterService(IFooterRepository footerRepository,IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Footer Add(Footer footer)
        {
            return _footerRepository.Add(footer);
        }

        public void Delete(int id)
        {
            _footerRepository.Delete(id);
        }

        public IEnumerable<Footer> GetAll()
        {
            return _footerRepository.GetAll();
        }

        public Footer GetByID(int id)
        {
            return _footerRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Footer footer)
        {
            _footerRepository.Update(footer);
        }
    }
}
