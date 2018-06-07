﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class Page : BaseEntity
    {
        public Page()
        {
            IsPublished = true;
            ViewCount = 0;
            ChildPages = new HashSet<Page>();
            LanguageId = 1;
            Template = "page";
            LayoutTemplate = "_Layout";
        }
        [StringLength(200)]
        [Required]
        [Display(Name ="Başlık")]
        public string Title { get; set; }

        [StringLength(200)]
        [Required]
        [Display(Name = "Bağlantı")]
        public string Slug { get; set; }


        [Display(Name = "İçerik")]
        public string Body { get; set; }

        [Display(Name = "Pozisyon")]
        public int Position { get; set; }

        [Display(Name = "Görüntülenme Sayısı")]
        public long ViewCount { get; set; }


        [Display(Name = "Üst Sayfa")]
        public long? ParentPageId { get; set; }
        [Display(Name = "Üst Sayfa")]
        [ForeignKey("ParentPageId")]
        public Page ParentPage { get; set; }
        [Display(Name = "Alt Sayfalar")]
        public virtual ICollection<Page> ChildPages { get; set; }

        [StringLength(200)]
        [Display(Name = "Seo Başlığı")]
        public string SeoTitle { get; set; }

        [Display(Name = "Seo Açıklama"),]
        
        public string SeoDescription { get; set; }

        [Display(Name = "Seo Anahtar Kelimeler")]
        public string SeoKeywords { get; set; }

        [Display(Name = "Yayında Mı?")]
        public bool IsPublished { get; set; }

        [StringLength(200)]
        [Display(Name = "Şablon")]    
        public string Template  { get; set; }

        [Display(Name = "Dil")]
        public long? LanguageId { get; set; }

        [StringLength(200)]
        [Display(Name = "Resim")]
        public string Photo { get; set; }

        [StringLength(200)]
        [Display(Name = "Meta1")]
        public string Meta1 { get; set; }

        [StringLength(200)]
        [Display(Name = "Meta2")]
        public string Meta2 { get; set; }

        [StringLength(200)]
        [Display(Name = "Meta3")]
        public string Meta3 { get; set; }

        [StringLength(200)]
        [Display(Name = "Tasarım Şablonu")]
        public string LayoutTemplate { get; set; }

        [Display(Name = "Header Script")]
        public string HeaderScript { get; set; }

        [ForeignKey("LanguageId")]
        [Display(Name = "Dil")]
        public Language Language { get; set; }
       
    }
}