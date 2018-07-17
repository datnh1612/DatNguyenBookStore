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
    public interface IMenuService
    {
        Menu Add(Menu menu);

        void Update(Menu menu);

        void Delete(int id);

        IEnumerable<Menu> GetAll();

        Menu GetByID(int id);

        void SaveChanges();
    }
    public class MenuService : IMenuService
    {
        IMenuRepository _menuRepository;
        IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }

        public Menu Add(Menu menu)
        {
            return _menuRepository.Add(menu);
        }

        public void Delete(int id)
        {
            _menuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public Menu GetByID(int id)
        {
            return _menuRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Menu menu)
        {
            _menuRepository.Update(menu);
        }
    }
}
