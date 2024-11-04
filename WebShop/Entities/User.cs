﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string? FrstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public bool Satus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IdRole { get; set; }
    }
}
