﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Models
{
    public class User
    {
        public int MemberId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
