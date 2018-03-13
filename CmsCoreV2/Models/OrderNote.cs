using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class OrderNote:BaseEntity
    {
        [StringLength(200)]
        [Required]
        [Display(Name = "Sipariş Notu")]
        public string Note { get; set; }
        [Required]
        [Display(Name = "Özel mi?")]
        public bool IsPrivate { get; set; }
    }
}
