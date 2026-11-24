using Orders.Core.Dto;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Resturants
{
    public interface IResturantService
    {
        Task<List<ResturantViewModel>> GetAll(string searchKey);
        Task<List<ResturantViewModel>> NearMe(string UserId);
        Task<int> Create(CreateResturantDto dto);

    }
}
