using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServices.DTO
{

    public partial class DtoUser
    {
        [Required] 
        [Display(Name = "Current password")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "EmailId")]
        public string EmailId { get; set; }
        [Required]
 
        [Display(Name = "Status")]
        public bool? Status { get; set; }
        
    }
}
