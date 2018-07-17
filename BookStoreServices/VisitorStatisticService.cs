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
    public interface IVisitorStatisticService
    {
        VisitorStatistic Add(VisitorStatistic visitorStatistic);

        void Update(VisitorStatistic visitorStatistic);

        void Delete(int id);

        IEnumerable<VisitorStatistic> GetAll();

        VisitorStatistic GetByID(int id);

        void SaveChanges();
    }
    public class VisitorStatisticService : IVisitorStatisticService
    {
        IVisitorStatisticRepository _visitorStatisticRepository;
        IUnitOfWork _unitOfWork;

        public VisitorStatisticService(IVisitorStatisticRepository visitorStatisticRepository, IUnitOfWork unitOfWork)
        {
            this._visitorStatisticRepository = visitorStatisticRepository;
            this._unitOfWork = unitOfWork;
        }

        public VisitorStatistic Add(VisitorStatistic visitorStatistic)
        {
            return _visitorStatisticRepository.Add(visitorStatistic);
        }

        public void Delete(int id)
        {
            _visitorStatisticRepository.Delete(id);
        }

        public IEnumerable<VisitorStatistic> GetAll()
        {
            return _visitorStatisticRepository.GetAll();
        }

        public VisitorStatistic GetByID(int id)
        {
            return _visitorStatisticRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(VisitorStatistic visitorStatistic)
        {
            _visitorStatisticRepository.Update(visitorStatistic);
        }
    }
}
