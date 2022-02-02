using AutoMapper;
using PickPoints.Core.Entities;
using PickPoints.Core.Exceptions;
using PickPoints.Core.Models;
using PickPoints.Core.Repositories.Interfaces;
using PickPoints.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PickPoints.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IPostampRepository _postampsRepository;
        private readonly IMapper _mapper;

        public OrdersService(
            IOrderRepository ordersRepository,
            IPostampRepository postampsRepository,
            IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _postampsRepository = postampsRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateOrder(CreateOrderRequest model)
        {
            var postamp = await _postampsRepository.FirstOrDefaultdAsync(x => x.Number == model.PostampNumber);

            if (postamp == null)
                throw new NotFoundException($"Постамат с номером {model.PostampNumber} не найден");

            if (!postamp.IsActive)
                throw new InvalidOperationException($"Постамат с номером {model.PostampNumber} закрыт");

            var order = _mapper.Map<Order>(model);
            order.Postamp = postamp;

            _ordersRepository.UpdateAsync(order);
            await _ordersRepository.SaveAsync();

            return order.Id;
        }

        public async Task<OrderResponse> GetOrder(int id)
        {
            var order = await _ordersRepository.GetByIdWithPostampAsync(id);
            if (order == null)
                throw new NotFoundException($"Заказ с номером {id} не найден");

            return _mapper.Map<OrderResponse>(order);
        }

        public async Task UpdateOrder(int id, UpdateOrderRequest model)
        {
            var order = await _ordersRepository.GetByIdWithPostampAsync(id);
            if (order == null)
                throw new NotFoundException($"Заказ с номером {id} не найден");

            _mapper.Map(model, order);

            _ordersRepository.UpdateAsync(order);
            await _ordersRepository.SaveAsync();
        }

        public async Task CancelOrder(int id)
        {
            var order = await _ordersRepository.GetByIdAsync(id);
            if (order == null)
                throw new NotFoundException($"Заказ с номером {id} не найден");

            order.Status = OrderStatus.Canceled;
            _ordersRepository.UpdateAsync(order);
            await _ordersRepository.SaveAsync();
        }
    }
}
