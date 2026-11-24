using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository repo;
        public OrderService(IOrderRepository repository)
        {
            this.repo = repository;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await repo.AddOrder(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await repo.GetOrderById(id);
        }
    }
}
