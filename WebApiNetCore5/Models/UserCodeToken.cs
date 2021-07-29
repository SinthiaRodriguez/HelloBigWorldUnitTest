using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore5.Models
{
    public class UserCodeToken
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(900)]
        public string Token { get; set; }

        [MaxLength(500)]
        public string UserId { get; set; }

        public DateTime ExpirationDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
