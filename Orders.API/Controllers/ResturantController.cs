using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dto;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using Orders.Infrastructure.Services.Categories;
using Orders.Infrastructure.Services.Resturants;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RestaurantController : BaseController
    {
        private readonly IResturantService _restaurantService;
        public RestaurantController(IResturantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(string? searchkey = null)
        {
            var restaurants = await _restaurantService.GetAll(searchkey);
            return Ok(GetResponse(restaurants));
        }

        [HttpGet]
        public async Task<ActionResult> NearMe()
        {
            var category = await _restaurantService.NearMe(UserId);
            return Ok(GetResponse(category));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateResturantDto dto)
        {
            var savedId = await _restaurantService.Create(dto);
            return Ok(GetResponse(savedId));
        }



    }
}