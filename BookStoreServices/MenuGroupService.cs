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
    public interface IMenuGroupService
    {
        MenuGroup Add(MenuGroup menu);

        void Update(MenuGroup menu);

        void Delete(int id);

        IEnumerable<MenuGroup> GetAll();

        MenuGroup GetByID(int id);

        void SaveChanges();
    }
    public class MenuGroupService : IMenuGroupService
    {
        IMenuGroupRepository _menuGroupRepository;
        IUnitOfWork _unitOfWork;

        public MenuGroupService(IMenuGroupRepository menuGroupRepository, IUnitOfWork unitOfWork)
        {
            this._menuGroupRepository = menuGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public MenuGroup Add(MenuGroup menuGroup)
        {
            return _menuGroupRepository.Add(menuGroup);
        }

        public void Delete(int id)
        {
            _menuGroupRepository.Delete(id);
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _menuGroupRepository.GetAll();
        }

        public MenuGroup GetByID(int id)
        {
            return _menuGroupRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(MenuGroup menuGroup)
        {
            _menuGroupRepository.Update(menuGroup);
        }
    }
}
