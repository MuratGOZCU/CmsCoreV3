using CmsCoreV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace CmsCoreV2.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            // migration'ları veritabanına uygula
            context.Database.Migrate();
            AppTenant tenant = context.tenant;
            if (tenant != null) { 
            string tenantId = tenant.AppTenantId;
            // Look for any pages record.
            if (context.SetFiltered<Language>().Where(l => l.AppTenantId == tenantId).Any())
            {
                return;   // DB has been seeded
            }
            
            // Perform seed operations
            var languageId = AddLanguages(context, tenant);
            AddPages(context, tenant, languageId);
            context.SaveChanges();
            AddSettings(context, tenant);           
            AddCustomization(context, tenant);
            AddMenus(context,tenant);            
            AddMenuItems(context,tenant);
            context.SaveChanges();
            AddHomePageSlider(context, tenant);
            AddHomePageSlide(context, tenant);
            AddSecondarySlider(context, tenant);
            AddSecondarySlide(context, tenant);
            AddLogoSlider(context, tenant);
            AddLogoSlide(context, tenant);
            AddForms(context,tenant);
            AddFormFields(context, tenant);
            AddGalleries(context, tenant);
            AddGalleryItems(context, tenant);
            AddGalleryItemCategories(context, tenant);
            AddPosts(context, tenant);
            AddPostCategories(context, tenant);
            AddGalleryItemGalleryItemCategories(context, tenant);
            AddPostPostCategories(context, tenant);
            AddResources(context, tenant);




                context.SaveChanges();
            }

        }
        private static void AddPostPostCategories(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new PostPostCategory { PostId = 1, PostCategoryId = 1, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 3, PostCategoryId = 1, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 4, PostCategoryId = 1, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 5, PostCategoryId = 1, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 6, PostCategoryId = 1, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 2, PostCategoryId = 3, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 1, PostCategoryId = 4, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 2, PostCategoryId = 4, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 1, PostCategoryId = 5, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 2, PostCategoryId = 5, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 1, PostCategoryId = 6, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 2, PostCategoryId = 6, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 1, PostCategoryId = 7, AppTenantId = tenant.AppTenantId },
                new PostPostCategory { PostId = 2, PostCategoryId = 7, AppTenantId = tenant.AppTenantId }

                );
            context.SaveChanges();
        }
        private static void AddGalleryItemGalleryItemCategories(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new GalleryItemGalleryItemCategory { GalleryItemId=1,GalleryItemCategoryId = 1, AppTenantId = tenant.AppTenantId },
                new GalleryItemGalleryItemCategory { GalleryItemId = 1, GalleryItemCategoryId = 2, AppTenantId = tenant.AppTenantId },
                new GalleryItemGalleryItemCategory { GalleryItemId = 2, GalleryItemCategoryId = 1, AppTenantId = tenant.AppTenantId },
                new GalleryItemGalleryItemCategory { GalleryItemId = 2, GalleryItemCategoryId = 2, AppTenantId = tenant.AppTenantId }


                );
            context.SaveChanges();
        }
        private static void AddPostCategories(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new PostCategory { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description=null,LanguageId=1,Name= "Haberler",ParentCategoryId=null,Slug= "haberler", AppTenantId = tenant.AppTenantId },
                new PostCategory { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description = null, LanguageId = 1, Name = "Kadromuz", ParentCategoryId = null, Slug = "kadromuz", AppTenantId = tenant.AppTenantId },
                new PostCategory { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description = "blog", LanguageId = 1, Name = "Blog", ParentCategoryId = null, Slug = "blog", AppTenantId = tenant.AppTenantId },
                new PostCategory { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description = "Anaokulu", LanguageId = 1, Name = "Anaokulu", ParentCategoryId = 1, Slug = "anaokulu", AppTenantId = tenant.AppTenantId },
                new PostCategory { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description = "İlkokul", LanguageId = 1, Name = "İlkokul", ParentCategoryId = 1, Slug = "ilkokul", AppTenantId = tenant.AppTenantId },
                new PostCategory { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description = "Ortaokul", LanguageId = 1, Name = "ortaokul", ParentCategoryId = 1, Slug = "ortaokul", AppTenantId = tenant.AppTenantId },
                new PostCategory { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description = "Lise", LanguageId = 1, Name = "lise", ParentCategoryId = 1, Slug = "lise", AppTenantId = tenant.AppTenantId }

                );
            context.SaveChanges();
        }
        private static void AddPosts(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new Post { CreatedBy = "username", CreateDate = DateTime.Now,  UpdatedBy = "username", UpdateDate = DateTime.Now,  Body= "<p>Donec rutrum ante augue, eu rutrum turpis finibus vel. Quisque augue sapien, ornare ut turpis ac, faucibus tempus purus. Ut consectetur aliquam ligula. Phasellus efficitur at erat sit amet tincidunt. Sed pellentesque viverra posuere. Phasellus convallis at mauris quis tincidunt. Etiam condimentum odio ut vehicula eleifend. Etiam mi metus, pulvinar a iaculis eget, hendrerit sed est. Fusce felis lectus, elementum quis ultricies ullamcorper, maximus id mi. Aliquam quis finibus ipsum. Proin ut feugiat purus. Nulla in risus eleifend, sodales quam eget, volutpat leo.</p>",Description= "küçük masa lambası",IsPublished=true,LanguageId=1,Meta1= "meta1 nedir" ,Meta2= "meta2 nedir",Photo= "/uploads/images/18.jpg", SeoDescription= "post",SeoKeywords= "post",SeoTitle= "post",Slug= "haber1",Title= "Donec rutrum ante augue, eu rutrum turpis finibus vel",ViewCount=0, AppTenantId = tenant.AppTenantId },
                new Post { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Body = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tincidunt risus tortor, vitae congue nisi maximus vitae. Nunc id sapien ut est ultrices porta. In euismod dui vitae metus venenatis vehicula. Pellentesque non lacinia odio. Fusce id lectus eu justo euismod congue. Suspendisse potenti. Pellentesque rhoncus volutpat orci sed maximus. Mauris volutpat quam ac dui rhoncus, vel vestibulum nisl tristique. Aliquam scelerisque nunc in consectetur porta. Fusce quis molestie lacus. Phasellus molestie egestas arcu, sit amet condimentum mauris facilisis ut. Ut tempor felis erat, vitae hendrerit felis fermentum at. Quisque risus justo, lacinia id nibh in, lacinia aliquet enim.</p>", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", IsPublished = true, LanguageId = 1, Meta1 = null, Meta2 = null, Photo = "/uploads/images/19.jpg", SeoDescription = "blog", SeoKeywords = "blog", SeoTitle = "blog", Slug = "ilk-blog-yazisi", Title = "İlk blog yazısı", ViewCount = 0, AppTenantId = tenant.AppTenantId },
                new Post { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Body = "<h3>Section 1.10.32 of &quot;de Finibus Bonorum et Malorum&quot;, written by Cicero in 45 BC</h3>", Description = "culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias co", IsPublished = true, LanguageId = 1, Meta1 = null, Meta2 = null, Photo = "/uploads/images/20.jpg", SeoDescription = "yok", SeoKeywords = "yok", SeoTitle = "yok", Slug = "flat-resimler", Title = "Flat resimler", ViewCount = 0, AppTenantId = tenant.AppTenantId },
                new Post { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Body = "<h3>Section 1.10.33 of &quot;de Finibus Bonorum et Malorum&quot;, written by Cicero in 45 BC</h3>", Description = "culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias co", IsPublished = true, LanguageId = 1, Meta1 = null, Meta2 = null, Photo = "/uploads/images/21.jpg", SeoDescription = null, SeoKeywords = null, SeoTitle = null, Slug = "flat-2-resim-haber", Title = "Flat 2. resim haber ", ViewCount = 0, AppTenantId = tenant.AppTenantId },
                new Post { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Body = "<h3>The standard Lorem Ipsum passage, used since the 1500s</h3>", Description = "nis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque po", IsPublished = true, LanguageId = 1, Meta1 = "a", Meta2 = "a", Photo = "/uploads/images/21.jpg", SeoDescription = "a", SeoKeywords = "a", SeoTitle = "a", Slug = "fil-haberleri-basliyor", Title = "Fil haberleri başlıyor", ViewCount = 0, AppTenantId = tenant.AppTenantId },
                new Post { CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Body = "<h3>1914 translation by H. Rackham</h3>", Description = "st, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures ha", IsPublished = true, LanguageId = 1, Meta1 = "a", Meta2 = "a", Photo = "/uploads/images/22.jpg", SeoDescription = "a", SeoKeywords = "a", SeoTitle = "a", Slug = "kameralar-geldi", Title = "Kameralar geldi", ViewCount = 0, AppTenantId = tenant.AppTenantId }


                );
            context.SaveChanges();
        }

        private static void AddFeedbackValues(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new FeedbackValue { CreatedBy = "username", CreateDate = DateTime.Now, FeedbackId = 1, FieldType = FieldType.fullName, FormFieldId = 1, FormFieldName = "Ad Soyad", UpdatedBy = "username", UpdateDate = DateTime.Now, Position = 1, AppTenantId = tenant.AppTenantId },

                new FeedbackValue { CreatedBy = "username", CreateDate = DateTime.Now, FeedbackId = 1, FieldType = FieldType.email, FormFieldId = 2, FormFieldName = "E-posta", UpdatedBy = "username", UpdateDate = DateTime.Now, Position = 2, AppTenantId = tenant.AppTenantId },
                new FeedbackValue { CreatedBy = "username", CreateDate = DateTime.Now, FeedbackId = 1, FieldType = FieldType.telephone, FormFieldId = 3, FormFieldName = "Telefon", UpdatedBy = "username", UpdateDate = DateTime.Now, Position = 3, AppTenantId = tenant.AppTenantId },
                new FeedbackValue { CreatedBy = "username", CreateDate = DateTime.Now, FeedbackId = 1, FieldType = FieldType.radioButtons, FormFieldId = 4, FormFieldName = "Çocuğunuzu kaydettirmeyi düşündüğünüz okul aşağıdakilerden hangisidir?", UpdatedBy = "username", UpdateDate = DateTime.Now, Position = 4,Value=null, AppTenantId = tenant.AppTenantId },
                new FeedbackValue { CreatedBy = "username", CreateDate = DateTime.Now, FeedbackId = 1, FieldType = FieldType.dropdownMenu, FormFieldId = 5, FormFieldName = "Çocuğunuzu kaydettirmeyi düşündüğünüz sınıf hangisidir?", UpdatedBy = "username", UpdateDate = DateTime.Now, Position = 5, Value = "Seçiniz", AppTenantId = tenant.AppTenantId },
                new FeedbackValue { CreatedBy = "username", CreateDate = DateTime.Now, FeedbackId = 1, FieldType = FieldType.checkbox, FormFieldId = 6, FormFieldName = "Abonelik", UpdatedBy = "username", UpdateDate = DateTime.Now, Position = 6, Value = null, AppTenantId = tenant.AppTenantId }
                );
        }
        private static void AddFeedbacks(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new Feedback { CreatedBy= "username",CreateDate=DateTime.Now,FormId=1,FormName="Sizi Arayalım",UpdatedBy="username",UpdateDate=DateTime.Now,UserName="username",SentDate=DateTime.Now, AppTenantId = tenant.AppTenantId }

                
                );
            AddGalleries(context, tenant);
            context.SaveChanges();

        }
        public static long AddLanguages(ApplicationDbContext context, AppTenant tenant)
        {
            var l = new Language();
            l.Name = "Turkish";
            l.NativeName = "Türkçe";
            l.Culture = "tr";
            l.IsActive = true;
            l.AppTenantId = tenant.AppTenantId;
            context.Languages.Add(l);

            var eng = new Language();
            eng.AppTenantId = tenant.AppTenantId;
            eng.Name = "English";
            eng.NativeName = "İngilizce";
            eng.Culture = "en";
            eng.IsActive = true;
            context.Languages.Add(eng);
            context.SaveChanges();

            return l.Id;


        }
        public static void AddPages(ApplicationDbContext context, AppTenant tenant, long languageId)
        {
           
            context.AddRange(
                new Page { Title = "Anasayfa", Slug = "anasayfa", Template = "Index", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now , AppTenantId = tenant.AppTenantId},
                new Page { Title = "AnaOkulu", Slug = "anaokulu", Template = "kindergarten", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "İlkokul", Slug = "ilkokul", Template = "primaryschool", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Ortaokul", Slug = "ortaokul", Template = "middleschool", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Lise", Slug = "lise", Template = "highschool", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Derslikler", Slug = "derslikler", ParentPageId = 15, Template = "Page", LanguageId = 1, IsPublished = true,Position=12, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                
                new Page { Title = "Kampüs", Slug = "kampus", Template = "Page", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "İngilizce Laboratuvarı", Slug = "ingilizce-laboratuvari", ParentPageId=15, Template = "Page", LanguageId = 1, IsPublished = true, Position = 13, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Bilişim Laboratuvarı ", Slug = "bilisim-laboratuvarı", ParentPageId=15, Template = "Page", LanguageId = 1, IsPublished = true, Position = 14, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Fen Bilimleri Laboratuvarı ", Slug = "fen-bilimleri-laboratuvari", ParentPageId=15, Template = "Page", LanguageId = 1, IsPublished = true, Position = 15, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Müzik Atölyesi", Slug = "muzik-atolyesi", Template = "Page", ParentPageId=15, LanguageId = 1, IsPublished = true, Position = 16, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Güzel Sanatlar Atölyesi", Slug = "guzel-sanatlar-atolyesi", ParentPageId=15,Template = "Page", LanguageId = 1, IsPublished = true, Position = 17, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Spor Salonu", Slug = "spor-salonu", Template = "Page", ParentPageId=15,LanguageId = 1, IsPublished = true, Position = 18, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Kütüphane", Slug = "kutuphane", Template = "Page", ParentPageId=15,LanguageId = 1, IsPublished = true, Position = 19, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Yemekhane", Slug = "yemekhane", Template = "Page", ParentPageId = 15, LanguageId = 1, IsPublished = true, Position = 20, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Bahçe", Slug = "bahce", Template = "Page", ParentPageId = 15, LanguageId = 1, IsPublished = true, Position = 21, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Farkımız", Slug = "farkimiz", Template = "Page", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Haberler", Slug = "haberler", Template = "Posts", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Blog", Slug = "blog", Template = "Blog", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Ön Kayıt Formu", Slug = "on-kayit-formu", Template = "PreRegistration", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now , AppTenantId = tenant.AppTenantId },
                new Page { Title = "İş Başvuru Formu", Slug = "is-basvuru-formu", Template = "JobApplicationForm", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now , AppTenantId = tenant.AppTenantId },
                new Page { Title = "Arama", Slug = "arama", Template = "Search", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now , AppTenantId = tenant.AppTenantId },
                new Page { Title = "Anket", Slug = "anket", Template = "Survey", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now , AppTenantId = tenant.AppTenantId },
                new Page { Title = "Galeri", Slug = "galeri", Template = "Gallery", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now , AppTenantId = tenant.AppTenantId },
                new Page { Title = "Site Haritası", Slug = "site-haritasi", Template = "SiteMap", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now , AppTenantId = tenant.AppTenantId },
                new Page { Title = "Kurumsal", Slug = "kurumsal", Template = "Page", LanguageId = 1,ParentPageId =11,Position=1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Kadromuz", Slug = "kadromuz", Template = "Page", LanguageId = 1, ParentPageId = 11,Position=3, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Hakkımızda", Slug = "hakkimizda", Template = "Page", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Ön Kayıt", Slug = "on-kayit", Template = "PreRegistration", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Bize Ulaşın", Slug = "bize-ulasin", Template = "Contact", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body= "<div class=\"row contact-method\"><div class=\"col-md-4\"><div class=\"method-item\"><i class=\"fa fa-map-marker\"></i><p class=\"sub\">ADRES</p><div class=\"detail\"><p>Bahariye Caddesi Süleymanpaşa Sokak No:2</p><p>Türkiye</p></div></div></div><div class=\"col-md-4\"><div class=\"method-item\"><i class=\"fa fa-phone\"></i><p class=\"sub\">ARA</p><div class=\"detail\"><p>Local: 216-346-26-06</p><p>Mobile: 444-3-236</p></div></div></div><div class=\"col-md-4\"><div class=\"method-item\"><i class=\"fa fa-envelope\"></i><p class=\"sub\">İLETİŞİM</p><div class=\"detail\"><p>bilisim@bilisimegitim.com</p><p>www.bilisimegitim.com</p></div></div></div></div>" },
                new Page { Title = "İş başvurusu", Slug = "is-basvurusu", Template = "JobRecourseForm", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Okul Öncesi", Slug = "okul-oncesi", Template = "Page", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Yönetim Kurulu", Slug = "yonetim-kurulu", Template = "Page", LanguageId = 1, ParentPageId = 11,Position=4, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "İngilizce Eğitimleri", Slug = "ingilizce-egitimleri", Template = "Page", Position=5,LanguageId = 1,ParentPageId=48, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId,Body= "<p>Bilgi Koleji&rsquo;nde, &ccedil;ocuklarımıza basit&ccedil;e dinleme ya da aynı metotların tekrarından oluşan, bilinen y&ouml;ntemler yerine; LSA ( Learning Style Analysis: &Ouml;ğrenme stili analizi ) ve TSA ( Teaching Style Analysis &Ouml;ğretme stili analizi ) alanlarında uzman yabancı &ouml;ğretmenlerimizle, Task Based Learning ( Durum ve Olaylara Dayalı &Ouml;ğrenme) modeliyle, her &ouml;ğrencinin farklı &ouml;ğrenme stiline uygun tasarlanmış bir m&uuml;fredatla İngilizce &ouml;ğretiyoruz. İngilizce eğitimlerimizde kullandığımız, &ldquo;Durum Bazlı &Ouml;ğrenme Modeliyle&rdquo;, doğal dil &ouml;ğrenme hızı yakalanır ve &ouml;l&ccedil;&uuml;lebilir etkin konuşma becerisi kazanılır.</p><p> Bilgi Koleji &rsquo;de,<strong> &ldquo; A + 5B Eğitim Modeli </strong> &rdquo; gereği olarak çocuklarımız İngilizce&rsquo; yi anadil d & uuml; zeyinde öğrenirler.Amacımız öğrencilerimizin hayatları boyunca öğrendikleri İngilizceyi akıcı bir şekilde konuşmalarını sağlamaktır.</p><p> Dil Ko&ccedil; luğu uygulaması, Türkiye &rsquo;de ilk kez Bilgi Koleji & rsquo; nde, eğitim programının i&ccedil;ine yerleştirilmiş, tamamen &ouml;ğrenci odaklı, CEFR (The Common European Framework of Reference for Languages - Avrupa Dil Kriterleri Portfolyosu) &rsquo;na paralel şekilde ilerleyen ve eğitimden maksimum verim alınmasını sağlayan &ouml;zel bir sistemdir.Bu sistemle; eğitim sırasında ve sonrasında kimin hangi &ouml;ğrenme modeline yatkın olduğu s&uuml;rekli g&ouml;zlemlenir ve kişiye &ouml;zel hazırlanan programlarla, eğitim materyallerimiz &ouml;ğrenci merkezli olarak g&uuml;ncellenir, &ouml;ğrenme s&uuml;reci denetlenir. Dil Ko&ccedil;luğu uygulaması ile &ouml;ğrencilerimizin konuşma, anlama, dinleme, ve yazma alanlarının tüm &uuml;nde &ouml;ğrenme içmotivasyonunun yükseltilmesi hedeflenir.</p><p> Bilgi Koleji &rsquo;nde ilkokulu bitiren &ouml;ğrencilerimiz; Cambridge English, Flyers sınavına tabi tutulur ve yeterlilikleri &ouml;l&ccedil;&uuml;l &uuml;r.Ortaokul &ouml;ğrencilerimizin ise Cambridge English, Preliminary English(PET) sınavlarıyla yazılı ve s&ouml;zlüolarak İngilizce seviyeleri &ouml;l&ccedil;&uuml;l&uuml;r. &Ouml;ğrencilerimiz, bu seviye tespit y&ouml;ntemleri sayesinde 8.sınıfın sonunda CEFR kriterlerine g&ouml;re B1-B2 düzeyinde okur, anlar, dinler, konuşur ve yazar d & uuml; zeye ulaşmış olur.</p><p> Deneyimli &ouml;ğretmenlerimiz, ebeveynlerle işbirliği yaparak;&ouml;ğrencilerimize; edindikleri dil becerilerini okul dışında da ortaya koyabileceklerine dair g&uuml;ven duygusu kazandırırlar. &Ccedil;ocuklarımız g&ouml;rsel, işitsel ve oyuna dayalı tekniklerle, İngilizce öğrenimini bilinen &ouml;ğrenmes&uuml;re &ccedil;leri dışında metotlarla doğal kazanım haline getirirler.</p><p> Uluslararası etkinlik ve projelerle öğrendiklerini sunma ve sergileme hazzını yaşayan Bilgi Koleji &ouml;ğrencileri, dil &ouml;ğrenmenin toplumları ve kişileri yaklaştırma ve en önemlisi tanıma yolu olduğunu da deneyimlerler.</p><p> &nbsp;</p>" },
                new Page { Title = "Kişisel Gelişim Eğitimleri", Slug = "kisisel-gelisim-egitimleri", Template = "Page",Position=7, LanguageId = 1, ParentPageId = 48, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId,Body= "<p>Bilgi Koleji&rsquo;nde &ldquo;<strong>A+5B Eğitim Modeli</strong>&rdquo; nin gereği olarak &ouml;ğrencilerimizin kişisel gelişimlerinin en az akademik gelişimleri kadar &ouml;nemli olduğunun bilincindeyiz. &Ccedil;ocuklarımızın; hayatın t&uuml;m evrelerinde &uuml;retken ve g&uuml;&ccedil;lüolabilmesi i&ccedil;in farklı kazanımlar edinmesini hedefleriz. Bu nedenle okulumuzda; kişisel gelişim alanında rehber &ouml;ğretmenlerimiz dışında var olan kurullarımızda bizimle yola &ccedil;ıkan uzmanı bilim insanlarının da desteği alınmaktadır. &Ouml;ğrencilerimiz, kişisel ve akademik gelişim alanlarında eş zamanlı ilerlemeyi hedefleyen modelimizle, gelecekte &ouml;zg&uuml;ven ve &ouml;zsaygısı tam bireyler olurlar.</p><p> &ldquo; Kişisel Gelişim Eğitimlerimiz &rdquo;de, öğrencilerimize hedeflerine ulaşmak i&ccedil;in motivasyonlarını yükselterek, yaratıcı düş & uuml; nmeyi ve sorumluluk almayı öğretiriz.</ p >< p > Bilgi Koleji & rsquo; de biz, okul öncesinden başlayarak, çocuklarımızın eğitim hayatının tamamına yayılmış oyuna dayalı bir anlayışla, onların en y&uuml;ksek potansiyelini ortaya &ccedil;ıkararak, yaşamları boyunca etkin, verimli ve mutlu olmalarını sağlarız.</p><p> Okulumuzda, Kişisel Gelişim ama &ccedil;lı, her yaş grubuna &ouml;zel hazırlanmış eğlenceli etkinlik ve at&ouml;lye çalışmalarımızı; &ouml;ğrenci ve veliyi kapsayacak bir perspektifle oluştururuz.Bilgi Koleji &ouml;ğrencileri, okul hayatları boyunca aşağıdaki temel başlıklarda kazanımlar edinirler:</p><ul><li> Kendini Tanıma,</li><li> Gerginlikle Baş etme,</li><li> &Ouml;fke KontrolüKazanma,</li><li> Etik Değerleri Geliştirme,</li><li> İletişim Becerileri Kazanma,</li><li> Zamanı Verimli Kullanma,</li><li> Okulda ve Hayatta Zorbalıkla M&uuml;cadele </li><li> Stres Y&ouml;netimi,</li><li> Barış Eğitimi,</li><li> Ergenlik D&ouml;nemi Duygu Y&ouml;netimi </li></ul><p> Bu başlıklar altında yapılan eğitimleri, zaman zaman bire bir g&ouml;r &uuml;şmelerle, velilerimizi de dahil ederek &ldquo; Ebeveyn Eğitimleri&rdquo; ile de pekiştiririz.</p><p> Okulumuz  &uuml;nyesindeki kurullarımızda yer alan uzman pedagog ve eğitimlerimizin işbirliği ile oluşturduğumuz, &ldquo;Bilgi Akademi&rdquo;de, veli, &ouml;ğretmen ve okul çalışanlarına yönelik sürekli eğitim merkezi olarak, okul y önetimiyle işbirliği halinde etkinlikler, eğitimler ve seminerler d&uuml;zenlenir.Amacımız; &ouml;ğrencilerimizin başarısı i&ccedil;in bizimle aynı yolda y&uuml;r&uuml;yen veli, &ouml;ğretmen ve okul &ccedil;alışanlarımızın da hayatın tüm alanlarında verimli ve kaliteli iletişim kurmalarını sağlamak, böylelikle deçocuklarımızın eğitim hayatına daha fazla dokunabilmektir.</p><p> Kurumumuz tarafından oluşturulmuş &ouml;l&ccedil;me - değerlendirme kriterleri ışığında ve &ouml;zellikle velilerle yapılan gör&uuml;şmeler sonucunda &ouml;nceliğimiz &ouml;ğrencilerimizin kazanımlarını arttırmaktır.Bu y&ouml;ntem sayesinde aile ile öğrenci arasındaki iletişim de g&uuml;&ccedil;lenmektedir.T&uuml;m bu s&uuml;re&ccedil;ler konularında uzman bilim insanlarının katılacağı okul i&ccedil;i ve okul dışı seminer ve etkinliklerle de desteklenmektedir.</p><p> &nbsp;</p><p> Kişisel Gelişim Eğitimleri ancak doğru okul iklimi oluşturulduğu hallerde başarıya ulaşabilir. Bu nedenle okulumuzdaki t&uuml;m idari ve akademik kadrolarımız da aynı bilinçve &ouml;zenle se&ccedil;ilip eğitimlere tabi tutulmaktadır.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Sanat Eğitimleri", Slug = "sanat-egitimleri", Template = "Page", LanguageId = 1, Position=8,ParentPageId = 48, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId,Body= "<p>Bilgi Koleji&rsquo;nde eğitim programlarımıza y&ouml;n veren, <strong>&ldquo;A+5B Eğitim Modeli&rdquo; </strong>mizin bileşenlerinden biri de sanat eğitimidir. Bizim bakış a&ccedil;ımıza g&ouml;re, sanat eğitimi; bilim, teknoloji, kişisel gelişim ve spor eğitimleriyle birlikte bireysel ve toplumsal eğitimin vazge&ccedil;ilmezlerinden birisidir. İnsan &ccedil;ok y&ouml;nlüeğitim gereksinimi olan bir varlıktır. Bu nedenle akademik başarıyı destekleyecek bu alanlarda, &ccedil;ocuklarımızın eğilimlerini keşfediyor, uygun i&ccedil;eriklerle zenginleştirilmiş programlar &uuml;retiyor ve eğitimdeki yenilik&ccedil;i anlayışımızla daima g&uuml;ncelliyoruz.</p><p> Ayrıca bizlere destek veren ve öğrencilerimize sanat alanında yol g östermek i&ccedil;in bir araya getirdiğimiz konusunda s öz sahibi olmuş, değerli kişilerden oluşan & ldquo; Sanat Kurulu&rdquo; muz da okulumuz i&ccedil;in ayrı bir gurur kaynağıdır.</ p >< p > öğrencilerimizin, okulumuzda alacakları sanat eğitimi, yaşam boyu sürecek bir disiplinin parçası olacağından, müfredatımızın kazanımları, sadece &ouml;rg&uuml;n eğitimle değil aynı zamanda sergiler, m&uuml;zeler, kitap, dergi, yayın ve her t&uuml;rl&uuml;g&ouml;rsel - işitsel iletişim araçları ile laboratuvar ortamlarıyla da desteklenmektedir. Konularında uzman kişilerden oluşan &ldquo; Sanat Kurulu&rdquo; &uuml;yelerinin gör&uuml;ş ve &ouml;nerileri ışığında &ouml;ğrencilerimizin, sanat ve kült&uuml;r d&uuml;nyasına daha yakın olabilmeleri i&ccedil;in girişimlerde bulunulmaktadır. Kült&uuml;rel alanlara geziler düzenlenmekte ve yine kurulumuz &uuml;yelerinin desteğiyle, farklı alanlardaki sanat&ccedil;ılarla iş birlikleri yapılmaktadır. Ayrıca &ouml;ğrenciler sanatla alakalı organizasyonlara, festival ve yarışmalara katılmak i&ccedil;in teşvik edilmektedirler.</p><p> Kurulumuz &rsquo;da yer alan duayen sanat &ccedil;ılarımız g&ouml;zetiminde ve &ouml;ğretmenlerimizin bakış açısına g&ouml;re sanat eğitiminin amaçlarından biri de bireye g&ouml;rmeyi, işitmeyi, dokunmayı, tat almayı öğretmektir.Okulumuz i&ccedil;in &ouml;zel olarak tasarlanmış görsel sanatlar ve m&uuml;zik at&ouml;lyelerinde yapılan &ccedil;alışmalar, yalnızca bakmak değil, &ldquo;g&ouml;rmek &rdquo;, yalnızca duymak değil &ldquo;işitmek &rdquo;, yalnızca elle yoklamak değil, &ldquo;dokunulanı duyumsamak ve keşfetmek&rdquo; aşamalarını kapsamaktadır.</p><p> Bilgi Koleji &rsquo;nde sanat eğitimi, &ccedil;ocuklarımızın sadece yaratıcılıklarını ortaya çıkartmakla kalmaz, aynı zamanda &ouml;ğrencilerimizin kişisel gelişimlerini de destekler.Bu y&ouml;nüile<strong> &ldquo; A + 5B Eğitim Modeli & rdquo; </strong> mizin bütünl&uuml;ğ&uuml;n&uuml;n ayrılmaz bir parçasıdır.</p><p> Okulumuzda, sanat derslerimiz aşağıdaki başlıklara göre şekillenmiştir:</p><ul><li><strong> G&ouml;rsel sanatlar;</strong> iki boyutlu sanat; resim ve &ccedil;izim gibi, ayrıca &uuml;çboyutlu sanatlar; heykel ve seramik yapımı,</li><li><strong> M&uuml;zik;</strong> m&uuml;zik performansı, kompozisyon ve m&uuml;zik eleştirisi,</li><li><strong> Drama;</strong> drama performansı, oyun yazarlığı ve oyun eleştirmenliği,</li><li><strong> Dans;</strong> dans performansı, koreografi ve dans eleştirmenliği,</li><li><strong> Medya sanatları;</strong> fotoğraf &ccedil;ılık, sinema, video ve bilgisayar animasyonları,</li><li><strong> Mimari;</strong> bina tasarım sanatı; bir alanın g&ouml;zlemi, planlaması ve bilgisayar ortamına 3 boyutlu modellemesi,</li></ul><p> Bilgi Koleji &rsquo;nde; sanatsal duyarlılıkları eğitilen &ccedil;ocuklarımız, bu duyarlılıkla ve yaklaşımla g&ouml;zleriyle de d&uuml;ş ünerekd&uuml;nyaya bakar ve üretirler.</p>" },
                new Page { Title = "Spor Eğitimi", Slug = "spor-egitimi", Template = "Page", LanguageId = 1,Position=9, ParentPageId = 48, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId,Body= "<p>Bilgi Koleji&rsquo;nin eğitim i&ccedil;erikleri ve &ldquo;A+5B Eğitim Modeli&rdquo; oluşturulurken, Spor Kurulu&rsquo;muzun da katkıları alınarak; sporun &ccedil;ocuk ve gen&ccedil;lerde fiziksel, duyusal, sosyal ve bilişsel kazanımları desteklediği prensibiyle ile yola &ccedil;ıkılmıştır.</p><p> &nbsp;</p><p> Okulumuzda yapılan sportif etkinlikler, öğrencilerimizin bedensel özellikleri, spora yönelik ilgi alanları ve yetenekleri bilimsel testler yardımıyla saptandıktan sonra, akademik gelişim ile sağlıklı yaşam parametreleri dikkate alınarak planlanır. Bizce spor, çocuklarımızın sadece bedenini değil, büt&uuml;nsel gelişimlerini son derece önemli ve gereklidir.</p><p> &nbsp;</p><p> öğrencilerimizin gerek psikolojik gerekse sosyal bakımdan gelişmelerinde, oyunla birlikte sporun önemli bir yeri vardır. çünk & uuml; çocuklarımız bu faaliyetlere katılırken aynı zamanda grup içerisinde hareket etmeyi, kazanmayı veya kaybetmeyi, kurallara uymayı öğrenmektedir.</p><p> En önemlisi, öğrencilerimiz sportif aktivitelere katılarak, kendine g&uuml;ven duygusunu kazanmakta ve toplumun bir ferdi olduğunu anlamaktadır.Bilgi Koleji&rsquo;nde &ouml;ğrencilerimiz, sportif etkinliklerimiz sayesinde birçok farklı ortamda, farklı düş&uuml;nceden ve farklı kült&uuml;rden &ouml;ğrencilerle bir araya gelerek etkileşimde bulunabilmektedir.</p><p> &nbsp;</p><p> Okulumuzda uyguladığımız sportif programlar, &ouml;ğrencilerimizin yaş grubuna uygun hazırlanarak, sosyal bakımdan gelişimlerine yardımcı olmaktadır.Sportif etkinliklerimizin kazanımlarını aşağıdaki temalara g&ouml;re kurguladık;</p><p> &nbsp;</p><ul><li> Doğayı sevme, temiz hava ve güneşten faydalanabilme.</li><li> İşbirliği i&ccedil;inde&ccedil;alışma ve birlikte davranma alışkanlığı edinebilme.</li><li> G&ouml;rev ve sorumluluk alma, lidere uyma ve liderlik yapma.</li><li> Kendine g&uuml;ven duyma, yerinde ve &ccedil;abuk karar verebilme.</li><li> Dost &ccedil;a oynama ve yarışma, kazananı takdir etme, kaybetmeyi kabullenme, hile ve haksızlığın karşısında olabilme.</li><li> Demokratik hayatın gerektirdiği tavır ve alışkanlıklar kazanma.</li></ul><p> &nbsp;</p><p> Ayrıca Spor Kurulumuz&rsquo;da yer alan konusunda uzman spor adamları ve deneyimli öğretmenlerimizin katkılarıyla oluşturduğumuz, eğitim içerikleriyle, &ccedil;ocuklarımızın bireysel anlamda hangi fiziksel aktiviteye yatkın oldukları belirlenmektedir.Bu verilere g&ouml;re hazırlanan aktiviteler eşliğinde okulumuzda, g&uuml;n&uuml;m&uuml;z &uuml;n en büy&uuml;k sorunlarından biri olan &ldquo;&ccedil;ocuklarda obeziteyi&rdquo; &nbsp; &ouml;nlemek adına da pek &ccedil;ok faaliyet d&uuml;zenlenmektedir.</p><p> &nbsp; Amacımız &ccedil ocuklarımıza t&uuml;m hayatları boyunca spor yapma alışkanlığını kazandırırken aynı zamanda velilerimizi de seminer ve etkinlikler aracılığıyla bilgilendirerek, sporu ailece kaliteli zaman geçirmek i&ccedil;in hayatlarına dahil etmelerini sağlamaktır. &nbsp;</p>" },
                new Page { Title = "Bilişim Eğitimleri", Slug = "bilisim-egitimleri", Template = "Page",Position=6, LanguageId = 1,ParentPageId=48, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Kurullar", Slug = "kurullar", Template = "Page", LanguageId = 1,ParentPageId=48,Position=10, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Okul Öğrenci Konseyi", Slug = "okul-ogrenci-konseyi", Template = "Page",Position=11, LanguageId = 1, ParentPageId = 48, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Vizyon Misyon", Slug = "vizyon-misyon", Template = "Page", LanguageId = 1, Position=2,ParentPageId = 11, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId,Body= "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Anasayfa", Slug = "anasayfa", Template = "Index", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Kindergarten", Slug = "kindergarten", Template = "kindergarten", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Survey", Slug = "survey ", Template = "Survey", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Search", Slug = "search  ", Template = "Search", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "IT Education", Slug = "it-education", Template = "Page", LanguageId = 2, ParentPageId=35, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Contact Us", Slug = "contact-us", Template = "Contact", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Blog", Slug = "blog", Template = "Blog", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Gallery", Slug = "gallery", Template = "Gallery", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Vission Mission", Slug = "vission-mission", Template = "Page", ParentPageId = 30,Position =2, LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Misyon</p><p><strong> Var olma nedenimiz </strong> &ccedil;ocuklarımızdır. <strong> Başarımız </strong> ise;onların<strong> akademik</strong><strong> başarı </strong> larının,</p><ul><li><strong> İngilizce </strong> &rsquo;yled&uuml;nyaya a&ccedil;ılması,</li><li><strong> Teknoloji </strong> yle&uuml;retime katılması,</li><li><strong> Kişisel </strong> <strong> gelişim </strong> le mutlu bir yaşama d&ouml;n&uuml;şmesi,</li><li><strong> Spor </strong> k&uuml;lt&uuml;r&uuml;yle sağlıklı olması,</li><li><strong> Sanat </strong> la hayatına farklı bir anlam kazandırabilmesidir.</li></ul><p> &nbsp;</p><p> Vizyon </p><p> Biz BİLGİ &rsquo;yiz.İnsanlık tarihinin bu kavrama y&uuml;klediği sorumlulukla;</p><ul><li><ul style = 'list-style-type:circle' ><li> İnsanlığın bug&uuml;n&uuml;ne ve geleceğine,</li><li> Barışına,</li><li> &Uuml;retimine,</li><li> &Ccedil;ağdaşlığına,</li><li> Gelişimine,</li><li> İlerlemesine </li></ul></li></ul><p> katkı sağlayan,</p><p> &nbsp;</p><ul><li><ul style= 'list-style-type:circle'><li> K&uuml;lt&uuml;r&uuml;ne ve milli değerlerine sahip &ccedil;ıkan,</li><li> &Uuml;lkesine ve D&uuml;nya &rsquo;ya değer katan,</li><li> &Ouml;zsaygısı, &ouml;zg&uuml;veniy&uuml;ksek bireyler yetiştirmek,</li></ul></li></ul><p> &nbsp;</p><p> Gelişim ve değişime &ouml;nc&uuml;l&uuml;k ederek &ldquo; Eğitim D&uuml;nyası &rdquo;nın lideri olmak.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "News", Slug = "news", Template = "Posts", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Blog", Slug = "blog", Template = "Blog", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Pre Register Form", Slug = "pre-register-form", Template = "PreRegistration", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Apply of Work Form", Slug = "apply-of-work-form", Template = "JobApplicationForm", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Site Map", Slug = "site-map", Template = "SiteMap", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Kurumsal", Slug = "kurumsal", Template = "Page", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Our Staff", Slug = "our-staff", Template = "Page", LanguageId = 2, ParentPageId = 30, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "About Us", Slug = "about-us", Template = "Page", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Pre Register", Slug = "pre-register", Template = "PreRegistration", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Apply of Work", Slug = "apply-of-work", Template = "JobRecourseForm", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Pre School", Slug = "pre-school", Template = "Page", LanguageId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Board of Management", Slug = "board-of-management", Template = "Page", LanguageId = 2, ParentPageId = 30, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "English Education", Slug = "english-education", Template = "Page", LanguageId = 2,ParentPageId=35, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Bilgi Koleji&rsquo;nde, &ccedil;ocuklarımıza basit&ccedil;e dinleme ya da aynı metotların tekrarından oluşan, bilinen y&ouml;ntemler yerine; LSA ( Learning Style Analysis: &Ouml;ğrenme stili analizi ) ve TSA ( Teaching Style Analysis &Ouml;ğretme stili analizi ) alanlarında uzman yabancı &ouml;ğretmenlerimizle, Task Based Learning ( Durum ve Olaylara Dayalı &Ouml;ğrenme) modeliyle, her &ouml;ğrencinin farklı &ouml;ğrenme stiline uygun tasarlanmış bir m&uuml;fredatla İngilizce &ouml;ğretiyoruz. İngilizce eğitimlerimizde kullandığımız, &ldquo;Durum Bazlı &Ouml;ğrenme Modeliyle&rdquo;, doğal dil &ouml;ğrenme hızı yakalanır ve &ouml;l&ccedil;&uuml;lebilir etkin konuşma becerisi kazanılır.</p><p> Bilgi Koleji &rsquo;de,<strong> &ldquo; A + 5B Eğitim Modeli </strong> &rdquo; gereği olarak çocuklarımız İngilizce&rsquo; yi anadil d & uuml; zeyinde öğrenirler.Amacımız öğrencilerimizin hayatları boyunca öğrendikleri İngilizceyi akıcı bir şekilde konuşmalarını sağlamaktır.</p><p> Dil Ko&ccedil; luğu uygulaması, Türkiye &rsquo;de ilk kez Bilgi Koleji & rsquo; nde, eğitim programının i&ccedil;ine yerleştirilmiş, tamamen &ouml;ğrenci odaklı, CEFR (The Common European Framework of Reference for Languages - Avrupa Dil Kriterleri Portfolyosu) &rsquo;na paralel şekilde ilerleyen ve eğitimden maksimum verim alınmasını sağlayan &ouml;zel bir sistemdir.Bu sistemle; eğitim sırasında ve sonrasında kimin hangi &ouml;ğrenme modeline yatkın olduğu s&uuml;rekli g&ouml;zlemlenir ve kişiye &ouml;zel hazırlanan programlarla, eğitim materyallerimiz &ouml;ğrenci merkezli olarak g&uuml;ncellenir, &ouml;ğrenme s&uuml;reci denetlenir. Dil Ko&ccedil;luğu uygulaması ile &ouml;ğrencilerimizin konuşma, anlama, dinleme, ve yazma alanlarının tüm &uuml;nde &ouml;ğrenme içmotivasyonunun yükseltilmesi hedeflenir.</p><p> Bilgi Koleji &rsquo;nde ilkokulu bitiren &ouml;ğrencilerimiz; Cambridge English, Flyers sınavına tabi tutulur ve yeterlilikleri &ouml;l&ccedil;&uuml;l &uuml;r.Ortaokul &ouml;ğrencilerimizin ise Cambridge English, Preliminary English(PET) sınavlarıyla yazılı ve s&ouml;zlüolarak İngilizce seviyeleri &ouml;l&ccedil;&uuml;l&uuml;r. &Ouml;ğrencilerimiz, bu seviye tespit y&ouml;ntemleri sayesinde 8.sınıfın sonunda CEFR kriterlerine g&ouml;re B1-B2 düzeyinde okur, anlar, dinler, konuşur ve yazar d & uuml; zeye ulaşmış olur.</p><p> Deneyimli &ouml;ğretmenlerimiz, ebeveynlerle işbirliği yaparak;&ouml;ğrencilerimize; edindikleri dil becerilerini okul dışında da ortaya koyabileceklerine dair g&uuml;ven duygusu kazandırırlar. &Ccedil;ocuklarımız g&ouml;rsel, işitsel ve oyuna dayalı tekniklerle, İngilizce öğrenimini bilinen &ouml;ğrenmes&uuml;re &ccedil;leri dışında metotlarla doğal kazanım haline getirirler.</p><p> Uluslararası etkinlik ve projelerle öğrendiklerini sunma ve sergileme hazzını yaşayan Bilgi Koleji &ouml;ğrencileri, dil &ouml;ğrenmenin toplumları ve kişileri yaklaştırma ve en önemlisi tanıma yolu olduğunu da deneyimlerler.</p><p> &nbsp;</p>" },
                new Page { Title = "Personal Environment Education", Slug = "personal-environment-education", Template = "Page", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Bilgi Koleji&rsquo;nde &ldquo;<strong>A+5B Eğitim Modeli</strong>&rdquo; nin gereği olarak &ouml;ğrencilerimizin kişisel gelişimlerinin en az akademik gelişimleri kadar &ouml;nemli olduğunun bilincindeyiz. &Ccedil;ocuklarımızın; hayatın t&uuml;m evrelerinde &uuml;retken ve g&uuml;&ccedil;lüolabilmesi i&ccedil;in farklı kazanımlar edinmesini hedefleriz. Bu nedenle okulumuzda; kişisel gelişim alanında rehber &ouml;ğretmenlerimiz dışında var olan kurullarımızda bizimle yola &ccedil;ıkan uzmanı bilim insanlarının da desteği alınmaktadır. &Ouml;ğrencilerimiz, kişisel ve akademik gelişim alanlarında eş zamanlı ilerlemeyi hedefleyen modelimizle, gelecekte &ouml;zg&uuml;ven ve &ouml;zsaygısı tam bireyler olurlar.</p><p> &ldquo; Kişisel Gelişim Eğitimlerimiz &rdquo;de, öğrencilerimize hedeflerine ulaşmak i&ccedil;in motivasyonlarını yükselterek, yaratıcı düş & uuml; nmeyi ve sorumluluk almayı öğretiriz.</ p >< p > Bilgi Koleji & rsquo; de biz, okul öncesinden başlayarak, çocuklarımızın eğitim hayatının tamamına yayılmış oyuna dayalı bir anlayışla, onların en y&uuml;ksek potansiyelini ortaya &ccedil;ıkararak, yaşamları boyunca etkin, verimli ve mutlu olmalarını sağlarız.</p><p> Okulumuzda, Kişisel Gelişim ama &ccedil;lı, her yaş grubuna &ouml;zel hazırlanmış eğlenceli etkinlik ve at&ouml;lye çalışmalarımızı; &ouml;ğrenci ve veliyi kapsayacak bir perspektifle oluştururuz.Bilgi Koleji &ouml;ğrencileri, okul hayatları boyunca aşağıdaki temel başlıklarda kazanımlar edinirler:</p><ul><li> Kendini Tanıma,</li><li> Gerginlikle Baş etme,</li><li> &Ouml;fke KontrolüKazanma,</li><li> Etik Değerleri Geliştirme,</li><li> İletişim Becerileri Kazanma,</li><li> Zamanı Verimli Kullanma,</li><li> Okulda ve Hayatta Zorbalıkla M&uuml;cadele </li><li> Stres Y&ouml;netimi,</li><li> Barış Eğitimi,</li><li> Ergenlik D&ouml;nemi Duygu Y&ouml;netimi </li></ul><p> Bu başlıklar altında yapılan eğitimleri, zaman zaman bire bir g&ouml;r &uuml;şmelerle, velilerimizi de dahil ederek &ldquo; Ebeveyn Eğitimleri&rdquo; ile de pekiştiririz.</p><p> Okulumuz  &uuml;nyesindeki kurullarımızda yer alan uzman pedagog ve eğitimlerimizin işbirliği ile oluşturduğumuz, &ldquo;Bilgi Akademi&rdquo;de, veli, &ouml;ğretmen ve okul çalışanlarına yönelik sürekli eğitim merkezi olarak, okul y önetimiyle işbirliği halinde etkinlikler, eğitimler ve seminerler d&uuml;zenlenir.Amacımız; &ouml;ğrencilerimizin başarısı i&ccedil;in bizimle aynı yolda y&uuml;r&uuml;yen veli, &ouml;ğretmen ve okul &ccedil;alışanlarımızın da hayatın tüm alanlarında verimli ve kaliteli iletişim kurmalarını sağlamak, böylelikle deçocuklarımızın eğitim hayatına daha fazla dokunabilmektir.</p><p> Kurumumuz tarafından oluşturulmuş &ouml;l&ccedil;me - değerlendirme kriterleri ışığında ve &ouml;zellikle velilerle yapılan gör&uuml;şmeler sonucunda &ouml;nceliğimiz &ouml;ğrencilerimizin kazanımlarını arttırmaktır.Bu y&ouml;ntem sayesinde aile ile öğrenci arasındaki iletişim de g&uuml;&ccedil;lenmektedir.T&uuml;m bu s&uuml;re&ccedil;ler konularında uzman bilim insanlarının katılacağı okul i&ccedil;i ve okul dışı seminer ve etkinliklerle de desteklenmektedir.</p><p> &nbsp;</p><p> Kişisel Gelişim Eğitimleri ancak doğru okul iklimi oluşturulduğu hallerde başarıya ulaşabilir. Bu nedenle okulumuzdaki t&uuml;m idari ve akademik kadrolarımız da aynı bilinçve &ouml;zenle se&ccedil;ilip eğitimlere tabi tutulmaktadır.</p><p> &nbsp;</p><p> &nbsp;</p><p> &nbsp;</p>" },
                new Page { Title = "Personal Education", Slug = "personal-education", Template = "Page", LanguageId = 2, ParentPageId = 35, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Commities", Slug = "commities", Template = "Page", LanguageId = 2, ParentPageId = 35, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "School Student Council", Slug = "school-student-council", Template = "Page", LanguageId = 2, ParentPageId = 35, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Page { Title = "Art Education", Slug = "art-education", Template = "Page", LanguageId = 2, ParentPageId=35, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Bilgi Koleji&rsquo;nde eğitim programlarımıza y&ouml;n veren, <strong>&ldquo;A+5B Eğitim Modeli&rdquo; </strong>mizin bileşenlerinden biri de sanat eğitimidir. Bizim bakış a&ccedil;ımıza g&ouml;re, sanat eğitimi; bilim, teknoloji, kişisel gelişim ve spor eğitimleriyle birlikte bireysel ve toplumsal eğitimin vazge&ccedil;ilmezlerinden birisidir. İnsan &ccedil;ok y&ouml;nlüeğitim gereksinimi olan bir varlıktır. Bu nedenle akademik başarıyı destekleyecek bu alanlarda, &ccedil;ocuklarımızın eğilimlerini keşfediyor, uygun i&ccedil;eriklerle zenginleştirilmiş programlar &uuml;retiyor ve eğitimdeki yenilik&ccedil;i anlayışımızla daima g&uuml;ncelliyoruz.</p><p> Ayrıca bizlere destek veren ve öğrencilerimize sanat alanında yol g östermek i&ccedil;in bir araya getirdiğimiz konusunda s öz sahibi olmuş, değerli kişilerden oluşan & ldquo; Sanat Kurulu&rdquo; muz da okulumuz i&ccedil;in ayrı bir gurur kaynağıdır.</ p >< p > öğrencilerimizin, okulumuzda alacakları sanat eğitimi, yaşam boyu sürecek bir disiplinin parçası olacağından, müfredatımızın kazanımları, sadece &ouml;rg&uuml;n eğitimle değil aynı zamanda sergiler, m&uuml;zeler, kitap, dergi, yayın ve her t&uuml;rl&uuml;g&ouml;rsel - işitsel iletişim araçları ile laboratuvar ortamlarıyla da desteklenmektedir. Konularında uzman kişilerden oluşan &ldquo; Sanat Kurulu&rdquo; &uuml;yelerinin gör&uuml;ş ve &ouml;nerileri ışığında &ouml;ğrencilerimizin, sanat ve kült&uuml;r d&uuml;nyasına daha yakın olabilmeleri i&ccedil;in girişimlerde bulunulmaktadır. Kült&uuml;rel alanlara geziler düzenlenmekte ve yine kurulumuz &uuml;yelerinin desteğiyle, farklı alanlardaki sanat&ccedil;ılarla iş birlikleri yapılmaktadır. Ayrıca &ouml;ğrenciler sanatla alakalı organizasyonlara, festival ve yarışmalara katılmak i&ccedil;in teşvik edilmektedirler.</p><p> Kurulumuz &rsquo;da yer alan duayen sanat &ccedil;ılarımız g&ouml;zetiminde ve &ouml;ğretmenlerimizin bakış açısına g&ouml;re sanat eğitiminin amaçlarından biri de bireye g&ouml;rmeyi, işitmeyi, dokunmayı, tat almayı öğretmektir.Okulumuz i&ccedil;in &ouml;zel olarak tasarlanmış görsel sanatlar ve m&uuml;zik at&ouml;lyelerinde yapılan &ccedil;alışmalar, yalnızca bakmak değil, &ldquo;g&ouml;rmek &rdquo;, yalnızca duymak değil &ldquo;işitmek &rdquo;, yalnızca elle yoklamak değil, &ldquo;dokunulanı duyumsamak ve keşfetmek&rdquo; aşamalarını kapsamaktadır.</p><p> Bilgi Koleji &rsquo;nde sanat eğitimi, &ccedil;ocuklarımızın sadece yaratıcılıklarını ortaya çıkartmakla kalmaz, aynı zamanda &ouml;ğrencilerimizin kişisel gelişimlerini de destekler.Bu y&ouml;nüile<strong> &ldquo; A + 5B Eğitim Modeli & rdquo; </strong> mizin bütünl&uuml;ğ&uuml;n&uuml;n ayrılmaz bir parçasıdır.</p><p> Okulumuzda, sanat derslerimiz aşağıdaki başlıklara göre şekillenmiştir:</p><ul><li><strong> G&ouml;rsel sanatlar;</strong> iki boyutlu sanat; resim ve &ccedil;izim gibi, ayrıca &uuml;çboyutlu sanatlar; heykel ve seramik yapımı,</li><li><strong> M&uuml;zik;</strong> m&uuml;zik performansı, kompozisyon ve m&uuml;zik eleştirisi,</li><li><strong> Drama;</strong> drama performansı, oyun yazarlığı ve oyun eleştirmenliği,</li><li><strong> Dans;</strong> dans performansı, koreografi ve dans eleştirmenliği,</li><li><strong> Medya sanatları;</strong> fotoğraf &ccedil;ılık, sinema, video ve bilgisayar animasyonları,</li><li><strong> Mimari;</strong> bina tasarım sanatı; bir alanın g&ouml;zlemi, planlaması ve bilgisayar ortamına 3 boyutlu modellemesi,</li></ul><p> Bilgi Koleji &rsquo;nde; sanatsal duyarlılıkları eğitilen &ccedil;ocuklarımız, bu duyarlılıkla ve yaklaşımla g&ouml;zleriyle de d&uuml;ş ünerekd&uuml;nyaya bakar ve üretirler.</p>" },
                new Page { Title = "Sport Education", Slug = "sport-education", Template = "Page", LanguageId = 2,ParentPageId=35,IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId, Body = "<p>Bilgi Koleji&rsquo;nin eğitim i&ccedil;erikleri ve &ldquo;A+5B Eğitim Modeli&rdquo; oluşturulurken, Spor Kurulu&rsquo;muzun da katkıları alınarak; sporun &ccedil;ocuk ve gen&ccedil;lerde fiziksel, duyusal, sosyal ve bilişsel kazanımları desteklediği prensibiyle ile yola &ccedil;ıkılmıştır.</p><p> &nbsp;</p><p> Okulumuzda yapılan sportif etkinlikler, öğrencilerimizin bedensel özellikleri, spora yönelik ilgi alanları ve yetenekleri bilimsel testler yardımıyla saptandıktan sonra, akademik gelişim ile sağlıklı yaşam parametreleri dikkate alınarak planlanır. Bizce spor, çocuklarımızın sadece bedenini değil, büt&uuml;nsel gelişimlerini son derece önemli ve gereklidir.</p><p> &nbsp;</p><p> öğrencilerimizin gerek psikolojik gerekse sosyal bakımdan gelişmelerinde, oyunla birlikte sporun önemli bir yeri vardır. çünk & uuml; çocuklarımız bu faaliyetlere katılırken aynı zamanda grup içerisinde hareket etmeyi, kazanmayı veya kaybetmeyi, kurallara uymayı öğrenmektedir.</p><p> En önemlisi, öğrencilerimiz sportif aktivitelere katılarak, kendine g&uuml;ven duygusunu kazanmakta ve toplumun bir ferdi olduğunu anlamaktadır.Bilgi Koleji&rsquo;nde &ouml;ğrencilerimiz, sportif etkinliklerimiz sayesinde birçok farklı ortamda, farklı düş&uuml;nceden ve farklı kült&uuml;rden &ouml;ğrencilerle bir araya gelerek etkileşimde bulunabilmektedir.</p><p> &nbsp;</p><p> Okulumuzda uyguladığımız sportif programlar, &ouml;ğrencilerimizin yaş grubuna uygun hazırlanarak, sosyal bakımdan gelişimlerine yardımcı olmaktadır.Sportif etkinliklerimizin kazanımlarını aşağıdaki temalara g&ouml;re kurguladık;</p><p> &nbsp;</p><ul><li> Doğayı sevme, temiz hava ve güneşten faydalanabilme.</li><li> İşbirliği i&ccedil;inde&ccedil;alışma ve birlikte davranma alışkanlığı edinebilme.</li><li> G&ouml;rev ve sorumluluk alma, lidere uyma ve liderlik yapma.</li><li> Kendine g&uuml;ven duyma, yerinde ve &ccedil;abuk karar verebilme.</li><li> Dost &ccedil;a oynama ve yarışma, kazananı takdir etme, kaybetmeyi kabullenme, hile ve haksızlığın karşısında olabilme.</li><li> Demokratik hayatın gerektirdiği tavır ve alışkanlıklar kazanma.</li></ul><p> &nbsp;</p><p> Ayrıca Spor Kurulumuz&rsquo;da yer alan konusunda uzman spor adamları ve deneyimli öğretmenlerimizin katkılarıyla oluşturduğumuz, eğitim içerikleriyle, &ccedil;ocuklarımızın bireysel anlamda hangi fiziksel aktiviteye yatkın oldukları belirlenmektedir.Bu verilere g&ouml;re hazırlanan aktiviteler eşliğinde okulumuzda, g&uuml;n&uuml;m&uuml;z &uuml;n en büy&uuml;k sorunlarından biri olan &ldquo;&ccedil;ocuklarda obeziteyi&rdquo; &nbsp; &ouml;nlemek adına da pek &ccedil;ok faaliyet d&uuml;zenlenmektedir.</p><p> &nbsp; Amacımız &ccedil ocuklarımıza t&uuml;m hayatları boyunca spor yapma alışkanlığını kazandırırken aynı zamanda velilerimizi de seminer ve etkinlikler aracılığıyla bilgilendirerek, sporu ailece kaliteli zaman geçirmek i&ccedil;in hayatlarına dahil etmelerini sağlamaktır. &nbsp;</p>" }

                );     

        }


        private static void AddSettings(ApplicationDbContext context,AppTenant tenant)
        {
            var s = new Setting();
            s.AppTenantId = tenant.AppTenantId;
            s.HeaderString = "";
            s.GoogleAnalytics = "";
            s.FooterScript = "";
            s.SmtpUserName = "denemecvhavuzu@gmail.com";
            s.SmtpPassword = "123:Asdfg";
            s.SmtpHost = "smtp.gmail.com";
            s.SmtpPort = "587";
            s.SmtpUseSSL = true;
            s.CreateDate = DateTime.Now;
            s.CreatedBy = "username";
            s.UpdateDate = DateTime.Now;
            s.UpdatedBy = "username";
            s.MapLat = "40.989143";
            s.MapLon = "29.0289560";
            s.MapTitle = "Bilişim Eğitim Merkezi";
            context.Settings.Add(s);
            context.SaveChanges();
            
           
        }
        public static void AddCustomization(ApplicationDbContext context, AppTenant tenant)
        {
            var customization = new Customization();
            customization.AppTenantId = tenant.AppTenantId;
            customization.ThemeId = tenant.ThemeId;
            customization.ThemeName = tenant.ThemeName;
            customization.MetaKeywords = tenant.Theme.MetaKeywords;
            customization.MetaDescription = tenant.Theme.MetaDescription;
            customization.MetaTitle = tenant.Theme.MetaTitle;
            customization.Logo = tenant.Theme.Logo;
            customization.ImageUrl = tenant.Theme.ImageUrl;
            customization.CustomCSS = tenant.Theme.CustomCSS;
            customization.CreateDate = DateTime.Now;
            customization.CreatedBy = "UserName";
            customization.UpdateDate = DateTime.Now;
            customization.UpdatedBy = "UserName";
            customization.PageTemplates = tenant.Theme.PageTemplates;
            customization.ComponentTemplates = tenant.Theme.ComponentTemplates;
            context.Customizations.Add(customization);
            context.SaveChanges();

        }
        private static void AddForms(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new Form { FormName = "Sizi Arayalım", Slug = "sizi-arayalim", EmailTo = "mdemirci@outlook.com", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Form { FormName = "İletişim", Slug = "iletisim", EmailTo = "mdemirci@outlook.com", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Form { FormName = "Anaokulu iletişim", Slug = "anaokulu-iletisim", EmailTo = "mdemirci@outlook.com", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Form { FormName = "İş Başvuru Formu", Slug = "is-basvuru-formu", EmailTo = "mdemirci@outlook.com", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Form { FormName = "OrtaOkul iletişim", Slug = "ortaokul-iletisim", EmailTo = "mdemirci@outlook.com", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                 new Form { FormName = "Lise iletişim", Slug = "lise-iletisim", EmailTo = "mdemirci@outlook.com", LanguageId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }

                );
            context.SaveChanges();
        }

        private static void AddFormFields(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new FormField { Name = "Ad Soyad", FormId = 1, FieldType = FieldType.fullName, Position = 1, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "E-posta", FormId = 1, FieldType = FieldType.email, Position = 2, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Telefon", FormId = 1, FieldType = FieldType.telephone, Position = 3, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Çocuğunuzu kaydettirmeyi düşündüğünüz okul aşağıdakilerden hangisidir?", FormId = 1, FieldType = FieldType.radioButtons, Position = 4, Required = true, Value = "Anaokulu,İlkokul,Ortaokul,Lise", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Çocuğunuzu kaydettirmeyi düşündüğünüz sınıf hangisidir?", FormId = 1, FieldType = FieldType.dropdownMenu, Position = 5, Required = true, Value = "Seçiniz,1,2,3,4", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Abonelik", FormId = 1, FieldType = FieldType.checkbox, Position = 6, Required = true, Value = "Bilgi Koleji Okullarından gönderilen her türlü haber&#44; bilgi ve tanıtım içeriklerinden e-posta adresim ve telefonum aracılığıyla haberdar olmak istiyorum.", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
                );
            context.SaveChanges();
            context.AddRange(
                new FormField { Name = "Ad Soyad", FormId = 2, FieldType = FieldType.fullName, Position = 1, Required = false, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "E-posta", FormId = 2, FieldType = FieldType.email, Position = 2, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Telefon", FormId = 2, FieldType = FieldType.telephone, Position = 3, Required = false, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Mesajınız", FormId = 2, FieldType = FieldType.largeText, Position = 3, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
                );
            context.SaveChanges();
            context.AddRange(
               new FormField { Name = "Ad Soyad", FormId = 3, FieldType = FieldType.fullName, Position = 1, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
               new FormField { Name = "Yaş Grubu", FormId = 3, FieldType = FieldType.smallText, Position = 2, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
               new FormField { Name = "Telefon Numarası", FormId = 3, FieldType = FieldType.telephone, Position = 3, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
               new FormField { Name = "Veli Adı Soyadı", FormId = 3, FieldType = FieldType.fullName, Position = 4, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
               );
            context.SaveChanges();
            context.AddRange(
                new FormField { Name = "Ad Soyad", FormId = 4, FieldType = FieldType.fullName, Position = 1, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "E-posta", FormId = 4, FieldType = FieldType.email, Position = 2, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Telefon", FormId = 4, FieldType = FieldType.telephone, Position = 3, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                  new FormField { Name = "CV", FormId = 4, FieldType = FieldType.file, Position = 4, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                    new FormField { Name = "Ön Yazı", FormId = 4, FieldType = FieldType.largeText, Position = 5, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
                    

                );
            context.SaveChanges();

            context.AddRange(
                new FormField { Name = "Ad Soyad", FormId = 5, FieldType = FieldType.fullName, Position = 1, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Yaş Grubu", FormId = 5, FieldType = FieldType.numberValue, Position = 2, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new FormField { Name = "Telefon Numarası", FormId = 5, FieldType = FieldType.telephone, Position = 3, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                  new FormField { Name = "Veli Adı Soyadı", FormId = 5, FieldType = FieldType.file, Position = 4, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
                   
                );
            context.SaveChanges();
            context.AddRange(
              new FormField { Name = "Ad Soyad", FormId = 6, FieldType = FieldType.fullName, Position = 1, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
              new FormField { Name = "Yaş Grubu", FormId = 6, FieldType = FieldType.smallText, Position = 2, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
              new FormField { Name = "Telefon Numarası", FormId = 6, FieldType = FieldType.telephone, Position = 3, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
              new FormField { Name = "Veli Adı Soyadı", FormId = 6, FieldType = FieldType.fullName, Position = 4, Required = true, Value = "", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
              );
            context.SaveChanges();
        }

        private static void AddMenus(ApplicationDbContext context, AppTenant tenant)
        {
            var menu = new Menu { Name = "Ana Menü", MenuLocation = "Primary", LanguageId = 1, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId=tenant.AppTenantId };
            var menu2 = new Menu { Name = "Home Menu", MenuLocation = "Primary", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId };

            context.AddRange(menu);
            context.AddRange(menu2);

            context.SaveChanges();
        }
        private static void AddMenuItems(ApplicationDbContext context, AppTenant tenant)
        {
            context.AddRange(
                new MenuItem { Name = "Hakkımızda", Url = "hakkimizda", Position = 1, IsPublished = true, MenuId = 1, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Farkımız", Url = "farkimiz", Position = 2, MenuId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Eğitim Modeli", Url = "egitim-modeli", Position = 3, IsPublished = true, MenuId = 1, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Kampüs", Url = "kampus", Position = 4, MenuId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "İletişim", Url = "iletisim", Position = 5, MenuId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
                );
            context.SaveChanges();
            context.AddRange(
                new MenuItem { Name = "About Us", Url = "about-us", Position = 1, IsPublished = true, MenuId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Differences", Url = "differences", Position = 2, IsPublished = true, MenuId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Education Model", Url = "education-model", Position = 3, IsPublished = true, MenuId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Campus", Url = "campus", Position = 4, IsPublished = true, MenuId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Contact", Url = "contact", Position = 5, IsPublished = true, MenuId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }  
                );
            context.SaveChanges();
            context.AddRange(
                new MenuItem { Name = "Kurumsal", Url = "kurumsal", Position = 1, MenuId = 1, IsPublished = true, ParentMenuItemId = 1, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Vizyon Misyon", Url = "vizyon-misyon", Position = 2, IsPublished = true, MenuId = 1, ParentMenuItemId = 1, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Kadromuz", Url = "kadromuz", MenuId = 1, Position = 3, IsPublished = true, ParentMenuItemId = 1, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Yönetim Kurulumuz", Url = "yonetim-kurulumuz", MenuId = 1, IsPublished = true, Position = 4, ParentMenuItemId = 1, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "İngilizce Eğitimleri", Url = "ingilizce-egitimleri", MenuId = 1, IsPublished = true, Position = 5, ParentMenuItemId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Bilişim Eğitimleri", Url = "bilisim-egitimleri", MenuId = 1, IsPublished = true, Position = 6, ParentMenuItemId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Kişisel Gelişim", Url = "kisisel-gelisim", MenuId = 1, IsPublished = true, Position = 7, ParentMenuItemId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Sanat Eğitimleri", Url = "sanat-egitimleri", MenuId = 1, IsPublished = true, Position = 8, ParentMenuItemId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Spor Eğitimi", Url = "spor-egitimi", MenuId = 1, IsPublished = true, Position = 9, ParentMenuItemId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Kurullar", Url = "kurullar", MenuId = 1, IsPublished = true, Position = 10, ParentMenuItemId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Okul Öğrenci Konseyi", Url = "okul-ogrenci-konseyi", Position = 11, IsPublished = true, MenuId = 1, ParentMenuItemId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "A+5B Eğitim Modeli", Url = "a-5b-egitim-modeli", Position = 12, IsPublished = true, MenuId = 1, ParentMenuItemId = 3, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Anaokulu", Url = "anaokulu", MenuId = 1, Position = 13, IsPublished = true, ParentMenuItemId = 3, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "İlkokul", Url = "ilkokul", MenuId = 1, Position = 14, IsPublished = true, ParentMenuItemId = 3, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Ortaokul", Url = "ortaokul", MenuId = 1, Position = 15, IsPublished = true, ParentMenuItemId = 3, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Lise", Url = "lise", MenuId = 1, Position = 16, IsPublished = true, ParentMenuItemId = 3, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Derslikler", Url = "derslikler", Position = 17, MenuId = 1, IsPublished = true, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "İngilizce Laboratuvarı", Url = "ingilizce-laboratuvari", Position = 18, IsPublished = true, MenuId = 1, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Bilişim Laboratuvarı", Url = "bilisim-laboratuvarı", MenuId = 1, Position = 19, IsPublished = true, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Fen Bilimleri Laboratuvarı", Url = "fen-bilimleri-laboratuvari", Position = 20, IsPublished = true, MenuId = 1, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Müzik Atölyesi", Url = "muzik-atolyesi", MenuId = 1, Position = 21, IsPublished = true, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Güzel Sanatlar Atölyesi", Url = "guzel-sanatlar-atolyesi", MenuId = 1, IsPublished = true, Position = 22, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Spor Salonu", Url = "spor-salonu", MenuId = 1, Position = 23, IsPublished = true, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Kütüphane", Url = "kutuphane", MenuId = 1, Position = 24, IsPublished = true, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Yemekhane", Url = "yemekhane", MenuId = 1, Position = 25, IsPublished = true, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Bahçe", Url = "bahce", MenuId = 1, Position = 26, IsPublished = true, ParentMenuItemId = 4, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Bize Ulaşın", Url = "bize-ulasin", MenuId = 1, Position = 27, IsPublished = true, ParentMenuItemId = 5, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Ön Kayıt", Url = "on-kayit-formu", MenuId = 1, Position = 28, IsPublished = true, ParentMenuItemId = 5, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Online Veli Görüşmesi", Url = "online-veli-gorusmesi", MenuId = 1, Position = 29, IsPublished = true, ParentMenuItemId = 5, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Veli-Öğrenci El Kitabı", Url = "veli-ogrenci-el-kitabi", MenuId = 1, Position = 30, IsPublished = true, ParentMenuItemId = 5, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Anket", Url = "anket", MenuId = 1, Position = 31, IsPublished = true, ParentMenuItemId = 5, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Corporate", Url = "corporate", Position = 1, MenuId = 2, IsPublished = true, ParentMenuItemId = 6, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Vission Mission", Url = "vission-mission", Position = 2, MenuId = 2, IsPublished = true, ParentMenuItemId = 6, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Our Staff", Url = "our-staff", Position = 3, MenuId = 2, IsPublished = true, ParentMenuItemId = 6, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Board of Management", Url = "board-of-management", Position = 4, MenuId = 2, IsPublished = true, ParentMenuItemId = 6, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "English Education", Url = "english-education", Position = 5, MenuId = 2, IsPublished = true, ParentMenuItemId = 7, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "IT Education", Url = "it-education", Position = 6, MenuId = 2, IsPublished = true, ParentMenuItemId = 7, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Personal Evolution", Url = "personal-evolution", Position = 7, MenuId = 2, IsPublished = true, ParentMenuItemId = 7, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Art Education", Url = "art-education", Position = 8, MenuId = 2, IsPublished = true, ParentMenuItemId = 7, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Sport Education", Url = "sport-education", Position = 9, MenuId = 2, IsPublished = true, ParentMenuItemId = 7, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Committies", Url = "Committies", MenuId = 2, Position = 10, IsPublished = true, ParentMenuItemId = 7, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "School Student Council", Url = "school-student-council", Position = 11, MenuId = 2, IsPublished = true, ParentMenuItemId = 7, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "A+5B Education Model", Url = "a5b-education-model", Position = 12, MenuId = 2, IsPublished = true, ParentMenuItemId = 8, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Kindergarten", Url = "kindergarten", Position = 13, MenuId = 2, IsPublished = true, ParentMenuItemId = 8, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Primary School", Url = "primary-school", Position = 14, MenuId = 2, IsPublished = true, ParentMenuItemId = 8, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Middle School", Url = "middle-school", Position = 15, MenuId = 2, IsPublished = true, ParentMenuItemId = 8, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "High School", Url = "high-school", Position = 16, MenuId = 2, IsPublished = true, ParentMenuItemId = 8, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Classes", Url = "classes", Position = 17, MenuId = 2, IsPublished = true, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "English Laboratory", Url = "english-laboratory", Position = 18, IsPublished = true, MenuId = 2, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "IT Laboratory", Url = "it-laboratory", MenuId = 2, Position = 19, IsPublished = true, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Science Laboratory", Url = "science-laboratory", Position = 20, IsPublished = true, MenuId = 2, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Music Studio", Url = "music-studio", MenuId = 2, Position = 21, IsPublished = true, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Art Studio", Url = "art-studio", MenuId = 2, IsPublished = true, Position = 22, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Sport Center", Url = "sport-center", MenuId = 2, Position = 23, IsPublished = true, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Library", Url = "library", MenuId = 2, Position = 24, IsPublished = true, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Refectory", Url = "refectory", MenuId = 2, Position = 25, IsPublished = true, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Garden", Url = "garden", MenuId = 2, Position = 26, IsPublished = true, ParentMenuItemId = 9, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Contact Us", Url = "contact-us", MenuId = 2, Position = 27, IsPublished = true, ParentMenuItemId = 10, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Pre Register", Url = "pre-register", MenuId = 2, Position = 28, IsPublished = true, ParentMenuItemId = 10, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Online Parent Interview", Url = "online-parent-interview", MenuId = 2, Position = 29, IsPublished = true, ParentMenuItemId = 10, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Parent-Student Hand Book", Url = "parent-student-hand-book", MenuId = 2, Position = 30, IsPublished = true, ParentMenuItemId = 10, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new MenuItem { Name = "Survey", Url = "survey", MenuId = 2, Position = 31, IsPublished = true, ParentMenuItemId = 10, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId });


            context.SaveChanges();
        }

        private static void AddHomePageSlider(ApplicationDbContext context, AppTenant tenant)
        {
            var slider = new Slider();
            slider.AppTenantId = tenant.AppTenantId;

            slider.IsPublished = true;
            slider.Name = "Anasayfa Slider";
            slider.Template = "Default";
            slider.CreateDate = DateTime.Now;
            slider.CreatedBy = "username";
            slider.UpdateDate = DateTime.Now;
            slider.UpdatedBy = "username";
            slider.Slides = new HashSet<Slide>();
            context.Sliders.Add(slider);
            context.SaveChanges();


        }

        private static void AddHomePageSlide(ApplicationDbContext context, AppTenant tenant)
        {
            var s1 = new Slide();
            s1.AppTenantId = tenant.AppTenantId;

            s1.Title = "Başlık1";
            s1.SubTitle = "Alt Başlık1";
            s1.Description = "Açıklama1";
            s1.Position = 1;
            s1.Video = "/uploads/slidervideo.mp4";
            s1.CallToActionText = "Buton1";
            s1.CallToActionUrl = "#";
            s1.DisplayTexts = false;
            s1.IsPublished = true;
            s1.SliderId = 1;
            s1.CreateDate = DateTime.Now;
            s1.CreatedBy = "username";
            s1.UpdateDate = DateTime.Now;
            s1.UpdatedBy = "username";
            context.Slides.Add(s1);

            var s2 = new Slide();
            s2.AppTenantId = tenant.AppTenantId;

            s2.Title = "Başlık2";
            s2.SubTitle = "Alt Başlık2";
            s2.Description = "Açıklama2";
            s2.Position = 1;
            s2.Photo = "/uploads/5-2017/9a2ef92e2e0ca0fb061171e27596dfeb.jpg";
            s2.CallToActionText = "Buton2";
            s2.CallToActionUrl = "#";
            s2.DisplayTexts = false;
            s2.IsPublished = true;
            s2.SliderId = 1;
            s2.CreateDate = DateTime.Now;
            s2.CreatedBy = "username";
            s2.UpdateDate = DateTime.Now;
            s2.UpdatedBy = "username";
            context.Slides.Add(s2);

            var s3 = new Slide();
            s3.AppTenantId = tenant.AppTenantId;

            s3.Title = "Başlık3";
            s3.SubTitle = "Alt Başlık3";
            s3.Description = "Açıklama3";
            s3.Position = 1;
            s3.Photo = "/uploads/5-2017/9a2ef92e2e0ca0fb061171e27596dfeb.jpg";
            s3.CallToActionText = "Buton3";
            s3.CallToActionUrl = "#";
            s3.DisplayTexts = false;
            s3.IsPublished = true;
            s3.SliderId = 1;
            s3.CreateDate = DateTime.Now;
            s3.CreatedBy = "username";
            s3.UpdateDate = DateTime.Now;
            s3.UpdatedBy = "username";
            context.Slides.Add(s3);
            context.SaveChanges();


        }

        private static void AddSecondarySlider(ApplicationDbContext context, AppTenant tenant)
        {
            var slider = new Slider();
            slider.AppTenantId = tenant.AppTenantId;

            slider.IsPublished = true;
            slider.Name = "Anasayfa İkinci Slider";
            slider.Template = "Secondary";
            slider.CreateDate = DateTime.Now;
            slider.CreatedBy = "username";
            slider.UpdateDate = DateTime.Now;
            slider.UpdatedBy = "username";
            slider.Slides = new HashSet<Slide>();

            context.Sliders.Add(slider);
            context.SaveChanges();


        }

        private static void AddSecondarySlide(ApplicationDbContext context, AppTenant tenant)
        {
            var s1 = new Slide();
            s1.AppTenantId = tenant.AppTenantId;

            s1.Title = "Başlık4";
            s1.SubTitle = "Alt Başlık4";
            s1.Description = "Açıklama4";
            s1.Position = 2;
            s1.Photo = "/uploads/5-2017/9a2ef92e2e0ca0fb061171e27596dfeb.jpg";
            s1.CallToActionText = "Buton4";
            s1.CallToActionUrl = "#";
            s1.DisplayTexts = false;
            s1.IsPublished = true;
            s1.SliderId = 2;
            s1.CreateDate = DateTime.Now;
            s1.CreatedBy = "username";
            s1.UpdateDate = DateTime.Now;
            s1.UpdatedBy = "username";
            context.Slides.Add(s1);

            var s2 = new Slide();
            s2.AppTenantId = tenant.AppTenantId;

            s2.Title = "Başlık5";
            s2.SubTitle = "Alt Başlık5";
            s2.Description = "Açıklama5";
            s2.Position = 2;
            s2.Photo = "/uploads/5-2017/9a2ef92e2e0ca0fb061171e27596dfeb.jpg";
            s2.CallToActionText = "Buton5";
            s2.CallToActionUrl = "#";
            s2.DisplayTexts = false;
            s2.IsPublished = true;
            s2.SliderId = 2;
            s2.CreateDate = DateTime.Now;
            s2.CreatedBy = "username";
            s2.UpdateDate = DateTime.Now;
            s2.UpdatedBy = "username";
            context.Slides.Add(s2);
            context.SaveChanges();


        }

        private static void AddLogoSlider(ApplicationDbContext context, AppTenant tenant)
        {
            var slider = new Slider();
            slider.AppTenantId = tenant.AppTenantId;

            slider.IsPublished = true;
            slider.Name = "Logo Slider";
            slider.Template = "LogoSlider";
            slider.CreateDate = DateTime.Now;
            slider.CreatedBy = "username";
            slider.UpdateDate = DateTime.Now;
            slider.UpdatedBy = "username";
            slider.Slides = new HashSet<Slide>();

            context.Sliders.Add(slider);
            context.SaveChanges();


        }

        private static void AddLogoSlide(ApplicationDbContext context, AppTenant tenant)
        {

            var s1 = new Slide();
            s1.AppTenantId = tenant.AppTenantId;

            s1.Title = "Başlık6";
            s1.SubTitle = "Alt Başlık6";
            s1.Description = "Açıklama6";
            s1.Position = 3;
            s1.Photo = "/uploads/5-2017/9a2ef92e2e0ca0fb061171e27596dfeb.jpg";
            s1.CallToActionText = "Buton6";
            s1.CallToActionUrl = "#";
            s1.DisplayTexts = false;
            s1.IsPublished = true;
            s1.SliderId = 3;
            s1.CreateDate = DateTime.Now;
            s1.CreatedBy = "username";
            s1.UpdateDate = DateTime.Now;
            s1.UpdatedBy = "username";
            context.Slides.Add(s1);

            var s2 = new Slide();
            s2.AppTenantId = tenant.AppTenantId;

            s2.Title = "Başlık7";
            s2.SubTitle = "Alt Başlık7";
            s2.Description = "Açıklama7";
            s2.Position = 3;
            s2.Photo = "/uploads/5-2017/9a2ef92e2e0ca0fb061171e27596dfeb.jpg";
            s2.CallToActionText = "Buton7";
            s2.CallToActionUrl = "#";
            s2.DisplayTexts = false;
            s2.IsPublished = true;
            s2.SliderId = 3;
            s2.CreateDate = DateTime.Now;
            s2.CreatedBy = "username";
            s2.UpdateDate = DateTime.Now;
            s2.UpdatedBy = "username";
            context.Slides.Add(s2);
            context.SaveChanges();


        }



        private static void AddGalleries(ApplicationDbContext context,AppTenant tenant)
        {




            context.AddRange(
            new Gallery { Name = "Galeri Sayfası", IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            new Gallery { Name = "Anasayfa Galeri", IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId });
            context.SaveChanges();


        }
        private static void AddGalleryItemCategories(ApplicationDbContext context, AppTenant tenant)
        {
            
            context.AddRange(
            new GalleryItemCategory { Name = "Flat", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now,Description= "flat", ParentCategoryId = null, Slug = "flat", AppTenantId = tenant.AppTenantId },
            new GalleryItemCategory { Name = "Standart", CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, Description = "standart",ParentCategoryId=null,Slug= "standart", AppTenantId = tenant.AppTenantId });
            context.SaveChanges();


        }
        private static void AddGalleryItems(ApplicationDbContext context,AppTenant tenant)
        {
           
            
            context.AddRange(
                new GalleryItem { Title = "flat1", Description = "flat 1", Position = 1, Photo = "/uploads/images/1.jpg", Video=null,Meta1= "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "Empt", Description = "Empt", Position = 11, Photo = "/uploads/images/2.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "bono", Description = "bono", Position = 7, Photo = "/uploads/images/3.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "kitcube", Description = "kit", Position = 6, Photo = "/uploads/images/4.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "sch", Description = "sch", Position = 8, Photo = "/uploads/images/5.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "m-W", Description = "m-W", Position = 11, Photo = "/uploads/images/6.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "catarse", Description = "cat", Position = 15, Photo = "/uploads/images/7.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "brand", Description = "brand", Position = 11, Photo = "/uploads/images/8.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "firefox", Description = "fire", Position = 11, Photo = "/uploads/images/9.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "joystick", Description = "x", Position = 12, Photo = "/uploads/images/10.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "fox", Description = "f", Position = 113, Photo = "/uploads/images/11.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "dc", Description = "DC", Position = 14, Photo = "/uploads/images/12.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "slug", Description = "sl", Position = 15, Photo = "/uploads/images/13.png", Video = null, Meta1 = "grid-item-height1", GalleryId = 1, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "Kalem", Description = "a", Position = 18, Photo = "/uploads/images/14.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "kareli falan bir hareket", Description = null, Position = 18, Photo = "/uploads/images/15.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "dikey", Description = "s", Position = 17, Photo = "/uploads/images/16.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new GalleryItem { Title = "web", Description = "webtrend", Position = 17, Photo = "/uploads/images/17.jpg", Video = null, Meta1 = "grid-item-height1", GalleryId = 2, IsPublished = true, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }


            );
            context.SaveChanges();
        }
        private static void AddResources(ApplicationDbContext context, AppTenant tenant)
        {

            context.AddRange(
                new Resource { Name = "Anaokulu", Value = "Kindergarten", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "İlkokul", Value = "Primary School", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Ortaokul", Value = "Middle School", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Lise", Value = "High School", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Arayınız...", Value = "Call Us", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Hızlı Ara", Value = "Fast Call", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "MUTLULUK VEREN BİLGİ'Yİ BİRLİKTE ÇOĞALTALIM", Value = "WE INCREASE HAPPY KNOWLEDGE TOGETHER", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "(Akademi ve İdari Personel Başvuruları)", Value = "Academy and Administrative Staff Applications", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Başvur", Value = "Apply", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "HAKKINDA", Value = "ABOUT", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "FooterAboutText", Value = "", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Mail", Value = "Mail", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Telefon", Value = "Phone", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Adres", Value = "Address", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "BAĞLANTILAR", Value = "LINKS", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Akademik Takvim", Value = "Academic Calendar", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Etkinlikler", Value = "Activities", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Basın", Value = "Press", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "İnsan Kaynakları", Value = "Human Resources", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Kendini Değerlendir", Value = "Evaluate yourself", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Bilgi Store", Value = "Information Store", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Veli İletişim", Value = "Parent Communication", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Ek Alanlar", Value = "Additional Areas", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Site Haritası", Value = "Site Map", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "E-Bülten", Value = "E-Newsletter", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "En son yeniliklerden ve tekliflerden haberdar olmak için e-posta listemize katılın.", Value = "Join our email list to be notified of the latest innovations and offers.", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "E-posta adresi", Value = "E-mail Address", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Gizliliğinize saygı duyuyoruz.", Value = "We respect your privacy.", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "GÜNCEL DUYURULAR", Value = "Actual Announcements", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "BİLGİ KOLEJİ'NDEN EN SON HABERLER", Value = "THE LAST NEWS FROM BİLGİ KOLEJİ", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Detaylı Bilgi", Value = "More Information", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Görün Ve Hissedin", Value = "See and Feel", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Galeri", Value = "Gallery", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Daha Fazla Fotoğraf", Value = "More photographs", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Gönder", Value = "Send", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Form bulunamadı!", Value = "Form can't find!", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "EN İYİSİNDEN ÖĞRENİN", Value = "Learn The Best", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "KADROMUZ", Value = "OUR STAFF", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Devamını oku...", Value = "Read More...", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Hakkımızda", Value = "About Us", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Farkımız", Value = "Our Difference", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Eğitim Modeli", Value = "Education Model", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Okul Konsepti", Value = "School Concept", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Kampüs", Value = "Campus", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "ANAOKULU", Value = "KINDERGARTEN", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "İletişim", Value = "Contact", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Buraya form gelicek", Value = "Forms should come here.", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "LİSE", Value = "HIGH SCHOOL", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Son Yazılar", Value = "Last Posts", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Çok Okunanlar", Value = "Most Read", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "İş Başvuru Formu", Value = "Job Application Form", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Galeri Sayfası", Value = "Gallery Page", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Diğer", Value = "Other", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Anaokulu iletişim", Value = "Kindergarten Contact", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "AnaOkulu", Value = "Kindergarten", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "ORTAOKUL", Value = "MIDDLE SCHOOL", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "ortaokul", Value = "MiddleSchool", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "İlgili Sayfalar", Value = "Related Pages", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Son Yazılar", Value = "Last Posts", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "İLKOKUL", Value = "PRIMARY SCHOOL", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "ilkokul", Value = "PrimarySchool", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
                new Resource { Name = "Survey", Value = "Anket", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }
                

            //new Resource { Name = "Kurumsal", Value = "Corporate", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Vizyon Misyon", Value = "Vission Mission", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Kadromuz", Value = "Our Staff", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Yönetim Kurulumuz", Value = "Board of Management", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "İngilizce Eğitimleri", Value = "English Education", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Bilişim Eğitimleri", Value = "IT Education", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Kişisel Gelişim", Value = "Personal Evoluation", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Sanat Eğitimleri", Value = "Art Educations", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Spor Eğitimi", Value = "Sport Education", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Kurullar", Value = "Committees", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Okul Öğrenci Konseyi", Value = "School Student Council", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Derslikler", Value = "Classes", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "İngilizce Laboratuvarı", Value = "English Laboratory", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Bilişim Laboratuvarı", Value = "IT Laboratory", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Fen Bilimleri Laboratuvarı", Value = "Science Laboratory", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Müzik Atölyesi", Value = "Music Workshop", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Güzel Sanatlar Atölyesi", Value = "Fine Arts Workshop", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Spor Salonu", Value = "Sport Center", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Kütüphane", Value = "Library", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Yemekhane", Value = "Refectory", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Bahçe", Value = "Garden", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Bize Ulaşın", Value = "Contact Us", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Ön Kayıt", Value = "Pre-registration", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Online Veli Görüşmesi", Value = "Online Parent Interview", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Veli-Öğrenci El Kitabı", Value = "Parent-Student Hand Book", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId },
            //new Resource { Name = "Anket", Value = "Survey", LanguageId = 2, CreatedBy = "username", CreateDate = DateTime.Now, UpdatedBy = "username", UpdateDate = DateTime.Now, AppTenantId = tenant.AppTenantId }



            );
            context.SaveChanges();
        }


    }
}

