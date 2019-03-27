using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServices.DTO
{  
    public class DtoLogin
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }

    public class DtoLoginResponse
    { 
        public string token { get; set; } 
        public string errorMessage { get; set; } 
    }
}
