﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore5.Models
{
    public class RestoreCode
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
