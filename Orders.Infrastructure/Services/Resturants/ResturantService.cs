using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.Core.Dto;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using Orders.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Resturants
{
    public class ResturantService : IResturantService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public ResturantService(OrdersDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ResturantViewModel>> GetAll(string searchKey)
        {
            var resturants = await _db.Resturants
                            .Include(x => x.Meals)
                            .Where(x => x.Name.Contains(searchKey) || string.IsNullOrEmpty(searchKey))
                            .OrderByDescending(x => x.Meals.Count())
                            .ToListAsync();
            return _mapper.Map<List<ResturantViewModel>>(resturants);
        }

        public async Task<int> Create(CreateResturantDto dto)
        {
            var resturant = _mapper.Map<Resturant>(dto);
            await _db.Resturants.AddAsync(resturant);
            await _db.SaveChangesAsync();
            return resturant.Id;
        }

        public async Task<List<ResturantViewModel>> NearMe(string userId)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (user == null || user.Latitude == null || user.Longitude == null)
                throw new Exception("User location not found");

            var resturants = await _db.Resturants
                .Where(x => x.Latitude != null && x.Longitude != null)
                .ToListAsync();

            var distances = new Dictionary<int, double>();
            var userLocation = new Coordinates((double)user.Latitude, (double)user.Longitude);

            foreach (var resturant in resturants)
            {
                var resturantLocation = new Coordinates((double)resturant.Latitude!, (double)resturant.Longitude!);
                distances.Add(resturant.Id, userLocation.DistanceTo(resturantLocation));
            }

            var nearIds = distances.OrderBy(x => x.Value)
                                   .Take(5)
                                   .Select(x => x.Key)
                                   .ToList();

            var nearResturants = await _db.Resturants
                .Where(x => nearIds.Contains(x.Id))
                .ToListAsync();

            return _mapper.Map<List<ResturantViewModel>>(nearResturants);
        }
    }
}
