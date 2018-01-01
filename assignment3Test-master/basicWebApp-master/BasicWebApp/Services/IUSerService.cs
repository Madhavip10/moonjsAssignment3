using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicWebApp.Models;

namespace BasicWebApp.Services
{
    public interface IUSerService
    {
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
