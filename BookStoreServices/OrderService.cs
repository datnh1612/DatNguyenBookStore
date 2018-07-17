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
    public interface IOrderService
    {
        Order Add(Order order);

        void Update(Order order);

        void Delete(int id);

        IEnumerable<Order> GetAll();

        Order GetByID(int id);

        void SaveChanges();
    }
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
        }

        public Order Add(Order order)
        {
            return _orderRepository.Add(order);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetByID(int id)
        {
            return _orderRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
