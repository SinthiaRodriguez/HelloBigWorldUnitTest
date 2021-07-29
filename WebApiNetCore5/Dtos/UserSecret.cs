using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore5.Dtos
{
    public class UserSecret
    {
        [NotMapped]
        public string Key { get; set; }
    }
}
