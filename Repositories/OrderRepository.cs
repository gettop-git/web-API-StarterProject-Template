using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        MyStorDBContext _context;
        public OrderRepository(MyStorDBContext _context)
        {
            this._context = _context;

        }
        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
    }
}
