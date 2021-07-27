using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore5.Models
{
    public class ChangeInfoUser : UserInfo
    {
        public string NewPass { get; set; }
    }
}
