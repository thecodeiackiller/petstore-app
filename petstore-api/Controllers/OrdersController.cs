﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petstore.Data.Repositories;
using Petstore.DTO;

namespace petstore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrdersController(IOrderRepository orderRepository, IMapper mapper) 
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var result = await _orderRepository.GetAllOrders();
                List<OrderDTO> models = _mapper.Map<List<OrderDTO>>(result);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}