using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BasicWebApp.Models;

namespace BasicWebApp.Services
{
    public class UserService : IUSerService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _context.Users
                .ToArrayAsync();

            return users;
        }
    }
}
