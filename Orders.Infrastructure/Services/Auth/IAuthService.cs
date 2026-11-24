using Orders.Core.Dto;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseViewModel> Login(LoginDto dto);
    }
}
