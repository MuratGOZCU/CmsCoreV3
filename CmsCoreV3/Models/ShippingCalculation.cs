using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum ShippingCalculation
    {
        [Display(Name = @"Sepet sayfasında gönderim bedeli hesaplayıcısını etkinleştir")]
        Basket = 1,
        [Display(Name = @"Bir adres girilene kadar gönderim ücretini gizle")]
        Address = 2,
    }
}
