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
    public interface ISupportOnlineService
    {
        SupportOnline Add(SupportOnline supportOnline);

        void Update(SupportOnline supportOnline);

        void Delete(int id);

        IEnumerable<SupportOnline> GetAll();

        SupportOnline GetByID(int id);

        void SaveChanges();
    }
    public class SupportOnlineService : ISupportOnlineService
    {
        ISupportOnlineRepository _supportOnlineRepository;
        IUnitOfWork _unitOfWork;

        public SupportOnlineService(ISupportOnlineRepository supportOnlineRepository, IUnitOfWork unitOfWork)
        {
            this._supportOnlineRepository = supportOnlineRepository;
            this._unitOfWork = unitOfWork;
        }

        public SupportOnline Add(SupportOnline supportOnline)
        {
            return _supportOnlineRepository.Add(supportOnline);
        }

        public void Delete(int id)
        {
            _supportOnlineRepository.Delete(id);
        }

        public IEnumerable<SupportOnline> GetAll()
        {
            return _supportOnlineRepository.GetAll();
        }

        public SupportOnline GetByID(int id)
        {
            return _supportOnlineRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SupportOnline supportOnline)
        {
            _supportOnlineRepository.Update(supportOnline);
        }
    }
}
