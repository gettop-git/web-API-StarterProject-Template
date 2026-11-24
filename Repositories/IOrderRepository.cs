using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}
