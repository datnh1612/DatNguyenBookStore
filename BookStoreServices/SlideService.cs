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
    public interface ISlideService
    {
        Slide Add(Slide slide);

        void Update(Slide slide);

        void Delete(int id);

        IEnumerable<Slide> GetAll();

        IEnumerable<Slide> GetAllPaging(int page, int pageSize, out int totalRow);

        Slide GetByID(int id);

        void SaveChanges();
    }
    public class SlideService : ISlideService
    {
        ISlideRepository _slideRepository;
        IUnitOfWork _unitOfWork;

        public SlideService(ISlideRepository slideRepository, IUnitOfWork unitOfWork)
        {
            this._slideRepository = slideRepository;
            this._unitOfWork = unitOfWork;
        }

        public Slide Add(Slide slide)
        {
            return _slideRepository.Add(slide);
        }

        public void Delete(int id)
        {
            _slideRepository.Delete(id);
        }

        public IEnumerable<Slide> GetAll()
        {
            return _slideRepository.GetAll();
        }

        public IEnumerable<Slide> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _slideRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Slide GetByID(int id)
        {
            return _slideRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Slide slide)
        {
            _slideRepository.Update(slide);
        }
    }
}
