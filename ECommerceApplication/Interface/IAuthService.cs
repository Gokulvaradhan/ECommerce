using ECommerceDomain.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interface
{
    public interface IAuthService
    {
        Task<IEnumerable<IdentityError>> Register(Register register);
        Task<object> Login(Login login);
    }
}
