using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum CatalogOrderBy
    {
        [Display(Name = @"Varsayılan Sıralama")]
        Default = 1,
        [Display(Name = @"Popüler")]
        Popular = 2,
        [Display(Name = @"Ortalama Oy")]
        AverageVote = 3,
        [Display(Name = @"En güncele göre sırala")]
        MostActual = 4,
        [Display(Name = @"Artan fiyata göre sırala")]
        RisingPrice = 5,
        [Display(Name = @"Azalan fiyata göre sırala")]
        DecreasingPrice = 6
    }
}
