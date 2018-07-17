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
    public interface ISystemConfigService
    {
        SystemConfig Add(SystemConfig systemConfig);

        void Update(SystemConfig systemConfig);

        void Delete(int id);

        IEnumerable<SystemConfig> GetAll();

        SystemConfig GetByID(int id);

        void SaveChanges();
    }
    public class SystemConfigService : ISystemConfigService
    {
        ISystemConfigRepository _systemConfigRepository;
        IUnitOfWork _unitOfWork;

        public SystemConfigService(ISystemConfigRepository systemConfigRepository, IUnitOfWork unitOfWork)
        {
            this._systemConfigRepository = systemConfigRepository;
            this._unitOfWork = unitOfWork;
        }

        public SystemConfig Add(SystemConfig systemConfig)
        {
            return _systemConfigRepository.Add(systemConfig);
        }

        public void Delete(int id)
        {
            _systemConfigRepository.Delete(id);
        }

        public IEnumerable<SystemConfig> GetAll()
        {
            return _systemConfigRepository.GetAll();
        }

        public SystemConfig GetByID(int id)
        {
            return _systemConfigRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SystemConfig systemConfig)
        {
            _systemConfigRepository.Update(systemConfig);
        }
    }
}
