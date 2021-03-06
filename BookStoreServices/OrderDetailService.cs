﻿using BookStoreData.Infrastructure;
using BookStoreData.Repositories;
using BookStoreModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreServices
{
    public interface IOrderDetailService
    {
        OrderDetail Add(OrderDetail orderDetail);

        void Update(OrderDetail orderDetail);

        void Delete(int id);

        IEnumerable<OrderDetail> GetAll();

        OrderDetail GetByID(int id);

        void SaveChanges();
    }
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitOfWork;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            return _orderDetailRepository.Add(orderDetail);
        }

        public void Delete(int id)
        {
            _orderDetailRepository.Delete(id);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _orderDetailRepository.GetAll(new string[] { "Order"} );
        }

        public OrderDetail GetByID(int id)
        {
            return _orderDetailRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
        }
    }
}
