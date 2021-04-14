using AuthorizationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Provider
{
    public interface IJwtAuthenticationManager
    {
        public User Validate(User login);
        public string GenarateToken(string email);
    }
}
