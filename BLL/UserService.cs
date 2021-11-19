using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService
    {
        private readonly DentalTimeContext _context;

        public UserService(DentalTimeContext context) => _context = context;

        public User Validate(string userName, string password)
        {
            return _context.Users.FirstOrDefault(t => t.UserName == userName && t.Password == password && t.Estado == "AC");
        }
    }
}
