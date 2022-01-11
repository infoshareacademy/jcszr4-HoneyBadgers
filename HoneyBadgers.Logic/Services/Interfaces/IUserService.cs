using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
    }
}
