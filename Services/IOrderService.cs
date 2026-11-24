using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}
