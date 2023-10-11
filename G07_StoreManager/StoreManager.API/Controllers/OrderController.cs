using Microsoft.AspNetCore.Mvc;
using StoreManager.DTO;
using StoreManager.Facade.Interfaces.Services;
using StoreManager.Models;
using AutoMapper;


namespace StoreManager.API.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly IOrderCommandService _orderCommandService;
        private readonly IMapper _mapper;
        
        public OrderController( IOrderQueryService orderQueryService,IOrderCommandService orderCommandService,IMapper mapper)
    {
        _orderQueryService = orderQueryService;
        _orderCommandService = orderCommandService;
        _mapper = mapper;
    }


        [HttpGet]
        [Route("{id}")]
        public OrderModel Get(int id) => _mapper.Map<OrderModel>(_orderQueryService.Get(id));

        [HttpPost]
        public int Insert(OrderModel model) => _orderCommandService.Insert(_mapper.Map<Order>(model));

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, ProductModel model)
        {
            var order = _mapper.Map<Order>(model);
            order.Id = id;
            _orderCommandService.Update(order);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _orderCommandService.Delete(id);





    }


}
